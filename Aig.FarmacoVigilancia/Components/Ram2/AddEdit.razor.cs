using Aig.FarmacoVigilancia.Nomenclators;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using DataModel.Helper;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;
using Aig.FarmacoVigilancia.Events.Language;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Net.Mail;

namespace Aig.FarmacoVigilancia.Components.Ram2
{    
    public partial class AddEdit
    {
        [Inject]
        IRamService2 ramService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IWorkerPersonService evaluatorService { get; set; }
        [Inject]
        IPdfGenerationService pdfGenerationService { get; set; }
        [Inject]
        ISocService socService { get; set; }

        [Parameter]
        public DataModel.FMV_Ram2TB Data { get; set; }
        List<PersonalTrabajadorTB> lEvaluators { get; set; } = new List<PersonalTrabajadorTB>();
        List<FMV_SocTB> lSoc { get; set; } = new List<FMV_SocTB>();

        bool Exit { get; set; } = false;
        bool OpenAddEditFarmaco { get; set; } = false;
        FMV_RamFarmacoTB Farmaco { get; set; } = null;

        bool OpenAddEditFarmacoRam { get; set; } = false;
        bool OpenAddEditFarmacoRamEval { get; set; } = false;
        FMV_RamFarmacoRamTB FarmacoRam { get; set; } = null;
        bool OpenAddEditConcominante { get; set; } = false;
        FMV_RamFarmacoConcominante FarmacoConcominante { get; set; } = null;

        [Inject]
        ITipoInstitucionService tipoInstitucionService { get; set; }
        [Inject]
        IProvicesService provicesService { get; set; }
        [Inject]
        IDestinyInstituteService destinyInstituteService { get; set; }

        List<TipoInstitucionTB> lTipoInstitucion { get; set; } = new List<TipoInstitucionTB>();
        List<ProvinciaTB> lProvincias { get; set; } = new List<ProvinciaTB>();
        List<InstitucionDestinoTB> lInstitucionDestino { get; set; } = new List<InstitucionDestinoTB>();

        bool openAttachment { get; set; } = false;
        AttachmentTB attachment { get; set; } = null;

        protected async override Task OnInitializedAsync()
        {

            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            base.OnInitialized();
        }

        //-----------------------RAM Rules--------------------------------

        #region RAM Rules

        private void UpgradeAll()
        {
            UpdateGrado0();
            UpdateIncongruenciaCondDosisEvo();
            UpdateIncongruenciaCondTerapiaEvo();
            UpdateIncongruenciaCondSuspTerapiaReex();
            UpdateIncongruenciaCondMantTerapiaReex();
            UpdateIncongruenciaConReex();
        }

        private void OnRamTypeChange(ChangeEventArgs args)
        {
            var value = args.Value.ToString();
            Data.RamType = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMType>(value);
            UpgradeAll();
        }
        private void UpdateGrado0()
        {   // Grado 0
            /* FÓRMULA: Si [farSosDCI]="", [hayRam]="", [fechaTratamiento]="" y [hayRam]="" entonces grado0=""
                         sino: Si [farSosDCI]!="", [hayRam]="Sí hay RAM" entonces
                                    Si [fechaTratamiento]="" o [hayRam]="" entonces grado0=Grado 0
                                    sino: grado0=""
            */
            //var value = string.Empty;
            //if (Data.RamType == enumFMV_RAMType.SiRam && Data.EvaluacionCalidadInfo.FechaTratamiento == null && Data.EvaluacionCalidadInfo.FechaRam == null)
            //    value = "Grado 0";
            //Data.Grado = value;
            string I5 = Data.RamType != enumFMV_RAMType.NoRam ? DataModel.Helper.Helper.GetDescription(Data.RamType) : "";
            string E5 = "";
            string W5 = "";
            string X5 = "";
            string Y5 = "";
            string Z5 = "";
            string AA5 = "";
            string AB5 = "";
            string AC5 = "";
            string AD5 = "";
            string AF5 = Data.Sexo!= enumSexo.NA? DataModel.Helper.Helper.GetDescription(Data.Sexo) : "";
            string AG5 = Data.Edad;
            string AJ5 = "";
            if (Data.LFarmacos != null)
            {
                foreach (var farm in Data.LFarmacos)
                {
                    E5 += farm.FarmacoSospechosoDci;
                    W5 += farm.FechaTratamiento?.ToString("dd/MM/yyyy")??"";
                    if (farm.LRams != null)
                    {
                        foreach (var ram in farm.LRams)
                        {
                            X5+=ram.FechaRam?.ToString("dd/MM/yyyy") ?? "";
                            Y5 += ram.Desenlace != enumFMV_RAMDesenlace.NA ? DataModel.Helper.Helper.GetDescription(ram.Desenlace) : "";
                            AC5 += ram.EvoDosis != enumFMV_RAMEvolucionDosis.NA ? DataModel.Helper.Helper.GetDescription(ram.EvoDosis) : "";
                            AD5 += ram.EvoTerapia != enumFMV_RAMEvolucionTerapia.NA ? DataModel.Helper.Helper.GetDescription(ram.EvoTerapia) : "";                            
                        }
                        Z5 += !string.IsNullOrEmpty(farm.Indicacion) ? farm.Indicacion : "";
                        AA5 += farm.ConductaDosis != enumFMV_RAMConductaDosis.NA ? DataModel.Helper.Helper.GetDescription(farm.ConductaDosis) : "";
                        AB5 += farm.ConductaTerapia != enumFMV_RAMConductaTerapia.NA ? DataModel.Helper.Helper.GetDescription(farm.ConductaTerapia) : "";
                        if (string.IsNullOrEmpty(AJ5) && farm.Reexposicion == enumOpcionSiNo.Si)
                        {
                            AJ5 = farm.Reexposicion == enumOpcionSiNo.Si || farm.Reexposicion == enumOpcionSiNo.No ? DataModel.Helper.Helper.GetDescription(farm.Reexposicion) : "";
                        }
                    }                    
                }
            }
            
            string grado0 = "";
            string grado1 = "";
            string grado2 = "";
            string grado3 = "";
            string grado4 = "";
            if (string.IsNullOrEmpty(I5)&& string.IsNullOrEmpty(E5) && string.IsNullOrEmpty(W5) && string.IsNullOrEmpty(X5))
            {
                grado0 = "";
            }
            else if(Data.RamType == enumFMV_RAMType.SiRam && !string.IsNullOrEmpty(E5))
            {
                grado0 = "";
                if ( string.IsNullOrEmpty(W5) || string.IsNullOrEmpty(X5))
                {
                    grado0 = "Grado 0"; 
                }
            }

            //grado1
            if (string.IsNullOrEmpty(I5) && string.IsNullOrEmpty(E5) && string.IsNullOrEmpty(W5) && string.IsNullOrEmpty(X5))
            {
                grado1 = "";
            }
            else if(!string.IsNullOrEmpty(Y5) && !string.IsNullOrEmpty(Z5) && !string.IsNullOrEmpty(AA5) && !string.IsNullOrEmpty(AB5))
            {
                grado1 = "";                
            }
            else if(I5 == DataModel.Helper.Helper.GetDescription(enumFMV_RAMType.SiRam) && !string.IsNullOrEmpty(E5) && !string.IsNullOrEmpty(W5) && !string.IsNullOrEmpty(X5))
            {
                grado1 = "Grado 1"; 
            }

            //grado2
            if (string.IsNullOrEmpty(I5) && string.IsNullOrEmpty(E5) && string.IsNullOrEmpty(W5) && string.IsNullOrEmpty(X5))
            {
                grado2 = "";
            }
            else if (!string.IsNullOrEmpty(AC5) && !string.IsNullOrEmpty(AD5) && !string.IsNullOrEmpty(AF5) && !string.IsNullOrEmpty(AG5))
            {
                grado2 = "";
            }
            else if (I5 == DataModel.Helper.Helper.GetDescription(enumFMV_RAMType.SiRam) && !string.IsNullOrEmpty(E5) && !string.IsNullOrEmpty(W5) && 
                !string.IsNullOrEmpty(X5) && !string.IsNullOrEmpty(Y5) && !string.IsNullOrEmpty(Z5) && !string.IsNullOrEmpty(AA5) && !string.IsNullOrEmpty(AB5))
            {
                grado2 = "Grado 2";
            }

            //grado3
            if (string.IsNullOrEmpty(I5) && string.IsNullOrEmpty(E5) && string.IsNullOrEmpty(W5) && string.IsNullOrEmpty(X5))
            {
                grado3 = "";
            }
            else if (AJ5 == DataModel.Helper.Helper.GetDescription(enumOpcionSiNo.Si))
            {
                grado3 = "";
            }
            else if (I5 == DataModel.Helper.Helper.GetDescription(enumFMV_RAMType.SiRam) && !string.IsNullOrEmpty(E5) && !string.IsNullOrEmpty(W5) &&
                !string.IsNullOrEmpty(X5) && !string.IsNullOrEmpty(Y5) && !string.IsNullOrEmpty(Z5) && !string.IsNullOrEmpty(AA5) && !string.IsNullOrEmpty(AB5)
                && !string.IsNullOrEmpty(AC5) && !string.IsNullOrEmpty(AD5) && !string.IsNullOrEmpty(AF5) && !string.IsNullOrEmpty(AG5))
            {
                grado3 = "Grado 3";
            }

            //grado4
            if (string.IsNullOrEmpty(I5) && string.IsNullOrEmpty(E5) && string.IsNullOrEmpty(W5) && string.IsNullOrEmpty(X5))
            {
                grado4 = "";
            }
            else if (I5 == DataModel.Helper.Helper.GetDescription(enumFMV_RAMType.SiRam) && !string.IsNullOrEmpty(E5) && !string.IsNullOrEmpty(W5) &&
                !string.IsNullOrEmpty(X5) && !string.IsNullOrEmpty(Y5) && !string.IsNullOrEmpty(Z5) && !string.IsNullOrEmpty(AA5) && !string.IsNullOrEmpty(AB5)
                && !string.IsNullOrEmpty(AC5) && !string.IsNullOrEmpty(AD5) && !string.IsNullOrEmpty(AF5) && !string.IsNullOrEmpty(AG5) && AJ5 == DataModel.Helper.Helper.GetDescription(enumOpcionSiNo.Si))
            {
                grado4 = "Grado 4";
            }

            Data.Grado = !string.IsNullOrEmpty(grado0)? grado0:(!string.IsNullOrEmpty(grado1) ? grado1 :(!string.IsNullOrEmpty(grado2) ? grado2 :(!string.IsNullOrEmpty(grado3) ? grado3 :(!string.IsNullOrEmpty(grado4) ? grado4 : "No Aplica"))));
           
        }

        private void UpdateIncongruenciaCondDosisEvo()
        {
            // Incongruencia Conducta_No Disminuyó Dosis /Evolución.
            /*
                FÓRMULA: Si [conductaDosis]="" y [evoDosis]="" entonces [incongruenciaCondDosisEvo]=""
                         sino: Si [conductaDosis]="No disminuyó la dosis" entonces
                                    Si [evoDosis]="Desapareció la reacción al disminuir la dosis" o [evoDosis]="Permanece la reacción al disminuir la dosis" entonces [incongruenciaCondDosisEvo]="Incongruente"
                                    sino entonces [incongruenciaCondDosisEvo]=""
            */
            var value = string.Empty;
            if (Data.LFarmacos.All(x => x.ConductaDosis == enumFMV_RAMConductaDosis.DISDOSIS))
            {
                value = "Falso";
            }
            else if (Data.LFarmacos.All(x => x.ConductaDosis == enumFMV_RAMConductaDosis.NODISDOSIS))
            {
                value = "Incongruente";
            }

            //if (Data.LFarmacos.All(x=>x.ConductaDosis == enumFMV_RAMConductaDosis.NODISDOSIS))
            //{
            //    if (Data.LFarmacos.All(x=>x.LRams.All(o=>o.EvoDosis == enumFMV_RAMEvolucionDosis.DESREACC)) ||
            //        Data.LFarmacos.All(x => x.LRams.All(o => o.EvoDosis == enumFMV_RAMEvolucionDosis.PERREACC)))
            //    {
            //        value = "Incongruente";
            //    }
            //}

            Data.ObservacionInfoNotifica.IncongruenciaCondDosisEvo = string.IsNullOrEmpty(value)? Data.ObservacionInfoNotifica.IncongruenciaCondDosisEvo:value;
        }
        private void UpdateIncongruenciaCondTerapiaEvo()
        {

            // Incongruencia Conducta_Mantuvo la Terapia/Evolución
            /*
                FÓRMULA: Si [conductaTerapia]="" y [evoTerapia]="" entonces [incongruenciaCondTerapiaEvo]=""
                         sino: Si [conductaTerapia]="Mantuvo la terapia" entonces
                                    Si [evoTerapia]="Desapareció la reacción al suspender el uso de medicamento sospechoso" o [evoTerapia]="Permanece la reacción al suspender el uso de medicamento sospechoso" entonces [incongruenciaCondTerapiaEvo]="Incongruente"
                                    sino entonces [incongruenciaCondTerapiaEvo]=""
            */

            
            var value = string.Empty;
            if (Data.LFarmacos.All(x => x.ConductaTerapia == enumFMV_RAMConductaTerapia.SUSTERAPIA))
            {
                value = "Falso";
            }
            else if (Data.LFarmacos.All(x => x.ConductaTerapia == enumFMV_RAMConductaTerapia.MANTERAPIA))
            {
                value = "Incongruente";
            }

            //if (Data.LFarmacos.All(x => x.ConductaTerapia == enumFMV_RAMConductaTerapia.MANTERAPIA))
            //{
            //    if (Data.LFarmacos.All(x => x.LRams.All(o => o.EvoTerapia == enumFMV_RAMEvolucionTerapia.DESREACC)) ||
            //        Data.LFarmacos.All(x => x.LRams.All(o => o.EvoTerapia == enumFMV_RAMEvolucionTerapia.PERREACC)))
            //    {
            //        value = "Incongruente";
            //    }
            //}

            Data.ObservacionInfoNotifica.IncongruenciaCondTerapiaEvo = string.IsNullOrEmpty(value) ? Data.ObservacionInfoNotifica.IncongruenciaCondTerapiaEvo : value;
        }
        private void UpdateIncongruenciaCondSuspTerapiaReex()
        {

            // Incongruencia Conducta_Suspendió la terapia/ REEX
            /*
                FÓRMULA: Si [conductaTerapia]="" y [reexposicion]="" entonces [incongruenciaCondSuspTerapiaReex]=""
                         sino: Si [conductaTerapia]="Suspendió la terapia" y [reexposicion]="Sí" entonces [incongruenciaCondSuspTerapiaReex]="Incongruente"
                               sino entonces [incongruenciaCondSuspTerapiaReex]=""
            */

            //var value = string.Empty;
            //if (Data.EvaluacionCalidadInfo.ConductaTerapia == enumFMV_RAMConductaTerapia.SUSTERAPIA && Data.EvaluacionCalidadInfo.Reexposicion == enumOpcionSiNo.Si)
            //    value = "Incongruente";
            var value = string.Empty;
            if (Data.LFarmacos.All(x => x.ConductaTerapia == enumFMV_RAMConductaTerapia.SUSTERAPIA) && Data.LFarmacos.All(x => x.Reexposicion == enumOpcionSiNo.Si))
            {
                value = "Incongruente";
            }
            else if (Data.LFarmacos.All(x => x.Reexposicion == enumOpcionSiNo.No))
            {
                Data.ObservacionInfoNotifica.IncongruenciaCondSuspTerapiaReex = "";
            }

            //if (Data.LFarmacos.All(x => x.ConductaTerapia == enumFMV_RAMConductaTerapia.SUSTERAPIA) && Data.LFarmacos.All(x => x.Reexposicion == enumOpcionSiNo.Si))
            //{
            //    value = "Incongruente";
            //}
            Data.ObservacionInfoNotifica.IncongruenciaCondSuspTerapiaReex = string.IsNullOrEmpty(value) ? Data.ObservacionInfoNotifica.IncongruenciaCondSuspTerapiaReex : value;
        }
        private void UpdateIncongruenciaCondMantTerapiaReex()
        {

            // Incongruencia Conducta_Mantuvo la terapia/ REEX
            /*
                FÓRMULA: Si [conductaTerapia]="" y [reexposicion]="" entonces [incongruenciaCondMantTerapiaReex]=""
                         sino: Si [conductaTerapia]="Mantuvo la terapia" y [reexposicion]="No" entonces [incongruenciaCondMantTerapiaReex]="Incongruente"
                               sino entonces [incongruenciaCondMantTerapiaReex]=""
            */

            //var value = string.Empty;
            //if (Data.EvaluacionCalidadInfo.ConductaTerapia == enumFMV_RAMConductaTerapia.MANTERAPIA && Data.EvaluacionCalidadInfo.Reexposicion == enumOpcionSiNo.No)
            //    value = "Incongruente";
            var value = string.Empty;
            if (Data.LFarmacos.All(x => x.ConductaTerapia == enumFMV_RAMConductaTerapia.MANTERAPIA) && Data.LFarmacos.All(x => x.Reexposicion == enumOpcionSiNo.No))
            {
                value = "Incongruente";
            }
            else if (Data.LFarmacos.All(x => x.ConductaTerapia == enumFMV_RAMConductaTerapia.SUSTERAPIA) && Data.LFarmacos.All(x => x.Reexposicion == enumOpcionSiNo.Si))
            {
                Data.ObservacionInfoNotifica.IncongruenciaCondMantTerapiaReex = "";
            }
            Data.ObservacionInfoNotifica.IncongruenciaCondMantTerapiaReex = string.IsNullOrEmpty(value) ? Data.ObservacionInfoNotifica.IncongruenciaCondMantTerapiaReex : value;
        }
        private void UpdateIncongruenciaConReex()
        {
            // Incongruencia Reexposición/Consecuencia de REEX
            /*
                FÓRMULA: Si [reexposicion]="" y [conReexposicion]="" entonces [incongruenciaConReex]=""
                         sino: Si [reexposicion]="No" entonces
                                    Si [conReexposicion]="Reapareció la reacción luego de reexposición" o [conReexposicion]="No reapareció la reacción luego de reexposición" entonces [incongruenciaConReex]="Incongruente"
                                    sino entonces [incongruenciaConReex]=""
            */

            //var value = string.Empty;
            //if (Data.EvaluacionCalidadInfo.Reexposicion == enumOpcionSiNo.No)
            //{
            //    if (Data.EvaluacionCalidadInfo.ConReexposicion == enumFMV_RAMConsecuenciaReexposicion.REAP || Data.EvaluacionCalidadInfo.ConReexposicion == enumFMV_RAMConsecuenciaReexposicion.NREAP)
            //        value = "Incongruente";
            //}
            var value = string.Empty;

            bool consecReex = false;
            foreach(var farm in Data.LFarmacos)
            {
                consecReex = farm.LRams.All(x=>x.ConReexposicion == enumFMV_RAMConsecuenciaReexposicion.REAP || x.ConReexposicion == enumFMV_RAMConsecuenciaReexposicion.NREAP);
                if (consecReex == false)
                    break;
            }
            bool reex = Data.LFarmacos.All(x=>x.Reexposicion== enumOpcionSiNo.No);
            if (consecReex && reex)
            {
                value = "Incongruente";
            }
            else {
                reex = Data.LFarmacos.All(x => x.Reexposicion == enumOpcionSiNo.Si);
                if (consecReex && reex)
                {
                    value = "Falso";
                }
            }
           
            Data.ObservacionInfoNotifica.IncongruenciaConReex = string.IsNullOrEmpty(value) ? Data.ObservacionInfoNotifica.IncongruenciaConReex : value;
        }


        #endregion

        //-----------------------RAM Rules--------------------------------

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await getUserLanguaje();
                await FetchData();
            }
        }

        //CHANGE LANGUAJE
        protected async Task getUserLanguaje(string? language = null)
        {
            language = string.IsNullOrEmpty(language) ? await profileService.GetLanguage() : language;
            languageContainerService.SetLanguage(System.Globalization.CultureInfo.GetCultureInfo(language));
            await this.InvokeAsync(StateHasChanged);
        }
        private void LanguageChangeEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<LanguageChangeEvent>();

            getUserLanguaje(message.Language);
        }

        //Fill Data
        protected async Task FetchData()
        {
            lSoc = lSoc != null && lSoc.Count > 0 ? lSoc : await socService.GetAll();
            lEvaluators = lEvaluators != null && lEvaluators.Count > 0 ? lEvaluators : await evaluatorService.GetAll();
            lTipoInstitucion = lTipoInstitucion != null && lTipoInstitucion.Count > 0 ? lTipoInstitucion : await tipoInstitucionService.GetAll();
            lProvincias = lProvincias != null && lProvincias.Count > 0 ? lProvincias : await provicesService.GetAll();

            lInstitucionDestino = await destinyInstituteService.FindAll(x => (Data.TipoInstitucionId != null ? x.TipoInstitucionId == Data.TipoInstitucionId : true) && (Data.ProvinciaId != null ? x.ProvinciaId == Data.ProvinciaId : true));

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            try 
            {
                UpgradeAll();

                //verificar CodigoCNFV
                if (!string.IsNullOrEmpty(Data.CodigoCNFV))
                {
                    var tmpData = (await ramService.FindAll(x => x.CodigoCNFV.Contains(Data.CodigoCNFV) && x.Id != Data.Id))?.FirstOrDefault();
                    if (tmpData != null)
                    {
                        await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["El código de CNFV ya existe"]);
                        return;
                    }
                }

                //verificar Cod Externo
                if (!string.IsNullOrEmpty(Data.CodExterno))
                {
                    var tmpData = (await ramService.FindAll(x => x.CodExterno.Contains(Data.CodExterno) && x.Id != Data.Id))?.FirstOrDefault();
                    if (tmpData != null)
                    {
                        await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["El código de Externo ya existe"]);
                        return;
                    }
                }

                //verificar Id Facedra
                if (!string.IsNullOrEmpty(Data.IdFacedra))
                {
                    var tmpData = (await ramService.FindAll(x => x.IdFacedra.Contains(Data.IdFacedra) && x.Id != Data.Id))?.FirstOrDefault();
                    if (tmpData != null)
                    {
                        await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["El código de ID Facedra ya existe"]);
                        return;
                    }
                }

                //verificar Codigo NotiFacedra
                if (!string.IsNullOrEmpty(Data.CodigoNotiFacedra))
                {
                    var tmpData = (await ramService.FindAll(x => x.CodigoNotiFacedra.Contains(Data.CodigoNotiFacedra) && x.Id != Data.Id))?.FirstOrDefault();
                    if (tmpData != null)
                    {
                        await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["El código de NotiFacedra ya existe"]);
                        return;
                    }
                }

                Data.FarmacosDesc = "";
                if (Data.LFarmacos?.Count() > 0)
                {
                    foreach (var dt in Data.LFarmacos)
                    {
                        Data.FarmacosDesc += string.Format("** {0} - {1} **", dt.FarmacoSospechosoDci, dt.FarmacoSospechosoComercial);
                        //Data.FarmacosDesc += string.Format("{0} - ", dt.FarmacoSospechosoDci);
                    }
                }

                var result = await ramService.Save(Data);
                if (result != null)
                {
                    await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                    Data = result;

                    if(Exit)
                        await bus.Publish(new Aig.FarmacoVigilancia.Events.Ram2.AddEdit_Event { Data = Data });                   
                }
                else
                    await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
            }
            catch { }
            finally { Exit = false; }
            
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.Ram2.AddEdit_Event { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }

        //Add New Farmaco
        protected async Task OpenFarmaco(FMV_RamFarmacoTB farmaco = null)
        {
            bus.Subscribe<Aig.FarmacoVigilancia.Events.RamFarmaco.AddEdit_Event>(Farmaco_AddEditEventHandlerHandler);

            Farmaco = farmaco != null ? farmaco : new FMV_RamFarmacoTB();
            OpenAddEditFarmaco = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //Remove Farmaco
        protected async Task RemoveFarmaco(FMV_RamFarmacoTB farmaco)
        {
            if (farmaco != null)
            {
                Data.LFarmacos.Remove(farmaco);


                UpgradeAll();
                this.InvokeAsync(StateHasChanged);
            }
        }
        //on close Farmaco MODAL 
        private void Farmaco_AddEditEventHandlerHandler(MessageArgs args)
        {
            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.RamFarmaco.AddEdit_Event>(Farmaco_AddEditEventHandlerHandler);

            var message = args.GetMessage<Aig.FarmacoVigilancia.Events.RamFarmaco.AddEdit_Event>();

            Farmaco = null;
            OpenAddEditFarmaco = false;
            if (message.Data != null)
            {
                Data.LFarmacos = Data.LFarmacos != null ? Data.LFarmacos : new List<FMV_RamFarmacoTB>();

                if (!Data.LFarmacos.Contains(message.Data))
                    Data.LFarmacos.Add(message.Data);
            }
            UpgradeAll();

            this.InvokeAsync(StateHasChanged);
        }


        //Add New FarmacoRam
        protected async Task OpenFarmacoRam(FMV_RamFarmacoRamTB farmacoRam = null)
        {
            if(Data.LFarmacos?.Count > 0)
            {
                bus.Subscribe<Aig.FarmacoVigilancia.Events.RamFarmacoRam.AddEdit_Event>(FarmacoRam_AddEditEventHandlerHandler);

                FarmacoRam = farmacoRam != null ? farmacoRam : new FMV_RamFarmacoRamTB();
                OpenAddEditFarmacoRam = true;

                await this.InvokeAsync(StateHasChanged);
            }
            else
            {
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["Debe agregar al menos un Fármaco Sospechoso"]);
            }
        }
        protected async Task OpenFarmacoRamEval(FMV_RamFarmacoRamTB farmacoRam = null)
        {
            bus.Subscribe<Aig.FarmacoVigilancia.Events.RamFarmacoRam.AddEdit_Event>(FarmacoRam_AddEditEventHandlerHandler);

            FarmacoRam = farmacoRam != null ? farmacoRam : new FMV_RamFarmacoRamTB();
            OpenAddEditFarmacoRamEval = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //Remove FarmacoRam
        protected async Task RemoveFarmacoRam(FMV_RamFarmacoRamTB farmacoRam)
        {
            if (farmacoRam != null)
            {
                var farmaco = (from f in Data.LFarmacos
                              where f.LRams.Contains(farmacoRam)
                              select f).FirstOrDefault();
                if(farmaco != null)
                {
                    farmaco.LRams.Remove(farmacoRam);
                }

                UpgradeAll();
                this.InvokeAsync(StateHasChanged);
            }
        }
        //on close FarmacoRam MODAL 
        private void FarmacoRam_AddEditEventHandlerHandler(MessageArgs args)
        {
            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.RamFarmacoRam.AddEdit_Event>(FarmacoRam_AddEditEventHandlerHandler);

            var message = args.GetMessage<Aig.FarmacoVigilancia.Events.RamFarmacoRam.AddEdit_Event>();

            FarmacoRam = null;
            OpenAddEditFarmaco = false;
            OpenAddEditFarmacoRamEval = false;

            if (message.Data != null)
            {
                var farmaco = (from f in Data.LFarmacos
                               where f.LRams.Contains(message.Data)
                               select f).FirstOrDefault();
                if (farmaco != null)
                {
                    farmaco.LRams.Remove(message.Data);
                }

                farmaco = Data.LFarmacos.Find(x => x == message.Data.Farmaco);
                if (farmaco != null)
                {
                    farmaco.LRams.Add(message.Data);
                }
            }
            

            UpgradeAll();

            this.InvokeAsync(StateHasChanged);
        }


        //Add New Concominante
        protected async Task OpenConcominante(FMV_RamFarmacoConcominante farmaco = null)
        {
            bus.Subscribe<Aig.FarmacoVigilancia.Events.RamConcominante.AddEdit_Event>(FarmacoConcominante_AddEditEventHandler);

            FarmacoConcominante = farmaco != null ? farmaco : new FMV_RamFarmacoConcominante();
            OpenAddEditConcominante = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //Remove Farmaco
        protected async Task RemoveConcominante(FMV_RamFarmacoConcominante farmaco)
        {
            if (farmaco != null)
            {
                Data.Concominantes.LProductos.Remove(farmaco);

                this.InvokeAsync(StateHasChanged);
            }
        }
        //on close Farmaco MODAL 
        private void FarmacoConcominante_AddEditEventHandler(MessageArgs args)
        {
            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.RamConcominante.AddEdit_Event>(FarmacoConcominante_AddEditEventHandler);

            var message = args.GetMessage<Aig.FarmacoVigilancia.Events.RamConcominante.AddEdit_Event>();

            FarmacoConcominante = null;
            OpenAddEditConcominante = false;
            if (message.Data != null)
            {
                Data.Concominantes = Data.Concominantes != null ? Data.Concominantes : new FMV_RamConcominantes();
                Data.Concominantes.LProductos = Data.Concominantes.LProductos != null ? Data.Concominantes.LProductos : new List<FMV_RamFarmacoConcominante>();

                if (!Data.Concominantes.LProductos.Contains(message.Data))
                    Data.Concominantes.LProductos.Add(message.Data);
            }

            this.InvokeAsync(StateHasChanged);
        }



        protected async Task OnEvaluatorChange(long? Id)
        {
            Data.EvaluadorId = Id;
            Data.Evaluador = lEvaluators.Where(x => x.Id == Id).FirstOrDefault();
        }

        protected async Task OnChangeTipoInstitucion(long? Id)
        {
            Data.TipoInstitucionId = Id;
            Data.TipoInstitucion = lTipoInstitucion.Where(x => x.Id == Id).FirstOrDefault();
            await FetchData();
        }

        protected async Task OnChangeProvincia(long? Id)
        {
            Data.ProvinciaId = Id;
            Data.Provincia = lProvincias.Where(x => x.Id == Id).FirstOrDefault();
            await FetchData();
        }


        //Add New Attachment
        protected async Task OpenAttachment(AttachmentTB _attachment = null)
        {
            bus.Subscribe<Aig.FarmacoVigilancia.Events.Attachments.AttachmentsAddEdit_CloseEvent>(AttachmentsAddEdit_CloseEventHandler);

            attachment = _attachment != null ? _attachment : new AttachmentTB();
            openAttachment = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //RemoveAttachment
        protected async Task RemoveAttachment(AttachmentTB attachment)
        {
            if (attachment != null)
            {
                try
                {
                    File.Delete(attachment.AbsolutePath);
                }
                catch { }

                Data.Adjunto.LAttachments.Remove(attachment);
                this.InvokeAsync(StateHasChanged);
            }
        }
        //ON CLOSE ATTACHMENT
        private void AttachmentsAddEdit_CloseEventHandler(MessageArgs args)
        {
            openAttachment = false;

            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.Attachments.AttachmentsAddEdit_CloseEvent>(AttachmentsAddEdit_CloseEventHandler);

            var message = args.GetMessage<Aig.FarmacoVigilancia.Events.Attachments.AttachmentsAddEdit_CloseEvent>();

            if (message.Attachment != null)
            {
                //message.Attachment.InspeccionId = Inspeccion.Id;
                Data.Adjunto = Data.Adjunto != null ? Data.Adjunto : new AttachmentData();
                Data.Adjunto.LAttachments = Data.Adjunto.LAttachments != null ? Data.Adjunto.LAttachments : new List<AttachmentTB>();

                Data.Adjunto.LAttachments.Add(message.Attachment);
            }

            this.InvokeAsync(StateHasChanged);
        }

    }

}

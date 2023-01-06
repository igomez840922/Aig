using Aig.FarmacoVigilancia.Nomenclators;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using DataModel.Helper;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;
using Aig.FarmacoVigilancia.Events.Language;

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

        bool OpenAddEditFarmaco { get; set; } = false;
        FMV_RamFarmacoTB Farmaco { get; set; } = null;

        bool OpenAddEditFarmacoRam { get; set; } = false;
        FMV_RamFarmacoRamTB FarmacoRam { get; set; } = null;

        [Inject]
        ITipoInstitucionService tipoInstitucionService { get; set; }
        [Inject]
        IProvicesService provicesService { get; set; }
        [Inject]
        IDestinyInstituteService destinyInstituteService { get; set; }

        List<TipoInstitucionTB> lTipoInstitucion { get; set; } = new List<TipoInstitucionTB>();
        List<ProvinciaTB> lProvincias { get; set; } = new List<ProvinciaTB>();
        List<InstitucionDestinoTB> lInstitucionDestino { get; set; } = new List<InstitucionDestinoTB>();

        protected async override Task OnInitializedAsync()
        {

            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            base.OnInitialized();
        }

        //-----------------------RAM Rules--------------------------------

        #region RAM Rules

        private void OnRamTypeChange(ChangeEventArgs args)
        {
            var value = args.Value.ToString();
            Data.RamType = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMType>(value);
            UpdateGrado0();
        }
        void OnFechaTratamientoChange(DateTime? value, string name, string format)
        {
            UpdateGrado0();
        }
        void OnRAMDateChange(DateTime? value, string name, string format)
        {
            UpdateGrado0();
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

            var value = string.Empty;
            if (Data.RamType == enumFMV_RAMType.SiRam && Data.LFarmacos.All(x=> x.FechaTratamiento == null) && Data.LFarmacos.All(x=>x.LRams.All(o=>o.FechaRam == null)))
                value = "Grado 0";
            Data.Grado = value;
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
            if (Data.LFarmacos.All(x=>x.ConductaDosis == enumFMV_RAMConductaDosis.NODISDOSIS))
            {
                if (Data.LFarmacos.All(x=>x.LRams.All(o=>o.EvoDosis == enumFMV_RAMEvolucionDosis.DESREACC)) ||
                    Data.LFarmacos.All(x => x.LRams.All(o => o.EvoDosis == enumFMV_RAMEvolucionDosis.PERREACC)))
                {
                    value = "Incongruente";
                }
            }
            Data.ObservacionInfoNotifica.IncongruenciaCondDosisEvo = value;
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

            //var value = string.Empty;
            //if (Data.EvaluacionCalidadInfo.ConductaTerapia == enumFMV_RAMConductaTerapia.MANTERAPIA)
            //{
            //    if (Data.EvaluacionCalidadInfo.EvoTerapia == enumFMV_RAMEvolucionTerapia.DESREACC ||
            //        Data.EvaluacionCalidadInfo.EvoTerapia == enumFMV_RAMEvolucionTerapia.PERREACC)
            //    {
            //        value = "Incongruente";
            //    }
            //}
            var value = string.Empty;
            if (Data.LFarmacos.All(x => x.ConductaTerapia == enumFMV_RAMConductaTerapia.MANTERAPIA))
            {
                if (Data.LFarmacos.All(x => x.LRams.All(o => o.EvoTerapia == enumFMV_RAMEvolucionTerapia.DESREACC)) ||
                    Data.LFarmacos.All(x => x.LRams.All(o => o.EvoTerapia == enumFMV_RAMEvolucionTerapia.PERREACC)))
                {
                    value = "Incongruente";
                }
            }

            Data.ObservacionInfoNotifica.IncongruenciaCondTerapiaEvo = value;
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
            Data.ObservacionInfoNotifica.IncongruenciaCondSuspTerapiaReex = value;
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
            Data.ObservacionInfoNotifica.IncongruenciaCondMantTerapiaReex = value;
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
            if ( Data.LFarmacos.All(x => x.Reexposicion == enumOpcionSiNo.No))
            {
                if(Data.LFarmacos.All(x => x.LRams.All(o=>o.ConReexposicion == enumFMV_RAMConsecuenciaReexposicion.REAP)) || Data.LFarmacos.All(x => x.LRams.All(o => o.ConReexposicion == enumFMV_RAMConsecuenciaReexposicion.NREAP)))
                value = "Incongruente";
            }
            Data.ObservacionInfoNotifica.IncongruenciaConReex = value;
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
            //verificar CodigoCNFV
            if (!string.IsNullOrEmpty(Data.CodigoCNFV))
            {
                var tmpData = (await ramService.FindAll(x => x.CodigoCNFV.Contains(Data.CodigoCNFV) && x.Id != Data.Id)).FirstOrDefault();
                if (tmpData != null)
                {
                    await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["El código de CNFV ya existe"]);
                    return;
                }
            }

            //verificar Cod Externo
            if (!string.IsNullOrEmpty(Data.CodExterno))
            {
                var tmpData = (await ramService.FindAll(x => x.CodExterno.Contains(Data.CodExterno) && x.Id != Data.Id)).FirstOrDefault();
                if (tmpData != null)
                {
                    await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["El código de Externo ya existe"]);
                    return;
                }
            }

            //verificar Id Facedra
            if (!string.IsNullOrEmpty(Data.IdFacedra))
            {
                var tmpData = (await ramService.FindAll(x => x.IdFacedra.Contains(Data.IdFacedra) && x.Id != Data.Id)).FirstOrDefault();
                if (tmpData != null)
                {
                    await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["El código de ID Facedra ya existe"]);
                    return;
                }
            }

            //verificar Codigo NotiFacedra
            if (!string.IsNullOrEmpty(Data.CodigoNotiFacedra))
            {
                var tmpData = (await ramService.FindAll(x => x.CodigoNotiFacedra.Contains(Data.CodigoNotiFacedra) && x.Id != Data.Id)).FirstOrDefault();
                if (tmpData != null)
                {
                    await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["El código de NotiFacedra ya existe"]);
                    return;
                }
            }

            var result = await ramService.Save(Data);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Data = result;

                await bus.Publish(new Aig.FarmacoVigilancia.Events.Ram2.AddEdit_Event { Data = Data });
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
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

            this.InvokeAsync(StateHasChanged);
        }


        //Add New FarmacoRam
        protected async Task OpenFarmacoRam(FMV_RamFarmacoRamTB farmacoRam = null)
        {
            bus.Subscribe<Aig.FarmacoVigilancia.Events.RamFarmacoRam.AddEdit_Event>(FarmacoRam_AddEditEventHandlerHandler);

            FarmacoRam = farmacoRam != null ? farmacoRam : new FMV_RamFarmacoRamTB();
            OpenAddEditFarmacoRam = true;

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

                this.InvokeAsync(StateHasChanged);
            }
        }
        //on close FarmacoRam MODAL 
        private void FarmacoRam_AddEditEventHandlerHandler(MessageArgs args)
        {
            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.RamFarmacoRam.AddEdit_Event>(FarmacoRam_AddEditEventHandlerHandler);

            var message = args.GetMessage<Aig.FarmacoVigilancia.Events.RamFarmacoRam.AddEdit_Event>();

            Farmaco = null;
            OpenAddEditFarmaco = false;
            //if (message.Data != null)
            //{
            //    Data.LFarmacos = Data.LFarmacos != null ? Data.LFarmacos : new List<FMV_RamFarmacoTB>();

            //    if (!Data.LFarmacos.Contains(message.Data))
            //        Data.LFarmacos.Add(message.Data);
            //}

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
    }

}

using Aig.FarmacoVigilancia.Components.Ram2;
using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.FarmacoVigilancia.Components.ESAVI2
{
    public partial class AddEdit
    {
        [Inject]
        IESAVI2Service esaviService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IWorkerPersonService evaluatorService { get; set; }
        [Inject]
        IPdfGenerationService pdfGenerationService { get; set; }
        [Inject]
        ITipoInstitucionService tipoInstitucionService { get; set; }
        [Inject]
        IProvicesService provicesService { get; set; }
        [Inject]
        IDestinyInstituteService destinyInstituteService { get; set; }
       

        [Parameter]
        public DataModel.FMV_Esavi2TB Data { get; set; }
        List<PersonalTrabajadorTB> lEvaluators { get; set; }
        List<TipoInstitucionTB> lTipoInstitucion { get; set; }
        List<ProvinciaTB> lProvincias { get; set; }
        List<InstitucionDestinoTB> lInstitucionDestino { get; set; }

        bool Exit { get; set; } = false;
        bool OpenAddEditFarmaco { get; set; } = false;
        FMV_EsaviVacunaTB Vacuna { get; set; } = null;
        bool OpenAddEditConcominante { get; set; } = false;
        FMV_RamFarmacoConcominante FarmacoConcominante { get; set; } = null;
        bool OpenAddEditFarmacoRam { get; set; } = false;
        bool OpenAddEditFarmacoRamEval { get; set; } = false;
        FMV_EsaviVacunaEsaviTB EsaviVacunaEsavi { get; set; } = null;
        
        bool openAttachment { get; set; } = false;
        AttachmentTB attachment { get; set; } = null;

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);

            base.OnInitialized();
        }

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
            lEvaluators = lEvaluators != null && lEvaluators.Count > 0 ? lEvaluators : await evaluatorService.GetAll();
            lTipoInstitucion = lTipoInstitucion != null && lTipoInstitucion.Count > 0 ? lTipoInstitucion : await tipoInstitucionService.GetAll();
            lProvincias = lProvincias != null && lProvincias.Count > 0 ? lProvincias : await provicesService.GetAll();
            
            lInstitucionDestino = await destinyInstituteService.FindAll(x => (Data.TipoInstitucionId != null ? x.TipoInstitucionId == Data.TipoInstitucionId : true) && (Data.ProvinciaId != null ? x.ProvinciaId == Data.ProvinciaId : true));
            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            try {
                if (!string.IsNullOrEmpty(Data.CodCNFV))
                {
                    var tmpData = (await esaviService.FindAll(x => x.CodCNFV.Contains(Data.CodCNFV) && x.Id != Data.Id)).FirstOrDefault();
                    if (tmpData != null)
                    {
                        await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["El código de CNFV ya existe"]);
                        return;
                    }
                }
                //verificar Cod Externo
                if (!string.IsNullOrEmpty(Data.CodExt))
                {
                    var tmpData = (await esaviService.FindAll(x => x.CodExt.Contains(Data.CodExt) && x.Id != Data.Id)).FirstOrDefault();
                    if (tmpData != null)
                    {
                        await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["El código Externo ya existe"]);
                        return;
                    }
                }
                //verificar Cod Externo
                if (!string.IsNullOrEmpty(Data.IdFacedra))
                {
                    var tmpData = (await esaviService.FindAll(x => x.IdFacedra.Contains(Data.IdFacedra) && x.Id != Data.Id)).FirstOrDefault();
                    if (tmpData != null)
                    {
                        await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["El ID Facedra ya existe"]);
                        return;
                    }
                }
                //verificar Cod Externo
                if (!string.IsNullOrEmpty(Data.CodigoNotiFacedra))
                {
                    var tmpData = (await esaviService.FindAll(x => x.CodigoNotiFacedra.Contains(Data.CodigoNotiFacedra) && x.Id != Data.Id)).FirstOrDefault();
                    if (tmpData != null)
                    {
                        await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["El código Noti-Facedra ya existe"]);
                        return;
                    }
                }

                Data.VacunasDesc = "";
                if(Data.LVacunas?.Count() > 0)
                {
                    foreach(var dt in Data.LVacunas)
                    {
                        Data.VacunasDesc += string.Format("** {0} - {1} **", dt.TipoVacuna?.Nombre??"",dt.VacunaComercial);
                        //Data.VacunasDesc += string.Format("{0} - ", dt.TipoVacuna?.Nombre ?? "");
                    }
                }

                var result = await esaviService.Save(Data);
                if (result != null)
                {
                    await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                    Data = result;

                    if(Exit)
                        await bus.Publish(new Aig.FarmacoVigilancia.Events.ESAVI2.AddEditEvent { Data = Data });
                }
                else
                    await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
            }
            catch { }
            finally { Exit = false; }
            //verificar CodigoCNFV
            
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.ESAVI2.AddEditEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
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


        /// <summary>
        /// ///////////////////////////////////
        /// </summary>
        /// 

        //Add New Farmaco
        protected async Task OpenFarmaco(FMV_EsaviVacunaTB vacuna = null)
        {
            bus.Subscribe<Aig.FarmacoVigilancia.Events.ESAVIVacuna.AddEditEvent>(Farmaco_AddEditEventHandlerHandler);

            Vacuna = vacuna != null ? vacuna : new FMV_EsaviVacunaTB();
            OpenAddEditFarmaco = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //Remove Farmaco
        protected async Task RemoveFarmaco(FMV_EsaviVacunaTB vacuna)
        {
            if (vacuna != null)
            {
                Data.LVacunas.Remove(vacuna);

                this.InvokeAsync(StateHasChanged);
            }
        }
        //on close Farmaco MODAL 
        private void Farmaco_AddEditEventHandlerHandler(MessageArgs args)
        {
            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.ESAVIVacuna.AddEditEvent>(Farmaco_AddEditEventHandlerHandler);

            var message = args.GetMessage<Aig.FarmacoVigilancia.Events.ESAVIVacuna.AddEditEvent>();

            Vacuna = null;
            OpenAddEditFarmaco = false;
            if (message.Data != null)
            {
                Data.LVacunas = Data.LVacunas != null ? Data.LVacunas : new List<FMV_EsaviVacunaTB>();

                if (!Data.LVacunas.Contains(message.Data))
                    Data.LVacunas.Add(message.Data);
            }

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


        //Add New FarmacoRam
        protected async Task OpenFarmacoRam(FMV_EsaviVacunaEsaviTB esaviVacunaEsavi = null)
        {
            if (Data.LVacunas?.Count > 0)
            {
                bus.Subscribe<Aig.FarmacoVigilancia.Events.ESAVIVacunaEsavi.AddEditEvent>(FarmacoRam_AddEditEventHandlerHandler);

                EsaviVacunaEsavi = esaviVacunaEsavi != null ? esaviVacunaEsavi : new FMV_EsaviVacunaEsaviTB();
                OpenAddEditFarmacoRam = true;

                await this.InvokeAsync(StateHasChanged);
            }
            else
            {
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["Debe agregar al menos una Vacuna Sospechosa"]);
            }
        }
        protected async Task OpenFarmacoRamEval(FMV_EsaviVacunaEsaviTB esaviVacunaEsavi = null)
        {
            bus.Subscribe<Aig.FarmacoVigilancia.Events.ESAVIVacunaEsavi.AddEditEvent>(FarmacoRam_AddEditEventHandlerHandler);

            EsaviVacunaEsavi = esaviVacunaEsavi != null ? esaviVacunaEsavi : new FMV_EsaviVacunaEsaviTB();
            OpenAddEditFarmacoRamEval = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //Remove FarmacoRam
        protected async Task RemoveFarmacoRam(FMV_EsaviVacunaEsaviTB esaviVacunaEsavi)
        {
            if (esaviVacunaEsavi != null)
            {
                var farmaco = (from f in Data.LVacunas
                               where f.LEsavis.Contains(esaviVacunaEsavi)
                               select f).FirstOrDefault();
                if (farmaco != null)
                {
                    farmaco.LEsavis.Remove(esaviVacunaEsavi);
                }

                this.InvokeAsync(StateHasChanged);
            }
        }
        //on close FarmacoRam MODAL 
        private void FarmacoRam_AddEditEventHandlerHandler(MessageArgs args)
        {
            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.ESAVIVacunaEsavi.AddEditEvent>(FarmacoRam_AddEditEventHandlerHandler);

            var message = args.GetMessage<Aig.FarmacoVigilancia.Events.ESAVIVacunaEsavi.AddEditEvent>();

            EsaviVacunaEsavi = null;
            OpenAddEditFarmaco = false;
            OpenAddEditFarmacoRamEval = false;

            if (message.Data != null)
            {
                Data.LVacunas = Data.LVacunas != null ? Data.LVacunas : new List<FMV_EsaviVacunaTB>();

                var farmaco = (from f in Data.LVacunas
                               where f.LEsavis.Contains(message.Data)
                               select f).FirstOrDefault();
                if (farmaco != null)
                {
                    farmaco.LEsavis.Remove(message.Data);
                }

                farmaco = Data.LVacunas.Find(x => x == message.Data.EsaviVacuna);
                if (farmaco != null)
                {
                    farmaco.LEsavis.Add(message.Data);
                }
            }

            this.InvokeAsync(StateHasChanged);
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

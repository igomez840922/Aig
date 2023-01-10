using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using DataModel;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace Aig.FarmacoVigilancia.Components.ESAVI
{
    public partial class AddEdit
    {        
        [Inject]
        IESAVIService esaviService { get; set; }
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
        [Inject]
        ISocService socService { get; set; }
        List<FMV_SocTB> lSoc { get; set; } = new List<FMV_SocTB>();
        [Inject]
        IIntensidadEsaviService intensidadEsaviService { get; set; }
        List<IntensidadEsaviTB> lintensidad { get; set; } = new List<IntensidadEsaviTB>();
        [Inject]
        ITipoVacunaService tipoVacunaService { get; set; }
        List<TipoVacunaTB> ltipoVacuna { get; set; } = new List<TipoVacunaTB>();
        [Inject]
        ILabsService labsService { get; set; }
        List<LaboratorioTB> lLaboratorios { get; set; } = new List<LaboratorioTB>();

        [Parameter]
        public DataModel.FMV_EsaviTB Data { get; set; }
        List<PersonalTrabajadorTB> lEvaluators { get; set; }
        List<TipoInstitucionTB> lTipoInstitucion { get; set; }
        List<ProvinciaTB> lProvincias { get; set; }
        List<InstitucionDestinoTB> lInstitucionDestino { get; set; }

        bool OpenAddEditNotification { get; set; } = false;
        FMV_EsaviNotificacionTB Notificacion { get; set; } = null;

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
            lTipoInstitucion = lTipoInstitucion!=null && lTipoInstitucion.Count > 0? lTipoInstitucion:await tipoInstitucionService.GetAll();
            lProvincias = lProvincias!=null && lProvincias.Count > 0? lProvincias: await provicesService.GetAll();
            lSoc = lSoc != null && lSoc.Count > 0 ? lSoc : await socService.GetAll();
            lintensidad = lintensidad != null && lintensidad.Count > 0 ? lintensidad : await intensidadEsaviService.GetAll();
            ltipoVacuna = ltipoVacuna != null && ltipoVacuna.Count > 0 ? ltipoVacuna : await tipoVacunaService.GetAll();
            lLaboratorios = lLaboratorios != null && lLaboratorios.Count > 0 ? lLaboratorios : await labsService.GetAll();

            lInstitucionDestino = await destinyInstituteService.FindAll(x => (Data.TipoInstitucionId != null ? x.TipoInstitucionId == Data.TipoInstitucionId : true) && (Data.ProvinciaId != null ? x.ProvinciaId == Data.ProvinciaId : true));
            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            //verificar CodigoCNFV
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

            var result = await esaviService.Save(Data);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Data = result;

                await bus.Publish(new Aig.FarmacoVigilancia.Events.ESAVI.AddEdit_CloseEvent { Data = Data });
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.ESAVI.AddEdit_CloseEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }

        ////Add New Product
        //protected async Task OpenProduct(FMV_EsaviNotificacionTB notificacion = null)
        //{
        //    bus.Subscribe<Aig.FarmacoVigilancia.Events.ESAVINotification.AddEdit_CloseEvent>(Notification_AddEditCloseEventHandlerHandler);

        //    Notificacion = notificacion != null ? notificacion : new FMV_EsaviNotificacionTB();
        //    OpenAddEditNotification = true;

        //    await this.InvokeAsync(StateHasChanged);
        //}
        ////Remove Product
        //protected async Task RemoveProduct(FMV_EsaviNotificacionTB notificacion)
        //{
        //    if (notificacion != null)
        //    {
        //        Data.LNotificaciones.Remove(notificacion);
        //        this.InvokeAsync(StateHasChanged);
        //    }
        //}
        ////ON CLOSE PRODUCT MODAL 
        //private void Notification_AddEditCloseEventHandlerHandler(MessageArgs args)
        //{
        //    bus.UnSubscribe<Aig.FarmacoVigilancia.Events.ESAVINotification.AddEdit_CloseEvent>(Notification_AddEditCloseEventHandlerHandler);

        //    var message = args.GetMessage<Aig.FarmacoVigilancia.Events.ESAVINotification.AddEdit_CloseEvent>();

        //    Notificacion = null;
        //    OpenAddEditNotification = false;
        //    if (message.Data != null)
        //    {
        //        Data.LNotificaciones = Data.LNotificaciones != null ? Data.LNotificaciones : new List<FMV_EsaviNotificacionTB>();

        //        if (!Data.LNotificaciones.Contains(message.Data))
        //            Data.LNotificaciones.Add(message.Data);
        //    }

        //    this.InvokeAsync(StateHasChanged);
        //}

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

        protected async Task OnSocChange(long? Id)
        {
            var soc = lSoc.Where(x => x.Id == Id).FirstOrDefault();

            Data.Soc = soc?.Nombre ?? "";

            //await FetchData();
        }
        protected async Task OnIntensidadChange(long? Id)
        {
            var dat = lintensidad.Where(x => x.Id == Id).FirstOrDefault();

            Data.IntensidadEsavi = dat;
            Data.Gravedad = dat?.Gravedad ?? "";

            CheckOtrosCritSeleccion();            
            //await FetchData();
        }
        protected async Task OnTipoVacunaChange(long? Id)
        {
            var dat = ltipoVacuna.Where(x => x.Id == Id).FirstOrDefault();

            Data.TipoVacuna = dat;

            //await FetchData();
        }
        protected async Task OnLaboratorioChange(long? Id)
        {
            var dat = lLaboratorios.Where(x => x.Id == Id).FirstOrDefault();

            Data.Laboratorio = dat;

            //await FetchData();
        }

        protected async Task CheckOtrosCritSeleccion()
        {
            Data.ElegibleEvaluacionCausal = "Regular";
            switch (Data.InvDetalleCaso)
            {
                case DataModel.Helper.enumOpcionSiNo.Si:
                    {
                        if(Data.Gravedad!=null && Data.Gravedad.Contains("Grave"))
                        {
                            Data.ElegibleEvaluacionCausal = "Prioridad";
                        }

                        switch (Data.OtrosCriterios)
                        {
                            case DataModel.Helper.enumFMV_EsaviOtroCriterio.NA:
                                {
                                    break;
                                }
                            default:
                                {
                                    Data.ElegibleEvaluacionCausal = "Prioridad";
                                    break;
                                }
                        }
                        break;
                    }
            }
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

using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using DataAccess;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.FarmacoVigilancia.Components.FF
{
    public partial class AddEdit
    {
        [Inject]
        IFFService ffService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IWorkerPersonService evaluatorService { get; set; }
        [Inject]
        IPdfGenerationService pdfGenerationService { get; set; }
        [Parameter]
        public DataModel.FMV_FfTB Data { get; set; }
        List<PersonalTrabajadorTB> lEvaluators { get; set; }

        [Inject]
        ITipoInstitucionService tipoInstitucionService { get; set; }
        [Inject]
        IProvicesService provicesService { get; set; }
        [Inject]
        IDestinyInstituteService destinyInstituteService { get; set; }
        [Inject]
        ILabsService labsService { get; set; }
        List<LaboratorioTB> Labs { get; set; } = new List<LaboratorioTB>();

        List<TipoInstitucionTB> lTipoInstitucion { get; set; }
        List<ProvinciaTB> lProvincias { get; set; }
        List<InstitucionDestinoTB> lInstitucionDestino { get; set; }

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
            Labs = Labs != null && Labs.Count > 0 ? Labs : await labsService.GetAll();

            lInstitucionDestino = await destinyInstituteService.FindAll(x => (Data.TipoInstitucionId != null ? x.TipoInstitucionId == Data.TipoInstitucionId : true) && (Data.ProvinciaId != null ? x.ProvinciaId == Data.ProvinciaId : true));

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            //verificar CodigoCNFV
            if (!string.IsNullOrEmpty(Data.CodCNFV))
            {
                var tmpData = (await ffService.FindAll(x => x.CodCNFV.Contains(Data.CodCNFV) && x.Id != Data.Id)).FirstOrDefault();
                if (tmpData != null)
                {
                    await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["El código de CNFV ya existe"]);
                    return;
                }
            }

            //verificar Cod Externo
            if (!string.IsNullOrEmpty(Data.CodExt))
            {
                var tmpData = (await ffService.FindAll(x => x.CodExt.Contains(Data.CodExt) && x.Id != Data.Id)).FirstOrDefault();
                if (tmpData != null)
                {
                    await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["El código Externo ya existe"]);
                    return;
                }
            }

            if (Data.RegSanitario != null && string.IsNullOrEmpty(Data.RegSanitario))
            {
                Data.RegSanitario = "Excepción al Registro Sanitario";
            }

            var result = await ffService.Save(Data);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Data = result;

                await bus.Publish(new Aig.FarmacoVigilancia.Events.FF.AddEdit_CloseEvent { Data = Data });
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.FF.AddEdit_CloseEvent { Data = null });
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

        //////////////////////
        ///

        public void OnAtcChanged()
        {
            Data.SubGrupoTerapeutico = "";
            Data.ATC = Data.ATC.Replace(" ", "");
            if (!string.IsNullOrEmpty(Data.ATC) && Data.ATC.Length >= 3)
                Data.SubGrupoTerapeutico = Helper.Helper.GetATC2doNivel(Data.ATC);
        }

    }

}

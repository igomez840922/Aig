using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Events.PMR;
using Aig.FarmacoVigilancia.Pages.Alert;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Mobsites.Blazor;
using System.Net.Mail;

namespace Aig.FarmacoVigilancia.Components.Pmr
{    
    public partial class AddEditPmr
    {
        [Inject]
        IPmrService pmrService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IWorkerPersonService evaluatorService { get; set; }
        [Inject]
        IPdfGenerationService pdfGenerationService { get; set; }

        [Inject]
        ILabsService labsService { get; set; }
        List<LaboratorioTB> lLaboratorio { get; set; } = new List<LaboratorioTB>();


        [Parameter]
        public DataModel.FMV_PmrTB Pmr { get; set; }
        List<PersonalTrabajadorTB> lEvaluators { get; set; } = new List<PersonalTrabajadorTB>();    

        bool OpenAddEditProduct { get; set; }=false;
        FMV_PmrProductoTB AddProduct { get; set; } = null;

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
            lLaboratorio = lLaboratorio!=null && lLaboratorio.Count > 0? lLaboratorio : await labsService.GetAll();
            lEvaluators = lEvaluators != null && lEvaluators.Count > 0 ? lEvaluators : await evaluatorService.GetAll();
           

            if (Pmr != null)
            {               
                if (Pmr.EvaluadorId == null)
                {
                    Pmr.EvaluadorId = lEvaluators?.FirstOrDefault()?.Id ?? null;
                    if (Pmr.EvaluadorId != null)
                    {
                        Pmr.Evaluador = lEvaluators.Where(x => x.Id == Pmr.EvaluadorId.Value).FirstOrDefault();
                    }
                }
            }

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            if (Pmr.EvaluadorId != null && Pmr.EvaluadorId > 0)
            {
                Pmr.Evaluador = await evaluatorService.Get(Pmr.EvaluadorId.Value);
            }
            if (Pmr.PmrProducto != null && string.IsNullOrEmpty(Pmr.PmrProducto.RegSanitario))
            {
                Pmr.PmrProducto.RegSanitario = "Excepción al Registro Sanitario";
            }

            var result = await pmrService.Save(Pmr);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Pmr = result;

                await bus.Publish(new PmrAddEdit_CloseEvent { Data = null });
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new PmrAddEdit_CloseEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }

        ////Add New Product
        //protected async Task OpenProduct(FMV_PmrProductoTB product = null)
        //{
            
        //    bus.Subscribe<Aig.FarmacoVigilancia.Events.PmrProduct.AddEdit_CloseEvent>(Product_AddEditCloseEventHandlerHandler);

        //    AddProduct = product != null ? product : new FMV_PmrProductoTB();
        //    OpenAddEditProduct = true;

        //    await bus.Publish(new Aig.FarmacoVigilancia.Events.PmrProduct.AddEdit_OpenEvent { Data = AddProduct });
        //    await this.InvokeAsync(StateHasChanged);
        //}
        ////Remove Product
        //protected async Task RemoveProduct(FMV_PmrProductoTB product)
        //{
        //    if (product != null)
        //    {
        //        Pmr.LProductos.Remove(product);
        //        this.InvokeAsync(StateHasChanged);
        //    }
        //}
        ////ON CLOSE PRODUCT MODAL 
        //private void Product_AddEditCloseEventHandlerHandler(MessageArgs args)
        //{
        //    bus.UnSubscribe<Aig.FarmacoVigilancia.Events.PmrProduct.AddEdit_CloseEvent>(Product_AddEditCloseEventHandlerHandler);

        //    var message = args.GetMessage<Aig.FarmacoVigilancia.Events.PmrProduct.AddEdit_CloseEvent>();

        //    AddProduct = null;
        //    OpenAddEditProduct = false;
        //    if (message.Data != null)
        //    {
        //        Pmr.LProductos = Pmr.LProductos != null ? Pmr.LProductos : new List<FMV_PmrProductoTB>();

        //        Pmr.LProductos.Add(message.Data);
        //    }

        //    this.InvokeAsync(StateHasChanged);
        //}
                
        protected async Task OnEvaluatorChange(long? Id)
        {
            Pmr.EvaluadorId = Id;
            Pmr.Evaluador = lEvaluators.Where(x => x.Id == Id).FirstOrDefault();
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

                Pmr.Adjunto.LAttachments.Remove(attachment);
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
                Pmr.Adjunto = Pmr.Adjunto != null ? Pmr.Adjunto : new AttachmentData();
                Pmr.Adjunto.LAttachments = Pmr.Adjunto.LAttachments != null ? Pmr.Adjunto.LAttachments : new List<AttachmentTB>();
                Pmr.Adjunto.LAttachments.Add(message.Attachment);
            }
            this.InvokeAsync(StateHasChanged);
        }
    }

}

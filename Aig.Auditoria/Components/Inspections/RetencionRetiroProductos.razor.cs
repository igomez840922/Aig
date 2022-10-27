using Aig.Auditoria.Events.Inspections;
using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Pages.Inspections;
using Aig.Auditoria.Services;
using BlazorComponentBus;
using DataModel;
using DataModel.Helper;
using Duende.IdentityServer.AspNetIdentity;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MimeKit.Utils;
using MimeKit;
using System;
using System.IO;
using Mobsites.Blazor;
using Org.BouncyCastle.Utilities;
using DocumentFormat.OpenXml.ExtendedProperties;
using Aig.Auditoria.Data;
using Aig.Auditoria.Pages.Settings.Corregimiento;

namespace Aig.Auditoria.Components.Inspections
{
    public partial class RetencionRetiroProductos
    {
        [Inject]
        IInspectionsService inspeccionService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IEstablishmentsService establecimientoService { get; set; } 
        [Inject]
        IPdfGenerationService pdfGenerationService { get; set; }
        [Parameter]
        public DataModel.AUD_InspeccionTB Inspeccion { get; set; }
        List<AUD_EstablecimientoTB> lEstablecimientos { get; set; }

        SignaturePad signaturePadDNFD;
        SignaturePad signaturePadESTAB;
        SignaturePad.SupportedSaveAsTypes signatureType { get; set; } = SignaturePad.SupportedSaveAsTypes.png;
        //string dataURL;

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
            if (lEstablecimientos == null || lEstablecimientos.Count < 1)
            {
                lEstablecimientos = await establecimientoService.GetAll();
            }

            if(Inspeccion!=null)
            {
                signaturePadDNFD.Image = Inspeccion.FirmaDNFD1;
                signaturePadESTAB.Image = Inspeccion.FirmaEstablec1;

                if (Inspeccion.EstablecimientoId == null)
                {
                    Inspeccion.EstablecimientoId = lEstablecimientos?.FirstOrDefault()?.Id ?? null;
                    if (Inspeccion.EstablecimientoId != null)
                    {
                        Inspeccion.UbicacionEstablecimiento = lEstablecimientos.Where(x => x.Id == Inspeccion.EstablecimientoId.Value).FirstOrDefault()?.Ubicacion ?? "";
                    }
                }
            }            
            
            await this.InvokeAsync(StateHasChanged);
        }
            
        //Save Data and Close
        protected async Task SaveData()
        {            
            if (Inspeccion.EstablecimientoId!=null && Inspeccion.EstablecimientoId > 0) {
                Inspeccion.Establecimiento = await establecimientoService.Get(Inspeccion.EstablecimientoId.Value);
            }

            var result = await inspeccionService.Save(Inspeccion);
            if (result != null)
            {                            
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Inspeccion = result;

                await bus.Publish(new Aig.Auditoria.Events.Inspections.AddEditCloseEvent { Inspeccion = null });
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.Auditoria.Events.Inspections.AddEditCloseEvent { Inspeccion=null });
            await this.InvokeAsync(StateHasChanged);
        }
        
        //Add New Product
        protected async Task OpenProduct(AUD_ProdRetiroRetencionTB product=null)
        {
            bus.Subscribe<Aig.Auditoria.Events.RetiredProduct.AddEditCloseEvent>(RetiredProduct_AddEditCloseEventHandler);

            product = product != null ? product : new AUD_ProdRetiroRetencionTB();

            await bus.Publish(new Aig.Auditoria.Events.RetiredProduct.AddEditOpenEvent { Product = product }); 
            await this.InvokeAsync(StateHasChanged);
        }
        //Remove Product
        protected async Task RemoveProduct(AUD_ProdRetiroRetencionTB product)
        {
            if (product != null)
            {
                Inspeccion.InspRetiroRetencion.LProductos.Remove(product);
                this.InvokeAsync(StateHasChanged);
            }
        }
        //ON CLOSE PRODUCT MODAL 
        private void RetiredProduct_AddEditCloseEventHandler(MessageArgs args)
        {
            bus.UnSubscribe<Aig.Auditoria.Events.RetiredProduct.AddEditCloseEvent>(RetiredProduct_AddEditCloseEventHandler);

            var message = args.GetMessage<Aig.Auditoria.Events.RetiredProduct.AddEditCloseEvent>();

            if(message.Product != null)
            {
                Inspeccion.InspRetiroRetencion.LProductos = Inspeccion.InspRetiroRetencion.LProductos != null ? Inspeccion.InspRetiroRetencion.LProductos : new List<AUD_ProdRetiroRetencionTB>();

                Inspeccion.InspRetiroRetencion.LProductos.Add(message.Product);
                this.InvokeAsync(StateHasChanged);
            }
        }
          
        //Add New Attachment
        protected async Task OpenAttachment(AttachmentTB attachment = null)
        {
            bus.Subscribe<Aig.Auditoria.Events.Attachments.AttachmentsAddEdit_CloseEvent>(AttachmentsAddEdit_CloseEventHandler);

            attachment = new AttachmentTB();

            await bus.Publish(new Aig.Auditoria.Events.Attachments.AttachmentsAddEdit_OpenEvent { Attachment = attachment });
            await this.InvokeAsync(StateHasChanged);
        }
        //RemoveAttachment
        protected async Task RemoveAttachment(AttachmentTB attachment)
        {
            if (attachment != null)
            {
                try {
                    File.Delete(attachment.AbsolutePath);
                }
                catch { }

                Inspeccion.LAttachments.Remove(attachment);
                this.InvokeAsync(StateHasChanged);
            }
        }
        //ON CLOSE ATTACHMENT
        private void AttachmentsAddEdit_CloseEventHandler(MessageArgs args)
        {
            bus.UnSubscribe<Aig.Auditoria.Events.Attachments.AttachmentsAddEdit_CloseEvent>(AttachmentsAddEdit_CloseEventHandler);

            var message = args.GetMessage<Aig.Auditoria.Events.Attachments.AttachmentsAddEdit_CloseEvent>();

            if (message.Attachment != null)
            {
                message.Attachment.InspeccionId = Inspeccion.Id;
                Inspeccion.LAttachments = Inspeccion.LAttachments != null ? Inspeccion.LAttachments : new List<AttachmentTB>();

                Inspeccion.LAttachments.Add(message.Attachment);
                this.InvokeAsync(StateHasChanged);
            }
        }

        //Firma
        protected async Task OnSignatureDNFDChange(ChangeEventArgs eventArgs)
        {
            Inspeccion.FirmaDNFD1 = null;
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.FirmaDNFD1 = await signaturePadDNFD.ToDataURL(signatureType);
        }
        protected async Task OnSignatureESTABChange(ChangeEventArgs eventArgs)
        {
            Inspeccion.FirmaEstablec1 = null;
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.FirmaEstablec1 = await signaturePadESTAB.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureDNFDImg()
        {
            signaturePadDNFD.Image = null;
        }
        protected async Task RemoveSignatureESTABImg()
        {
            signaturePadESTAB.Image = null;
        }

        protected async Task OnEstablishmentChange(long? Id)
        {
            Inspeccion.EstablecimientoId = Id;
            Inspeccion.UbicacionEstablecimiento = lEstablecimientos.Where(x => x.Id == Id).FirstOrDefault()?.Ubicacion ?? "";
        }


    }
}

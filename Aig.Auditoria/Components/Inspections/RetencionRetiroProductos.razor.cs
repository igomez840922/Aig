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
        public DataModel.AUD_InspeccionTB Inspeccion { get; set; } = null;
        List<AUD_EstablecimientoTB> lEstablecimientos { get; set; }
        enum_StatusInspecciones StatusInspecciones { get; set; } =  enum_StatusInspecciones.Pending;

        SignaturePad signaturePad1;
        SignaturePad signaturePad2;
        SignaturePad signaturePad3;
        SignaturePad signaturePad4;
        SignaturePad signaturePad5;
        SignaturePad signaturePad6;
        SignaturePad signaturePad7;
        SignaturePad signaturePad8;
        SignaturePad signaturePad9;
        SignaturePad signaturePad10;
        SignaturePad.SupportedSaveAsTypes signatureType { get; set; } = SignaturePad.SupportedSaveAsTypes.png;
        //string dataURL;
        bool showSignasure { get; set; } = false;

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
            StatusInspecciones = Inspeccion?.StatusInspecciones ?? enum_StatusInspecciones.Pending;

            if (lEstablecimientos == null || lEstablecimientos.Count < 1)
            {
                lEstablecimientos = await establecimientoService.GetAll();
            }

            if(Inspeccion!=null)
            {
                if (signaturePad1 != null)
                    signaturePad1.Image = Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector1;
                if (signaturePad2 != null)
                    signaturePad2.Image = Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector2;
                if (signaturePad3 != null)
                    signaturePad3.Image = Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector3;
                if (signaturePad4 != null)
                    signaturePad4.Image = Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector4;
                if (signaturePad5 != null)
                    signaturePad5.Image = Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector5;
                if (signaturePad6 != null)
                    signaturePad6.Image = Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector6;
                if (signaturePad7 != null)
                    signaturePad7.Image = Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector7;
                if (signaturePad8 != null)
                    signaturePad8.Image = Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector8;
                if (signaturePad9 != null)
                    signaturePad9.Image = Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaRepresentanteLegal;
                if (signaturePad10 != null)
                    signaturePad10.Image = Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaRegente;
                
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
        protected async Task OnSignatureChange1(ChangeEventArgs eventArgs)
        {
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector1 = null;
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector1 = await signaturePad1.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg1()
        {
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector1 = null;
            signaturePad1.Image = null;
        }
        protected async Task OnSignatureChange2(ChangeEventArgs eventArgs)
        {
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector2 = null;
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector2 = await signaturePad2.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg2()
        {
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector2 = null;
            signaturePad2.Image = null;
        }
        protected async Task OnSignatureChange3(ChangeEventArgs eventArgs)
        {
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector3 = null;
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector3 = await signaturePad3.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg3()
        {
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector3 = null;
            signaturePad3.Image = null;
        }
        protected async Task OnSignatureChange4(ChangeEventArgs eventArgs)
        {
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector4 = null;
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector4 = await signaturePad4.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg4()
        {
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector4 = null;
                signaturePad4.Image = null;
        }
        protected async Task OnSignatureChange5(ChangeEventArgs eventArgs)
        {
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector5 = null;
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector5 = await signaturePad5.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg5()
        {
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector5 = null;
            signaturePad5.Image = null;
        }
        protected async Task OnSignatureChange6(ChangeEventArgs eventArgs)
        {
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector6 = null;
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector6 = await signaturePad6.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg6()
        {
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector6 = null;
            signaturePad6.Image = null;
        }
        protected async Task OnSignatureChange7(ChangeEventArgs eventArgs)
        {
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector7 = null;
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector7 = await signaturePad7.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg7()
        {
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector7 = null;
            signaturePad7.Image = null;
        }
        protected async Task OnSignatureChange8(ChangeEventArgs eventArgs)
        {
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector8 = null;
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector8 = await signaturePad8.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg8()
        {
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaInspector8 = null;
            signaturePad8.Image = null;
        }
        protected async Task OnSignatureChange9(ChangeEventArgs eventArgs)
        {
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaRepresentanteLegal = null;
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaRepresentanteLegal = await signaturePad9.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg9()
        {
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaRepresentanteLegal = null;
            signaturePad9.Image = null;
        }
        protected async Task OnSignatureChange10(ChangeEventArgs eventArgs)
        {
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaRegente = null;
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaRegente = await signaturePad10.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg10()
        {
            Inspeccion.InspRetiroRetencion.DatosConclusiones.FirmaRegente = null;
            signaturePad10.Image = null;
        }

        protected async Task OnShowSignasure()
        {
            if (!showSignasure)
            {
                showSignasure = true;
                DelayToShowSignasure();
            }
        }
        async Task DelayToShowSignasure()
        {
            await Task.Delay(2000);
            await FetchData();
        }

        protected async Task OnEstablishmentChange(long? Id)
        {
            Inspeccion.EstablecimientoId = Id;
            Inspeccion.UbicacionEstablecimiento = lEstablecimientos.Where(x => x.Id == Id).FirstOrDefault()?.Ubicacion ?? "";
        }


    }
}

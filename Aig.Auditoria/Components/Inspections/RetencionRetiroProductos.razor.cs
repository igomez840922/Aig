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
        //List<AUD_EstablecimientoTB> lEstablecimientos { get; set; }
        //AUD_EstablecimientoTB selectedEstablecimiento
        //{
        //    get { return null; }
        //    set { Inspeccion.Establecimiento = value; }
        //}
        enum_StatusInspecciones StatusInspecciones { get; set; } =  enum_StatusInspecciones.Pending;

        
        SignaturePad signaturePad9;
        SignaturePad signaturePad10;
        SignaturePad.SupportedSaveAsTypes signatureType { get; set; } = SignaturePad.SupportedSaveAsTypes.png;
        //string dataURL;
        bool showSignasure { get; set; } = false;
        List<SignaturePad> lSignaturePads { get; set; } = new List<SignaturePad>();
        SignaturePad signaturePad {
            get { return null; } 
            set { lSignaturePads.Add(value);} 
        }

        bool showParticipant { get; set; } = false;
        Participante participante { get; set; } = null;

        bool showSearchEstablishment { get; set; } = false;

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
                StatusInspecciones = Inspeccion?.StatusInspecciones ?? enum_StatusInspecciones.Pending;
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
            
            //if (lEstablecimientos == null || lEstablecimientos.Count < 1)
            //{
            //    lEstablecimientos = await establecimientoService.GetAll();
            //}

            if(Inspeccion!=null)
            {
                if (signaturePad9 != null)
                    signaturePad9.Image = Inspeccion.InspRetiroRetencion.DatosAtendidosPor.Firma;
                if (signaturePad10 != null)
                    signaturePad10.Image = Inspeccion.InspRetiroRetencion.DatosRegente.Firma;


                foreach (var partic in Inspeccion.InspRetiroRetencion.DatosConclusiones.LParticipantes)
                {
                    try {
                        lSignaturePads[Inspeccion.InspRetiroRetencion.DatosConclusiones.LParticipantes.IndexOf(partic)].Image = partic.Firma;
                    }
                    catch (Exception ex) { }
                }               

                //if (Inspeccion.EstablecimientoId == null)
                //{
                //    Inspeccion.EstablecimientoId = lEstablecimientos?.FirstOrDefault()?.Id ?? null;
                //    if (Inspeccion.EstablecimientoId != null)
                //    {
                //        Inspeccion.UbicacionEstablecimiento = lEstablecimientos.Where(x => x.Id == Inspeccion.EstablecimientoId.Value).FirstOrDefault()?.Ubicacion ?? "";
                //    }
                //}
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

                if(!Inspeccion.InspRetiroRetencion.LProductos.Contains(message.Product))
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

        //ADD PARTICIPANTE
        protected async Task OpenParticipant(Participante _participante=null)
        {
            bus.Subscribe<Aig.Auditoria.Events.Participants.ParticipantsAddEdit_CloseEvent>(ParticipantsAddEdit_CloseEventHandler);

            participante= _participante!=null? _participante: new Participante();
            showParticipant = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //RemoveAttachment
        protected async Task RemoveParticipant(Participante _participante)
        {
            if (_participante != null)
            {
                try
                {
                    Inspeccion.InspRetiroRetencion.DatosConclusiones.LParticipantes.Remove(_participante);
                }
                catch { }

                this.InvokeAsync(StateHasChanged);
            }
        }
        //ON CLOSE ATTACHMENT
        private void ParticipantsAddEdit_CloseEventHandler(MessageArgs args)
        {
            showSignasure = false;
            showParticipant = false;

            bus.UnSubscribe<Aig.Auditoria.Events.Participants.ParticipantsAddEdit_CloseEvent>(ParticipantsAddEdit_CloseEventHandler);

            var message = args.GetMessage<Aig.Auditoria.Events.Participants.ParticipantsAddEdit_CloseEvent>();

            if (message.Data != null)
            {
                if (!Inspeccion.InspRetiroRetencion.DatosConclusiones.LParticipantes.Contains(message.Data))
                    Inspeccion.InspRetiroRetencion.DatosConclusiones.LParticipantes.Add(message.Data);
            }

            this.InvokeAsync(StateHasChanged);
        }
        

        //Firma
        protected async Task OnSignatureChange9(ChangeEventArgs eventArgs)
        {
            await RemoveSignatureImg9();
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspRetiroRetencion.DatosAtendidosPor.Firma = await signaturePad9.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg9()
        {
            Inspeccion.InspRetiroRetencion.DatosAtendidosPor.Firma = null;
            signaturePad9.Image = null;
        }
        protected async Task OnSignatureChange10(ChangeEventArgs eventArgs)
        {
            await RemoveSignatureImg10();
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspRetiroRetencion.DatosRegente.Firma = await signaturePad10.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg10()
        {
            Inspeccion.InspRetiroRetencion.DatosRegente.Firma = null;
            signaturePad10.Image = null;
        }


        protected async Task OnShowSignasure()
        {
            if (!showSignasure && Inspeccion.InspRetiroRetencion.DatosConclusiones.LParticipantes.Count > 0)
            {
                lSignaturePads.Clear();
                showSignasure = true;
                DelayToShowSignasure();
            }
            //await this.InvokeAsync(StateHasChanged);
        }
        async Task DelayToShowSignasure()
        {
            await Task.Delay(2000);
            await FetchData();
        }

        //protected async Task OnEstablishmentChange(long? Id)
        //{
        //    Inspeccion.EstablecimientoId = Id;
        //    Inspeccion.UbicacionEstablecimiento = lEstablecimientos.Where(x => x.Id == Id).FirstOrDefault()?.Ubicacion ?? "";
        //    Inspeccion.Establecimiento = lEstablecimientos.Find(x => x.Id == Id);
        //}

        ////////
        ///        
        protected async Task OnSignatureChange(Participante _participante)
        {
            await RemoveSignatureImg(_participante);
            var _signaturePad = lSignaturePads[Inspeccion.InspRetiroRetencion.DatosConclusiones.LParticipantes.IndexOf(_participante)];
            _participante.Firma = await _signaturePad.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg(Participante _participante)
        {
            _participante.Firma = null;
            var _signaturePad = lSignaturePads[Inspeccion.InspRetiroRetencion.DatosConclusiones.LParticipantes.IndexOf(_participante)];
            _signaturePad.Image = null;
        }


        /////////
        ///
        
        protected async Task OpenSearchEstablishment()
        {
            bus.Subscribe<Aig.Auditoria.Events.Establishments.SearchEvent>(Establishments_SearchEventHandler);

            showSearchEstablishment = true;

            await this.InvokeAsync(StateHasChanged);
        }
        private void Establishments_SearchEventHandler(MessageArgs args)
        {
            showSearchEstablishment = false;

            bus.UnSubscribe<Aig.Auditoria.Events.Establishments.SearchEvent>(Establishments_SearchEventHandler);

            var message = args.GetMessage<Aig.Auditoria.Events.Establishments.SearchEvent>();

            if (message.Data != null)
            {
                Inspeccion.EstablecimientoId = message.Data.Id;
                Inspeccion.Establecimiento = message.Data;
                Inspeccion.UbicacionEstablecimiento = message.Data.Ubicacion;
            }

            this.InvokeAsync(StateHasChanged);
        }


    }
}

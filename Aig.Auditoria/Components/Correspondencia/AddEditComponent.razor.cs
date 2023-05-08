using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Pages.Inspections;
using Aig.Auditoria.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using Castle.Core;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Mobsites.Blazor;
using System.Net.Mail;

namespace Aig.Auditoria.Components.Correspondencia
{   
    public partial class AddEditComponent
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        ICorrespondenciaService correspondenciaService { get; set; }
        [Inject]
        AuthenticationStateProvider authenticationStateAsync { get; set; }
        [Inject]
        ICorrespondenciaAsuntoService correspondenciaAsuntoService { get; set; }
        List<AUD_CorrespondenciaAsuntoTB> LAsuntos { get; set; } = new List<AUD_CorrespondenciaAsuntoTB>();
        [Inject]
        ICorrespondenciaContactoService correspondenciaContactoService { get; set; }
        List<AUD_CorrespondenciaContactoTB> LContacto { get; set; } = new List<AUD_CorrespondenciaContactoTB>();
        [Inject]
        ICorrespondenciaRespRevisionService correspondenciaRespRevisionService { get; set; }
        List<AUD_CorrespondenciaRespRevisionTB> LResponsables { get; set; } = new List<AUD_CorrespondenciaRespRevisionTB>();


        bool OpenDialog { get; set; }
        [Parameter]
        public DataModel.AUD_CorrespondenciaTB Correspondencia { get; set; } = null;

        Mobsites.Blazor.SignaturePad SignaturePad5;
        Mobsites.Blazor.SignaturePad.SupportedSaveAsTypes signatureType { get; set; } = Mobsites.Blazor.SignaturePad.SupportedSaveAsTypes.png;

        System.Security.Claims.ClaimsPrincipal userClaims { get; set; } = null;

        bool disabledDatosIngresos { get; set; } = false;
        bool disabledDatosRevision { get; set; } = false;
        bool disabledDatosRecepcion { get; set; } = false;
        bool disabledDatosSeguimiento { get; set; } = false;
        bool disabledDatosEstablecimientos { get; set; } = false;

        bool showSearchEstablishment { get; set; } = false;

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
            LContacto = LContacto?.Count > 0 ? LContacto : await correspondenciaContactoService.GetAll();
            LAsuntos = LAsuntos?.Count > 0 ? LAsuntos : await correspondenciaAsuntoService.GetAll();
            LResponsables = LResponsables?.Count > 0 ? LResponsables : await correspondenciaRespRevisionService.GetAll();

            OpenDialog = true;
            Correspondencia = Correspondencia != null ? Correspondencia : new DataModel.AUD_CorrespondenciaTB();

            var authstate = await authenticationStateAsync.GetAuthenticationStateAsync();
            userClaims = authstate.User;

            disabledDatosIngresos = ((userClaims?.IsInRole(DataModel.Helper.Helper.GetDescription(DataModel.enumUserRoleType.JefSecAudit)) ?? false) ||
                                        (userClaims?.IsInRole(DataModel.Helper.Helper.GetDescription(DataModel.enumUserRoleType.JefSecInspec)) ?? false) ||
                                           (userClaims?.IsInRole(DataModel.Helper.Helper.GetDescription(DataModel.enumUserRoleType.JefSecLic)) ?? false) ||
                                           (userClaims?.IsInRole(DataModel.Helper.Helper.GetDescription(DataModel.enumUserRoleType.EvaInsMP)) ?? false)
                                            );

            disabledDatosRevision = ((userClaims?.IsInRole(DataModel.Helper.Helper.GetDescription(DataModel.enumUserRoleType.SecDepAudit)) ?? false) ||
                                       (userClaims?.IsInRole(DataModel.Helper.Helper.GetDescription(DataModel.enumUserRoleType.SecSecLic)) ?? false) ||
                                          (userClaims?.IsInRole(DataModel.Helper.Helper.GetDescription(DataModel.enumUserRoleType.JefSecAudit)) ?? false) ||
                                          (userClaims?.IsInRole(DataModel.Helper.Helper.GetDescription(DataModel.enumUserRoleType.JefSecInspec)) ?? false) ||
                                          (userClaims?.IsInRole(DataModel.Helper.Helper.GetDescription(DataModel.enumUserRoleType.JefSecLic)) ?? false) ||
                                          (userClaims?.IsInRole(DataModel.Helper.Helper.GetDescription(DataModel.enumUserRoleType.EvaInsMP)) ?? false) 
                                           );

            disabledDatosRecepcion = ((userClaims?.IsInRole(DataModel.Helper.Helper.GetDescription(DataModel.enumUserRoleType.SecDepAudit)) ?? false) ||
                                       (userClaims?.IsInRole(DataModel.Helper.Helper.GetDescription(DataModel.enumUserRoleType.SecSecLic)) ?? false) ||
                                          (userClaims?.IsInRole(DataModel.Helper.Helper.GetDescription(DataModel.enumUserRoleType.JefSecAudit)) ?? false) ||
                                          (userClaims?.IsInRole(DataModel.Helper.Helper.GetDescription(DataModel.enumUserRoleType.JefSecInspec)) ?? false) ||
                                          (userClaims?.IsInRole(DataModel.Helper.Helper.GetDescription(DataModel.enumUserRoleType.JefSecLic)) ?? false) ||
                                          (userClaims?.IsInRole(DataModel.Helper.Helper.GetDescription(DataModel.enumUserRoleType.EvaInsMP)) ?? false)
                                           );

            disabledDatosEstablecimientos = ((userClaims?.IsInRole(DataModel.Helper.Helper.GetDescription(DataModel.enumUserRoleType.SecDepAudit)) ?? false) ||
                                        (userClaims?.IsInRole(DataModel.Helper.Helper.GetDescription(DataModel.enumUserRoleType.SecSecLic)) ?? false));

            
            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task SaveData()
        {
            switch (Correspondencia.DptoSeccionType)
            {
                case enumUserRoleType.None: { break; }
                default:
                    {
                        Correspondencia.DptoSeccion = DataModel.Helper.Helper.GetDescription(Correspondencia.DptoSeccionType);
                        break;
                    }
            }

            if(Correspondencia.TipoCorrespondencia!= DataModel.Helper.enumAUD_TipoCorrespondencia.Otros)
            {
                Correspondencia.DescTipoCorrespondencia = DataModel.Helper.Helper.GetDescription(Correspondencia.TipoCorrespondencia);
            }
            if (Correspondencia.CorrespondenciaAsuntoId != null)
            {
                Correspondencia.CorrespondenciaAsunto = LAsuntos.Where(x => x.Id == Correspondencia.CorrespondenciaAsuntoId)?.FirstOrDefault();
                Correspondencia.Asunto = Correspondencia.CorrespondenciaAsunto?.Nombre;               
            }
            if(Correspondencia.CorrespondenciaContactoId != null)
            {
                Correspondencia.CorrespondenciaContacto = LContacto.Where(x => x.Id == Correspondencia.CorrespondenciaContactoId)?.FirstOrDefault();
                Correspondencia.NombreDirigido = Correspondencia.CorrespondenciaContacto?.Nombre;
                Correspondencia.EmailDirigido = Correspondencia.CorrespondenciaContacto?.Email;
            }
            if (Correspondencia.CorrespondenciaResponsableId != null)
            {
                Correspondencia.CorrespondenciaResponsable = LResponsables.Where(x => x.Id == Correspondencia.CorrespondenciaResponsableId)?.FirstOrDefault();
                Correspondencia.NombreRevision = string.Format("{0} - {1}", Correspondencia.CorrespondenciaResponsable?.Nombre, Correspondencia.CorrespondenciaResponsable?.Cargo);
            }

            var result = await correspondenciaService.Save(Correspondencia);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                OpenDialog = false;
                Correspondencia = result;
                await bus.Publish(new Aig.Auditoria.Events.Correspondencia.AddEditEvent { Data = Correspondencia });
                bus.UnSubscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
                await this.InvokeAsync(StateHasChanged);
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);                        
        }

        protected async Task Cancel()
        {
            //bus.UnSubscribe<Aig.Auditoria.Events.OpenHours.OpenHoursAddEdit_OpenEvent>(AddEditOpenEventHandler);
            OpenDialog = false;
            await bus.Publish(new Aig.Auditoria.Events.Correspondencia.AddEditEvent { Data = null });
            bus.UnSubscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            await this.InvokeAsync(StateHasChanged);
        }



        //protected async Task OnSignatureload()
        //{
        //    await Task.Delay(2000);
        //    if (SignaturePad5 != null)
        //        SignaturePad5.Image = Correspondencia.FirmaRecibido;
        //    await this.InvokeAsync(StateHasChanged);
        //}
        //protected async Task OnSignatureChange5(ChangeEventArgs eventArgs)
        //{
        //    RemoveSignatureImg5();
        //    if (eventArgs?.Value != null)
        //    {
        //        var signatureType = (Mobsites.Blazor.SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(Mobsites.Blazor.SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
        //    }
        //    Correspondencia.FirmaRecibido = await SignaturePad5.ToDataURL(signatureType);
        //}
        //protected async Task RemoveSignatureImg5()
        //{
        //    Correspondencia.FirmaRecibido = null;
        //    SignaturePad5.Image = null;
        //}

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
                Correspondencia.EstablecimientoNombre = message.Data.Nombre;
                Correspondencia.EstablecimientoNumLic = message.Data.NumLicencia;
                Correspondencia.EstablecimientoUbicacion = message.Data.Ubicacion;
                Correspondencia.EstablecimientoCorregimiento = message.Data.Corregimiento?.Nombre??"";
            }

            this.InvokeAsync(StateHasChanged);
        }


        //Add New Attachment
        protected async Task OpenAttachment(AttachmentTB _attachment = null)
        {
            bus.Subscribe<Aig.Auditoria.Events.Attachments.AttachmentsAddEdit_CloseEvent>(AttachmentsAddEdit_CloseEventHandler);

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

                Correspondencia.AdjuntoIngreso.LAttachments.Remove(attachment);
                this.InvokeAsync(StateHasChanged);
            }
        }
        //ON CLOSE ATTACHMENT
        private void AttachmentsAddEdit_CloseEventHandler(MessageArgs args)
        {
            openAttachment = false;

            bus.UnSubscribe<Aig.Auditoria.Events.Attachments.AttachmentsAddEdit_CloseEvent>(AttachmentsAddEdit_CloseEventHandler);

            var message = args.GetMessage<Aig.Auditoria.Events.Attachments.AttachmentsAddEdit_CloseEvent>();

            if (message.Attachment != null)
            {
                //message.Attachment.InspeccionId = Inspeccion.Id;
                Correspondencia.AdjuntoIngreso = Correspondencia.AdjuntoIngreso != null ? Correspondencia.AdjuntoIngreso : new AttachmentData();
                Correspondencia.AdjuntoIngreso.LAttachments = Correspondencia.AdjuntoIngreso.LAttachments != null ? Correspondencia.AdjuntoIngreso.LAttachments : new List<AttachmentTB>();

                Correspondencia.AdjuntoIngreso.LAttachments.Add(message.Attachment);
            }

            this.InvokeAsync(StateHasChanged);
        }

        //Add New Attachment2
        protected async Task OpenAttachment2(AttachmentTB _attachment = null)
        {
            bus.Subscribe<Aig.Auditoria.Events.Attachments.AttachmentsAddEdit_CloseEvent>(AttachmentsAddEdit_CloseEventHandler2);

            attachment = _attachment != null ? _attachment : new AttachmentTB();
            openAttachment = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //RemoveAttachment
        protected async Task RemoveAttachment2(AttachmentTB attachment)
        {
            if (attachment != null)
            {
                try
                {
                    File.Delete(attachment.AbsolutePath);
                }
                catch { }

                Correspondencia.AdjuntoSeguimiento.LAttachments.Remove(attachment);
                this.InvokeAsync(StateHasChanged);
            }
        }
        //ON CLOSE ATTACHMENT
        private void AttachmentsAddEdit_CloseEventHandler2(MessageArgs args)
        {
            openAttachment = false;

            bus.UnSubscribe<Aig.Auditoria.Events.Attachments.AttachmentsAddEdit_CloseEvent>(AttachmentsAddEdit_CloseEventHandler);

            var message = args.GetMessage<Aig.Auditoria.Events.Attachments.AttachmentsAddEdit_CloseEvent>();

            if (message.Attachment != null)
            {
                //message.Attachment.InspeccionId = Inspeccion.Id;
                Correspondencia.AdjuntoSeguimiento = Correspondencia.AdjuntoSeguimiento != null ? Correspondencia.AdjuntoSeguimiento : new AttachmentData();
                Correspondencia.AdjuntoSeguimiento.LAttachments = Correspondencia.AdjuntoSeguimiento.LAttachments != null ? Correspondencia.AdjuntoSeguimiento.LAttachments : new List<AttachmentTB>();

                Correspondencia.AdjuntoSeguimiento.LAttachments.Add(message.Attachment);
            }

            this.InvokeAsync(StateHasChanged);
        }

    }

}

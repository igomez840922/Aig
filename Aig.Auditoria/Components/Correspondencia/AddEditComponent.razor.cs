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

        bool OpenDialog { get; set; }
        [Parameter]
        public DataModel.AUD_CorrespondenciaTB Correspondencia { get; set; } = null;

        SignaturePad signaturePad5;
        SignaturePad.SupportedSaveAsTypes signatureType { get; set; } = SignaturePad.SupportedSaveAsTypes.png;

        System.Security.Claims.ClaimsPrincipal userClaims { get; set; } = null;

        bool disabledDatosIngresos { get; set; } = false;
        bool disabledDatosRevision { get; set; } = false;
        bool disabledDatosRecepcion { get; set; } = false;
        bool disabledDatosSeguimiento { get; set; } = false;


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

            //OnSignatureload();

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
        //    if (signaturePad5 != null)
        //        signaturePad5.Image = Correspondencia.FirmaRecibido;
        //    await this.InvokeAsync(StateHasChanged);
        //}
        //protected async Task OnSignatureChange5(ChangeEventArgs eventArgs)
        //{
        //    RemoveSignatureImg5();
        //    if (eventArgs?.Value != null)
        //    {
        //        var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
        //    }
        //    Correspondencia.FirmaRecibido = await signaturePad5.ToDataURL(signatureType);
        //}
        //protected async Task RemoveSignatureImg5()
        //{
        //    Correspondencia.FirmaRecibido = null;
        //    signaturePad5.Image = null;
        //}

    }

}

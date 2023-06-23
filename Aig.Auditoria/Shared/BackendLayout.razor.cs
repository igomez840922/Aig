using Aig.Auditoria.Events;
using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel;
using DataModel.Models;
using Duende.IdentityServer.AspNetIdentity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.JSInterop;
using System;

namespace Aig.Auditoria.Shared
{
    public partial class BackendLayout
    {
        [Inject]
        IAuthService authService { get; set; }
        [Inject]
        UserManager<ApplicationUser> userManager { get; set; }

        [Inject]
        IProfileService profileService { get; set; }

        #region Variables

        [CascadingParameter]
        protected Task<AuthenticationState> authStat { get; set; }

        protected string currentLanguage { get; set; }

        RegisterModel newUser { get; set; } = null;
        ChangePswModel chgPsw { get; set; }
        ApplicationUser currentUsr { get; set; }

        bool OpenAddEditDialog { get; set; }
        bool OpenChangePswDialog { get; set; }

        #endregion

        #region Events
        protected async override Task OnInitializedAsync()
        {           
            await base.OnInitializedAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            await FetchData();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //JS.InvokeAsync<IJSObjectReference>("import", "./assets/plugins/global/plugins.bundle.js");
                jsRuntime.InvokeAsync<IJSObjectReference>("import", "./assets/js/scripts.bundle.js");
                //JS.InvokeAsync<IJSObjectReference>("import", "./assets/js/pages/dashboard.js");

                await getUserLanguage();
            }
            //return base.OnAfterRenderAsync(firstRender);
        }

        #endregion

        #region Functions

        protected async Task FetchData()
        {
            StateHasChanged();
        }

        protected async Task getUserLanguage()
        {
            string language = await profileService.GetLanguage();
            language = !string.IsNullOrEmpty(language) ? language : "en-US";
            SelectLanguage(language);
        }

        protected async Task setUserLanguage(string language)
        {
            if (!string.IsNullOrEmpty(language))
            {
                //save selected language in Browser Profile
                await profileService.SetLanguage(language);

                SelectLanguage(language);
            }
        }

        protected async Task SelectLanguage(string language)
        {
            currentLanguage = language;
            languageContainerService.SetLanguage(System.Globalization.CultureInfo.GetCultureInfo(language));

            //Change Language event
            bus.Publish(new LanguageChangeEvent { Language = language });

            await this.InvokeAsync(StateHasChanged);
        }

        //Call Add/Edit 
        private async Task OnEdit()
        {
            var user = (await authStat).User;
            currentUsr = await userManager.FindByNameAsync(user.Identity.Name);
            if (currentUsr != null)
            {
                bus.Subscribe<Aig.Auditoria.Events.SystemUsers.RegisterEvent>(RegisterEventHandler);
                OpenAddEditDialog = true;
            }

            //await this.InvokeAsync(StateHasChanged);
        }
        private async Task OnChangePsw()
        {
            var user = (await authStat).User;
            currentUsr = await userManager.FindByNameAsync(user.Identity.Name);
            if (currentUsr != null)
            {
                bus.Subscribe<Aig.Auditoria.Events.SystemUsers.ChangePswEvent>(ChangePswEventHandler);
                chgPsw = new ChangePswModel() { Id = currentUsr.Id };
                OpenChangePswDialog = true;
            }

            await this.InvokeAsync(StateHasChanged);
        }
        private void RegisterEventHandler(MessageArgs args)
        {
            bus.UnSubscribe<Aig.Auditoria.Events.SystemUsers.RegisterEvent>(RegisterEventHandler);
            OpenAddEditDialog = false;
            this.InvokeAsync(StateHasChanged);
        }
        private void ChangePswEventHandler(MessageArgs args)
        {
            bus.UnSubscribe<Aig.Auditoria.Events.SystemUsers.ChangePswEvent>(ChangePswEventHandler);
            OpenChangePswDialog = false;
            this.InvokeAsync(StateHasChanged);
        }

        #endregion


    }
}

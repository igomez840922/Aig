using Aig.FarmacoVigilancia.Events;
using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using Duende.IdentityServer.AspNetIdentity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;

namespace Aig.FarmacoVigilancia.Shared
{
    public partial class BackendLayout
    {
        [Inject]
        IAuthService authService { get; set; }
        
        [Inject]
        IProfileService profileService { get; set; }

        #region Variables

        [CascadingParameter]
        protected Task<AuthenticationState> authStat { get; set; }

        protected string currentLanguage { get; set; }

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

        #endregion


    }
}

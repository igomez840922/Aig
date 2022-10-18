using Aig.Auditoria.Events;
using Aig.Auditoria.Services;
using AKSoftware.Localization.MultiLanguages;
using Duende.IdentityServer.AspNetIdentity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;

namespace Aig.Auditoria.Shared
{
    public partial class MainLayout
    {
        [Inject]
        IAuthService authService { get; set; }
        [Inject]
        ISystemUserService systemUserService { get; set; }
        


        #region Events
        protected async override Task OnInitializedAsync()
        {           
            await base.OnInitializedAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            await base.OnAfterRenderAsync(firstRender);
            //return base.OnAfterRenderAsync(firstRender);
        }

        #endregion

        #region Functions

        

        #endregion


    }
}

using Aig.FarmacoVigilancia.Services;
using Microsoft.AspNetCore.Components;

namespace Aig.FarmacoVigilancia.Shared
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

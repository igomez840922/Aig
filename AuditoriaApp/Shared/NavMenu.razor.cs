using BlazorComponentBus;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AuditoriaApp.Shared
{
    public partial class NavMenu
    {
        [Inject]
        AuthenticationStateProvider GetAuthenticationStateAsync { get; set; }

        bool IsAdmin { get; set; } = false;

        protected async override Task OnInitializedAsync()
        {            
            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                
            }
            await base.OnAfterRenderAsync(firstRender);
        }

         

    }
}

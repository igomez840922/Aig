using Aig.Auditoria.Events;
using Aig.Auditoria.Helper;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Pages
{    
    public partial class Index
    {        
        protected async override Task OnInitializedAsync()
        {
            navigationManager.NavigateTo("/dashboard", true);
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

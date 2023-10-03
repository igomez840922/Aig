using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using AuditoriaApp.Services;

namespace AuditoriaApp.Components.SystemUsers
{    
    public partial class Edit
    {
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        [Inject]
        ISystemUserService systemUserService { get; set; }

        [Parameter]
        public ApplicationUser User { get; set; } = null;

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            //bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                
            }
        }

        private async Task FetchData()
        {
            await this.InvokeAsync(StateHasChanged);
        }
                
        /// <summary>
        /// Saving Data
        /// </summary>

        protected async Task SaveData()
        {
            User.UserRoleType = enumUserRoleType.Admin;
            var result = await systemUserService.Update(User);
            if (result != null)
            {
                if (result.Result)
                {
                    snackbar.Add(languageContainerService.Keys["DataSaveSuccessfully"], Severity.Success);
                    MudDialog.Close(DialogResult.Ok(true));
                }
                else
                {
                    snackbar.Add(result.Message, Severity.Error);
                }
            }
            else
                snackbar.Add(languageContainerService.Keys["DataSaveError"], Severity.Error);
        }

        protected async Task Cancel()
        {
            MudDialog.Cancel();
        }

    }

}

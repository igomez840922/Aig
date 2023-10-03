using BlazorComponentBus;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using AuditoriaApp.Services;

namespace AuditoriaApp.Pages.Settings.SystemUsers
{
    public partial class Index
    {
        [Inject]
        ISystemUserService SystemUserService { get; set; }

        [Inject]
        IDialogService DialogService { get; set; }

        GenericModel<ApplicationUser> model { get; set; } = new GenericModel<ApplicationUser>();

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            //bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            base.OnInitialized();
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                
                await FetchData();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        protected async Task FetchData()
        {
            model.ErrorMsg = null;
            model.Data = new ApplicationUser() { UserProfile = new UserProfileTB() };

            var data = await SystemUserService.FindAll(model);
            if (data != null)
            {
                model = data;
            }
            await this.InvokeAsync(StateHasChanged);
        }


        protected async Task OnPagingChange(int pIndex)
        {
            if (model.PagesCount < pIndex || model.PagIdx == pIndex - 1)
                return;

            model.PagIdx = pIndex - 1;

            await FetchData();
        }

        protected async Task OnFilter()
        {
            model.PagIdx = 0;

            await FetchData();
        }

       // <summary>
        /// /////////////
        /// </summary>

        //Call Add/Edit payment Order
        private async Task OnEdit(ApplicationUser data = null)
        {
            if (data == null)
            {
                var newUser = new RegisterModel() { UserProfile = new UserProfileTB() };
                //Open Modal
                var parameters = new DialogParameters();
                parameters.Add("User", newUser);
                var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Large, Position = DialogPosition.Center, FullWidth = true, DisableBackdropClick = true };
                var dialog = await DialogService.ShowAsync<AuditoriaApp.Components.SystemUsers.AddNew>(string.Format("New"), parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    FetchData();
                }
            }
            else
            {
                //Open Modal
                var parameters = new DialogParameters();
                parameters.Add("User", data);
                var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Large, Position = DialogPosition.Center, FullWidth = true, DisableBackdropClick = true };
                var dialog = await DialogService.ShowAsync<AuditoriaApp.Components.SystemUsers.Edit>(string.Format("Edit"), parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    FetchData();
                }
            }  
        }
        private async Task OnChangePasw(ApplicationUser data = null)
        {
            if (data != null)
            {
                var newUser = new ChangePswModel() { Id = data.Id };
                //Open Modal
                var parameters = new DialogParameters();
                parameters.Add("User", newUser);
                var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Large, Position = DialogPosition.Center, FullWidth = true, DisableBackdropClick = true };
                var dialog = await DialogService.ShowAsync<AuditoriaApp.Components.SystemUsers.ChangePsw>(string.Format("Change Password"), parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    FetchData();
                }
            }
        }

        private async Task OnDelete(ApplicationUser data)
        {
            model.Data = data;

            //Open Modal
            var parameters = new DialogParameters();
            parameters.Add("ContentText", "Do you really want to delete these records? This process cannot be undone.");
            parameters.Add("ButtonText", "Delete");
            parameters.Add("Color", MudBlazor.Color.Error);
            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };
            var dialog = await DialogService.ShowAsync<AuditoriaApp.Components.Dialog.DialogComponent>("Delete", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                DeleteData();
            }
        }
        
        private async Task DeleteData()
        {
            var result = await SystemUserService.Delete(model.Data.Id);
            if (result != null)
            {
                if (result.Result)
                {
                    snackbar.Add(languageContainerService.Keys["DataDeleteSuccessfully"], Severity.Success);
                    await FetchData();
                }
                else
                {
                    snackbar.Add(result.Message, Severity.Error);
                }
            }
            else
                snackbar.Add(languageContainerService.Keys["DataDeleteError"], Severity.Error);
        }
    }

}

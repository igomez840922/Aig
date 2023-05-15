using Aig.Auditoria.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using BlazorDownloadFile;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Events.DeleteConfirmationDlg;

namespace Aig.Auditoria.Pages.Settings.SystemUsers
{    
    public partial class Index
    {
        [Inject]
        ISystemUserService SystemUserService { get; set; }
        GenericModel<ApplicationUser> model { get; set; } = new GenericModel<ApplicationUser>(){ Data = new ApplicationUser() };
        RegisterModel newUser { get; set; } = null;
        ChangePswModel chgPsw { get; set; }

        bool OpenAddEditDialog { get; set; }
        bool OpenAddDialog { get; set; }
        bool OpenDeleteDialog { get; set; }
        bool OpenChangePswDialog { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<Aig.Auditoria.Events.SystemUsers.RegisterEvent>(RegisterEventHandler);
            bus.Subscribe<Aig.Auditoria.Events.SystemUsers.EditEvent>(EditEventHandler);
            bus.Subscribe<Aig.Auditoria.Events.SystemUsers.ChangePswEvent>(ChangePswEventHandler);
            bus.Subscribe<DeleteConfirmationCloseEvent>(DeleteConfirmationCloseEventHandler);
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
                //await getUserLanguaje();
                await FetchData();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        protected async Task FetchData()
        {
            OpenAddDialog = false; OpenAddEditDialog = false; OpenDeleteDialog = false;
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
            if (model.PagesCount < pIndex)
                return;

            model.PagIdx = pIndex - 1;

            await FetchData();
        }

        protected async Task OnFilter()
        {
            model.PagIdx = 0;

            await FetchData();
        }

        //SET LANGUAGE
        protected async Task getUserLanguaje(string? language = null)
        {
            //language = string.IsNullOrEmpty(language) ? await profileService.GetLanguage() : language;
            languageContainerService.SetLanguage(System.Globalization.CultureInfo.GetCultureInfo(language));
            await this.InvokeAsync(StateHasChanged);
        }

        private void LanguageChangeEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<LanguageChangeEvent>();

            getUserLanguaje(message.Language);
        }
        /// <summary>
        /// /////////////
        /// </summary>

        //Call Add/Edit 
        private async Task OnEdit(ApplicationUser data = null)
        {
            
            if (data == null)
            {
                OpenAddDialog = true;
                newUser = new RegisterModel();
            }
            else
            {
                model.Data = data;
                OpenAddEditDialog = true;
            }

            //await this.InvokeAsync(StateHasChanged);
        }
        private async Task OnChangePsw(ApplicationUser data = null)
        {

            if (data == null)
            {
                return;
            }
            else
            {
                chgPsw = new ChangePswModel() {  Id= data.Id};
                OpenChangePswDialog = true;
            }

            //await this.InvokeAsync(StateHasChanged);
        }
        private void RegisterEventHandler(MessageArgs args)
        {
            OpenAddDialog = false;
            //var message = args.GetMessage<PersonAddEdit_CloseEvent>();
            FetchData();
        }

        private void EditEventHandler(MessageArgs args)
        {
            OpenAddEditDialog = false;
            //var message = args.GetMessage<PersonAddEdit_CloseEvent>();
            FetchData();
        }
        private void ChangePswEventHandler(MessageArgs args)
        {
            OpenChangePswDialog = false;
            //var message = args.GetMessage<PersonAddEdit_CloseEvent>();
            FetchData();
        }
        

        private async Task OnDelete(ApplicationUser data)
        {
            OpenDeleteDialog = true;
            //bus.Subscribe<DeleteConfirmationCloseEvent>(DeleteConfirmationCloseEventHandler);
            model.Data = data;
            await bus.Publish(new DeleteConfirmationOpenEvent());
        }
        protected void DeleteConfirmationCloseEventHandler(MessageArgs args)
        {
            OpenDeleteDialog = false;
            //bus.UnSubscribe<DeleteConfirmationCloseEvent>(DeleteConfirmationCloseEventHandler);
            var message = args.GetMessage<DeleteConfirmationCloseEvent>();
            if (message.YesNo)
            {
                DeleteData();
            }
        }
        private async Task DeleteData()
        {
            var result = await SystemUserService.Delete(model.Data?.Id??"");
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataDeleteSuccessfully"]);
                await jsRuntime.InvokeVoidAsync("OpenCloseModal", "#btnCloseDeleteModal");

                await FetchData();
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataDeleteError"]);
        }

        public void Dispose()
        {
            //Subscribe Component to Language Change Event
            bus.UnSubscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.UnSubscribe<Aig.Auditoria.Events.SystemUsers.RegisterEvent>(RegisterEventHandler);
            bus.UnSubscribe<Aig.Auditoria.Events.SystemUsers.EditEvent>(EditEventHandler);
            bus.UnSubscribe<DeleteConfirmationCloseEvent>(DeleteConfirmationCloseEventHandler);

        }

        /////Export to excel
        //protected async Task ExportToExcel()
        //{
        //    Stream stream = await personService.ExportToExcel(dataModel);
        //    if (stream != null)
        //    {
        //        await blazorDownloadFileService.DownloadFile("RESPONSABLES_FARMACOVIGILANCIA.xlsx", stream, "application/actet-stream");
        //    }
        //}

    }

}

using BlazorComponentBus;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using Aig.Auditoria.Events.DeleteConfirmationDlg;
using Aig.Auditoria.Events.Inspections;
using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Services;
using BlazorComponentBus;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using BlazorDownloadFile;
using MimeKit;

namespace Aig.Auditoria.Pages.Settings.CorrespondenciaAsunto
{
    
    public partial class Index
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        ICorrespondenciaAsuntoService mainService { get; set; }        
        
        GenericModel<AUD_CorrespondenciaAsuntoTB> dataModel { get; set; } = new GenericModel<AUD_CorrespondenciaAsuntoTB>()
        { Data = new AUD_CorrespondenciaAsuntoTB() };

        bool OpenAddEditDialog { get; set; } = false;
        bool DeleteDialog { get; set; } = false;

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
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
                await getUserLanguaje();
                await FetchData();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        protected async Task FetchData()
        {

            dataModel.ErrorMsg = null;
            dataModel.Data = null;

            var data = await mainService.FindAll(dataModel);
            if (data != null)
            {
                dataModel = data;
            }
            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task OnPagingChange(int pIndex)
        {
            if (dataModel.PagesCount < pIndex)
                return;

            dataModel.PagIdx = pIndex - 1;

            await FetchData();
        }

        protected async Task OnFilter()
        {
            dataModel.PagIdx = 0;

            await FetchData();
        }

        //SET LANGUAGE
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
        /// <summary>
        /// /////////////
        /// </summary>

        //Call Add/Edit 
        private async Task OnEdit(long id)
        {
            OpenAddEditDialog = true;
            var result = await mainService.Get(id);
            if (result == null)
            {
                result = new AUD_CorrespondenciaAsuntoTB();
            }
            dataModel.Data = result;

            bus.Subscribe<Aig.Auditoria.Events.CorrespondenciaAsunto.AddEditEvent>(AddEditEventHandler);

            await this.InvokeAsync(StateHasChanged);
        }
        private void AddEditEventHandler(MessageArgs args)
        {
            bus.UnSubscribe<Aig.Auditoria.Events.CorrespondenciaAsunto.AddEditEvent>(AddEditEventHandler);

            OpenAddEditDialog = false;
            var message = args.GetMessage<Aig.Auditoria.Events.CorrespondenciaAsunto.AddEditEvent>();

            FetchData();
        }

        private async Task OnDelete(AUD_CorrespondenciaAsuntoTB data)
        {
            bus.Subscribe<Aig.Auditoria.Events.DeleteConfirmationDlg.DeleteConfirmationCloseEvent>(DeleteConfirmationCloseEventHandler);
            dataModel.Data = data;
            DeleteDialog = true;

            await this.InvokeAsync(StateHasChanged);
        }
        protected void DeleteConfirmationCloseEventHandler(MessageArgs args)
        {
            DeleteDialog = false;
            bus.UnSubscribe<Aig.Auditoria.Events.DeleteConfirmationDlg.DeleteConfirmationCloseEvent>(DeleteConfirmationCloseEventHandler);
            var message = args.GetMessage<Aig.Auditoria.Events.DeleteConfirmationDlg.DeleteConfirmationCloseEvent>();
            if (message.YesNo)
            {
                DeleteData();
            }

            this.InvokeAsync(StateHasChanged);
        }
        private async Task DeleteData()
        {
            var result = await mainService.Delete(dataModel.Data?.Id ?? 0);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataDeleteSuccessfully"]);
                await jsRuntime.InvokeVoidAsync("OpenCloseModal", "#btnCloseDeleteModal");

                await FetchData();
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataDeleteError"]);
        }


    }

}

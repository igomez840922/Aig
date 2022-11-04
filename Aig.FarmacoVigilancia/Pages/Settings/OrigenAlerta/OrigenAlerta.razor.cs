using Aig.FarmacoVigilancia.Events.WorkerPerson;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Events.DeleteConfirmationDlg;
using Aig.FarmacoVigilancia.Events.OrigenAlerta;

namespace Aig.FarmacoVigilancia.Pages.Settings.OrigenAlerta
{    
    public partial class OrigenAlerta
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IOrigenAlertaService origenAlertaService { get; set; }

        GenericModel<FMV_OrigenAlertaTB> dataModel { get; set; } = new GenericModel<FMV_OrigenAlertaTB>()
        { Data = new FMV_OrigenAlertaTB() };

        bool OpenAddEditDialog { get; set; } = false;

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<OrigenAlertaAddEdit_CloseEvent>(OrigenAlertaAddEdit_CloseHandler);
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
            var data = await origenAlertaService.FindAll(dataModel);
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
            var result = await origenAlertaService.Get(id);
            if (result == null)
            {
                result = new FMV_OrigenAlertaTB();
            }
            dataModel.Data = result;
            await bus.Publish(new OrigenAlertaAddEdit_OpenEvent { Data = result });
            await this.InvokeAsync(StateHasChanged);
        }
        private void OrigenAlertaAddEdit_CloseHandler(MessageArgs args)
        {
            OpenAddEditDialog = false;
            var message = args.GetMessage<OrigenAlertaAddEdit_CloseEvent>();
            FetchData();
        }

        private async Task OnDelete(FMV_OrigenAlertaTB data)
        {
            bus.Subscribe<DeleteConfirmationCloseEvent>(DeleteConfirmationCloseEventHandler);
            dataModel.Data = data;
            await bus.Publish(new DeleteConfirmationOpenEvent());
        }
        protected void DeleteConfirmationCloseEventHandler(MessageArgs args)
        {
            bus.UnSubscribe<DeleteConfirmationCloseEvent>(DeleteConfirmationCloseEventHandler);
            var message = args.GetMessage<DeleteConfirmationCloseEvent>();
            if (message.YesNo)
            {
                DeleteData();
            }
        }
        private async Task DeleteData()
        {
            var result = await origenAlertaService.Delete(dataModel.Data?.Id??0);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataDeleteSuccessfully"]);
                await jsRuntime.InvokeVoidAsync("OpenCloseModal", "#btnCloseDeleteModal");

                await FetchData();
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataDeleteError"]);
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

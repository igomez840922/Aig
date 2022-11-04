using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using BlazorDownloadFile;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Aig.FarmacoVigilancia.Events.Alerta;
using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Events.DeleteConfirmationDlg;

namespace Aig.FarmacoVigilancia.Pages.Alert
{    
    public partial class Alert
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IAlertaService alertaService { get; set; }
        [Inject]
        IWorkerPersonService personService { get; set; }
        [Inject]
        IOrigenAlertaService origenAlertaService { get; set; }
        List<PersonalTrabajadorTB> LPerson { get; set; }
        List<FMV_OrigenAlertaTB> LOriginAlert { get; set; }

        [Inject]
        IBlazorDownloadFileService blazorDownloadFileService { get; set; }

        GenericModel<FMV_AlertaTB> dataModel { get; set; } = new GenericModel<FMV_AlertaTB>()
        { Data = new FMV_AlertaTB() };

        bool OpenAddEditDialog { get; set; } = false;

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<AlertAddEdit_CloseEvent>(AlertAddEdit_CloseHandler);
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
            if (LPerson == null || LPerson.Count < 1)
            {
                LPerson = await personService.GetAll();
            }
            if (LOriginAlert == null || LOriginAlert.Count < 1)
            {
                LOriginAlert = await origenAlertaService.GetAll();
            }

            dataModel.ErrorMsg = null;
            dataModel.Data = null;
            var data = await alertaService.FindAll(dataModel);
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
            var result = await alertaService.Get(id);
            if (result == null)
            {
                result = new FMV_AlertaTB();
            }
            dataModel.Data = result;
            await bus.Publish(new AlertaAddEdit_OpenEvent { Data = result });
            await this.InvokeAsync(StateHasChanged);
        }
        private void AlertAddEdit_CloseHandler(MessageArgs args)
        {
            OpenAddEditDialog = false;
            var message = args.GetMessage<AlertAddEdit_CloseEvent>();
            FetchData();
        }

        private async Task OnDelete(FMV_AlertaTB data)
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
            var result = await alertaService.Delete(dataModel.Data?.Id??0);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataDeleteSuccessfully"]);
                await jsRuntime.InvokeVoidAsync("OpenCloseModal", "#btnCloseDeleteModal");

                await FetchData();
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataDeleteError"]);
        }

        ///Export to excel
        protected async Task ExportToExcel()
        {
            Stream stream = await alertaService.ExportToExcel(dataModel);
            if (stream != null)
            {
                await blazorDownloadFileService.DownloadFile("ALERTA_SEGURIDAD.xlsx", stream, "application/actet-stream");
            }
        }

    }

}

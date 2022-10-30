using Aig.FarmacoVigilancia.Events.PMR;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Events.IPS;
using Aig.FarmacoVigilancia.Events.DeleteConfirmationDlg;
using BlazorDownloadFile;

namespace Aig.FarmacoVigilancia.Pages.IPS
{    
    public partial class Ips
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IIpsService ipsService { get; set; }
        [Inject]
        IWorkerPersonService workerPersonService { get; set; }
        [Inject]
        ILabsService labsService { get; set; }
        List<PersonalTrabajadorTB> lPersons { get; set; }
        List<LaboratorioTB> Labs { get; set; }
        
        [Inject]
        IBlazorDownloadFileService blazorDownloadFileService { get; set; }

        GenericModel<FMV_IpsTB> dataModel { get; set; } = new GenericModel<FMV_IpsTB>()
        { Data = new FMV_IpsTB() };

        bool OpenAddEditDialog { get; set; } = false;

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<IpsAddEdit_CloseEvent>(IpsAddEdit_CloseHandler);
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
                await getUserLanguaje();
                await FetchData();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        protected async Task FetchData()
        {
            if (lPersons == null || lPersons.Count < 1)
            {
                lPersons = await workerPersonService.GetAll();
            }
            if (Labs == null || Labs.Count < 1)
            {
                Labs = await labsService.GetAll();
            }

            dataModel.ErrorMsg = null;
            dataModel.Data = null;
            var data = await ipsService.FindAll(dataModel);
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
            var result = await ipsService.Get(id);
            if (result == null)
            {
                result = new FMV_IpsTB() { IpsData=new FMV_IpsData() };
            }
            dataModel.Data = result;
            await bus.Publish(new IpsAddEdit_OpenEvent { Data = result });
            await this.InvokeAsync(StateHasChanged);
        }
        private void IpsAddEdit_CloseHandler(MessageArgs args)
        {
            OpenAddEditDialog = false;
            var message = args.GetMessage<IpsAddEdit_CloseEvent>();
            FetchData();
        }

        private async Task OnDelete(FMV_IpsTB data)
        {
            dataModel.Data = data;
            await bus.Publish(new DeleteConfirmationOpenEvent());
        }
        protected void DeleteConfirmationCloseEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<DeleteConfirmationCloseEvent>();
            if (message.YesNo)
            {
                DeleteData();
            }
        }
        private async Task DeleteData()
        {
            var result = await ipsService.Delete(dataModel.Data.Id);
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
            Stream stream = await ipsService.ExportToExcel(dataModel);
            if (stream != null)
            {
                await blazorDownloadFileService.DownloadFile("productosretirados.xlsx", stream, "application/actet-stream");
            }
        }

    }

}

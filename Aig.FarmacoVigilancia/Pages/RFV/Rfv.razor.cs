using Aig.FarmacoVigilancia.Events.IPS;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using BlazorDownloadFile;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Events.PMR;
using Aig.FarmacoVigilancia.Events.DeleteConfirmationDlg;

namespace Aig.FarmacoVigilancia.Pages.RFV
{
    public partial class Rfv
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IRfvService rfvService { get; set; }
        [Inject]
        ILabsService labsService { get; set; }
        List<LaboratorioTB> Labs { get; set; }

        [Inject]
        IBlazorDownloadFileService blazorDownloadFileService { get; set; }
        [Inject]
        IPdfGenerationService pdfGenerationService { get; set; }

        GenericModel<FMV_RfvTB> dataModel { get; set; } = new GenericModel<FMV_RfvTB>()
        { Data = new FMV_RfvTB() };

        bool OpenAddEditDialog { get; set; } = false;

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<RfvAddEdit_CloseEvent>(RfvAddEdit_CloseHandler);
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
            if (Labs == null || Labs.Count < 1)
            {
                Labs = await labsService.GetAll();
            }

            dataModel.ErrorMsg = null;
            dataModel.Data = null;
            var data = await rfvService.FindAll(dataModel);
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
            var result = await rfvService.Get(id);
            if (result == null)
            {
                result = new FMV_RfvTB();
            }
            dataModel.Data = result;
            await bus.Publish(new RfvAddEdit_OpenEvent { Data = result });
            await this.InvokeAsync(StateHasChanged);
        }
        private void RfvAddEdit_CloseHandler(MessageArgs args)
        {
            OpenAddEditDialog = false;
            var message = args.GetMessage<RfvAddEdit_CloseEvent>();
            FetchData();
        }

        private async Task OnDelete(FMV_RfvTB data)
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
            var result = await rfvService.Delete(dataModel.Data?.Id ?? 0);
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
            Stream stream = await rfvService.ExportToExcel(dataModel);
            if (stream != null)
            {
                await blazorDownloadFileService.DownloadFile("RESPONSABLES_FARMACOVIGILANCIA.xlsx", stream, "application/actet-stream");
            }
        }

        private async Task DownloadPdf(long Id)
        {
            //Stream stream = await pdfGenerationService.GenerateAlertPDF(Id);
            //if (stream != null)
            //{
            //    await blazorDownloadFileService.DownloadFile("ALERTA_SEGURIDAD.pdf", stream, "application/actet-stream");
            //}

            var data = await rfvService.Get(Id);
            if (data?.Adjunto?.LAttachments?.Count > 0)
            {
                foreach (var attachment in data.Adjunto.LAttachments)
                {
                    Stream stream = await pdfGenerationService.GetStreamsFromFile(attachment.AbsolutePath);
                    if (stream != null)
                        await blazorDownloadFileService.DownloadFile(attachment.FileName, stream, "application/actet-stream");
                }
            }

        }


    }

}

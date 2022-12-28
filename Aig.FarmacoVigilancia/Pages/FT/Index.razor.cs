﻿using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using BlazorDownloadFile;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Aig.FarmacoVigilancia.Events.Language;

namespace Aig.FarmacoVigilancia.Pages.FT
{
    public partial class Index
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IFTService ftService { get; set; }
        [Inject]
        IWorkerPersonService workerPersonService { get; set; }
        [Inject]
        IBlazorDownloadFileService blazorDownloadFileService { get; set; }
        [Inject]
        IPdfGenerationService pdfGenerationService { get; set; }
        List<PersonalTrabajadorTB> lPersons { get; set; }
        GenericModel<FMV_FtTB> dataModel { get; set; } = new GenericModel<FMV_FtTB>()
        { Data = new FMV_FtTB() };

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
            if (lPersons == null || lPersons.Count < 1)
            {
                lPersons = await workerPersonService.GetAll();
            }
            dataModel.ErrorMsg = null;
            dataModel.Data = null;

            var data = await ftService.FindAll(dataModel);
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
            var result = await ftService.Get(id);
            if (result == null)
            {
                result = new FMV_FtTB();
            }
            dataModel.Data = result;
            //Aig.FarmacoVigilancia.Events.Ram.AddEdit_CloseEvent
            bus.Subscribe<Aig.FarmacoVigilancia.Events.FT.AddEdit_CloseEvent>(AddEdit_CloseHandler);

            await this.InvokeAsync(StateHasChanged);
        }
        private void AddEdit_CloseHandler(MessageArgs args)
        {
            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.FT.AddEdit_CloseEvent>(AddEdit_CloseHandler);

            OpenAddEditDialog = false;
            var message = args.GetMessage<Aig.FarmacoVigilancia.Events.FT.AddEdit_CloseEvent>();

            FetchData();
        }

        private async Task OnDelete(FMV_FtTB data)
        {
            bus.Subscribe<Aig.FarmacoVigilancia.Events.DeleteConfirmationDlg.DeleteConfirmationCloseEvent>(DeleteConfirmationCloseEventHandler);
            dataModel.Data = data;
            DeleteDialog = true;

            await this.InvokeAsync(StateHasChanged);
        }
        protected void DeleteConfirmationCloseEventHandler(MessageArgs args)
        {
            DeleteDialog = false;
            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.DeleteConfirmationDlg.DeleteConfirmationCloseEvent>(DeleteConfirmationCloseEventHandler);
            var message = args.GetMessage<Aig.FarmacoVigilancia.Events.DeleteConfirmationDlg.DeleteConfirmationCloseEvent>();
            if (message.YesNo)
            {
                DeleteData();
            }

            this.InvokeAsync(StateHasChanged);
        }
        private async Task DeleteData()
        {
            var result = await ftService.Delete(dataModel.Data?.Id ?? 0);
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
            Stream stream = await ftService.ExportToExcel(dataModel);
            if (stream != null)
            {
                await blazorDownloadFileService.DownloadFile("SOSPECHAS_FALLAS_TERAPEUTICAS.xlsx", stream, "application/actet-stream");
            }
        }

        private async Task DownloadPdf(long Id)
        {
            //Stream stream = await pdfGenerationService.GenerateAlertPDF(Id);
            //if (stream != null)
            //{
            //    await blazorDownloadFileService.DownloadFile("ALERTA_SEGURIDAD.pdf", stream, "application/actet-stream");
            //}

            var data = await ftService.Get(Id);
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
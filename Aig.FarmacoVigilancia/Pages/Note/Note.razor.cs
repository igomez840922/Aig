﻿using Aig.FarmacoVigilancia.Events.Alerta;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using BlazorDownloadFile;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Events.Nota;
using Aig.FarmacoVigilancia.Events.DeleteConfirmationDlg;
using System.IO;
using MimeKit;

namespace Aig.FarmacoVigilancia.Pages.Note
{   
    public partial class Note
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        INoteService noteService { get; set; }
        [Inject]
        IWorkerPersonService personService { get; set; }
        [Inject]
        IDestinyInstituteService destinyInstituteService { get; set; }
        List<PersonalTrabajadorTB> LPerson { get; set; } = new List<PersonalTrabajadorTB>();
        List<InstitucionDestinoTB> LInstitucionDestino { get; set; }

        [Inject]
        IBlazorDownloadFileService blazorDownloadFileService { get; set; }
        [Inject]
        IPdfGenerationService pdfGenerationService { get; set; }
        [Inject]
        IEmailService emailService { get; set; }


        GenericModel<FMV_NotaTB> dataModel { get; set; } = new GenericModel<FMV_NotaTB>()
        { Data = new FMV_NotaTB() };

        bool OpenAddEditDialog { get; set; } = false;

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<NotaAddEdit_CloseEvent>(NotaAddEdit_CloseHandler);            
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
            if (LInstitucionDestino == null || LInstitucionDestino.Count < 1)
            {
                LInstitucionDestino = await destinyInstituteService.GetAll();
            }

            dataModel.ErrorMsg = null;
            dataModel.Data = null;
            var data = await noteService.FindAll(dataModel);
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
            var result = await noteService.Get(id);
            if (result == null)
            {
                result = new FMV_NotaTB();
            }
            dataModel.Data = result;
            await bus.Publish(new NotaAddEdit_OpenEvent { Data = result });
            await this.InvokeAsync(StateHasChanged);
        }
        private void NotaAddEdit_CloseHandler(MessageArgs args)
        {
            OpenAddEditDialog = false;
            var message = args.GetMessage<NotaAddEdit_CloseEvent>();
            FetchData();
        }

        private async Task OnDelete(FMV_NotaTB data)
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
            var result = await noteService.Delete(dataModel.Data?.Id ?? 0);
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
            Stream stream = await noteService.ExportToExcel(dataModel);
            if (stream != null)
            {
                await blazorDownloadFileService.DownloadFile("NOTA_SEGURIDAD.xlsx", stream, "application/actet-stream");
            }
        }

        private async Task DownloadPdf(long Id)
        {
            //Stream stream = await pdfGenerationService.GenerateAlertPDF(Id);
            //if (stream != null)
            //{
            //    await blazorDownloadFileService.DownloadFile("ALERTA_SEGURIDAD.pdf", stream, "application/actet-stream");
            //}

            var data = await noteService.Get(Id);
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

        private async Task SendEmailNotification(long Id)
        {
            try
            {
                var data = await noteService.Get(Id);
                if (data != null && data.NotaContactos?.LContactos?.Count>0)
                {
                    var subject = "Nota #: " + data.NumNota + " - " + data.Asunto;

                    var builder = new BodyBuilder();

                    builder.TextBody = "Nota #: " + data.NumNota + "\r\n" + data.Descripcion;

                    if (data.Adjunto?.LAttachments?.Count > 0)
                    {
                        foreach(var attch in data.Adjunto.LAttachments)
                        {
                            var stream = await pdfGenerationService.GetStreamsFromFile(attch.AbsolutePath);
                            if (stream != null)
                            {
                                builder.Attachments.Add("adjunto.pdf", stream);
                            }
                        }
                    }

                    List<string> lEmails = (from email in data.NotaContactos.LContactos
                                            select email.Correo).ToList();

                   if( await emailService.SendEmailAsync(lEmails, subject, builder))
                    {
                        await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["EmailSentSuccessfully"]);
                        return;
                    }
                    await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["EmailSentError"]);

                }

            }
            catch (Exception ex) { }
        }

    }

}

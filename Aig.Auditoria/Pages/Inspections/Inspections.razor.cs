using Aig.Auditoria.Events.DeleteConfirmationDlg;
using Aig.Auditoria.Events.Inspections;
using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Services;
using BlazorComponentBus;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using DataModel.Helper;
using Microsoft.AspNetCore.Mvc;
using BlazorDownloadFile;
using MimeKit;

namespace Aig.Auditoria.Pages.Inspections
{
    public partial class Inspections
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IInspectionsService inspeccionService { get; set; }
        [Inject]
        IPdfGenerationService pdfGenerationService { get; set; }
        [Inject] 
        IBlazorDownloadFileService blazorDownloadFileService { get; set; }
        [Inject]
        IEmailService emailService { get; set; }

        GenericModel<AUD_InspeccionTB> dataModel { get; set; } = new GenericModel<AUD_InspeccionTB>()
        { Data = new AUD_InspeccionTB() };

        bool OpenAddEdit { get; set; }=false;

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
            OpenAddEdit = false;
            dataModel.Data = null;
            var data = await inspeccionService.FindAll(dataModel);
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
        

        //Call Add/Edit 
        private async Task OnEdit(long id)
        {
            var result = await inspeccionService.Get(id);
            if (result == null)
            {
                result = new AUD_InspeccionTB() { DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), };
            }
            OpenAddEditScreen(result);
        }
        private void InspectionAddEdit_CloseEventHandler(MessageArgs args)
        {
            bus.UnSubscribe<Aig.Auditoria.Events.Inspections.AddEditCloseEvent>(InspectionAddEdit_CloseEventHandler);

            var message = args.GetMessage<Aig.Auditoria.Events.Inspections.AddEditCloseEvent>();

            if (message.Inspeccion != null)
            {
                OpenAddEditScreen(message.Inspeccion);
                return;
            }
            FetchData();
        }
        private async Task OpenAddEditScreen(AUD_InspeccionTB data)
        {
            bus.Subscribe<Aig.Auditoria.Events.Inspections.AddEditCloseEvent>(InspectionAddEdit_CloseEventHandler);
            dataModel.Data = data;
            OpenAddEdit = true;
            await this.InvokeAsync(StateHasChanged);
        }

        private async Task OnDelete(AUD_InspeccionTB data)
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
            var result = await inspeccionService.Delete(dataModel.Data?.Id ?? 0);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataDeleteSuccessfully"]);

                await jsRuntime.InvokeVoidAsync("OpenCloseModal", "#btnCloseDeleteModal");

                await FetchData();
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataDeleteError"]);
        }

      
        private async Task DownloadPdf(long Id)
        {            
            Stream stream = await pdfGenerationService.GenerateInspectionPDF(Id);

            if(stream != null)
            {
                await blazorDownloadFileService.DownloadFile("inspeccion.pdf", stream, "application/actet-stream");
            }

            //if (stream != null)
            //{
            //    await jsRuntime.InvokeVoidAsync("downloadFileFromStream", "inspeccion.pdf", stream);
            //}
        }

        private async Task SendEmailNotification(long Id)
        {
            try
            {
                var data = await inspeccionService.Get(Id);
                if (data!=null && !string.IsNullOrEmpty(data.ParticEstablecimientoEmail))
                {
                    var subject = data.NumActa + " - " + DataModel.Helper.Helper.GetDescription(data.TipoActa);

                    var builder = new BodyBuilder();

                    builder.TextBody = "Inspección #" + data.NumActa + " - " + DataModel.Helper.Helper.GetDescription(data.TipoActa);

                    var stream = await pdfGenerationService.GenerateInspectionPDF(data.Id);
                    if (stream != null)
                    {
                        builder.Attachments.Add("inspeccion.pdf", stream);
                    }                    
                    await emailService.SendEmailAsync(data.ParticEstablecimientoEmail, subject, builder);
                }

            }
            catch (Exception ex) { }
        }

        protected async Task ExportToExcel()
        {
            Stream stream = await inspeccionService.ExportToExcel(dataModel);
            if (stream != null)
            {
                await blazorDownloadFileService.DownloadFile("inspecciones.xlsx", stream, "application/actet-stream");
            }
        }

    }

}

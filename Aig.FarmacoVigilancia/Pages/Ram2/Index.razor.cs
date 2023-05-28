using Aig.FarmacoVigilancia.Events.PMR;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using BlazorDownloadFile;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Aig.FarmacoVigilancia.Events.Language;
using System.Net.Mail;
using Aig.FarmacoVigilancia.Pages.Alert;
using Newtonsoft.Json;
using System.Text;
using DataModel.Helper;

namespace Aig.FarmacoVigilancia.Pages.Ram2
{
    public partial class Index
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IRamService2 ramService { get; set; }
        [Inject]
        IWorkerPersonService workerPersonService { get; set; }
        [Inject]
        IBlazorDownloadFileService blazorDownloadFileService { get; set; }
        [Inject]
        IImportFileService importFileService { get; set; }
        List<PersonalTrabajadorTB> lPersons { get; set; } = new List<PersonalTrabajadorTB>();
        GenericModel<FMV_Ram2TB> dataModel { get; set; } = new GenericModel<FMV_Ram2TB>()
        { Data = new FMV_Ram2TB() };

        bool OpenAddEditDialog { get; set; } = false;
        bool DeleteDialog { get; set; } = false;

        bool openAttachment { get; set; } = false;
        AttachmentTB attachment { get; set; } = null;

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<Aig.FarmacoVigilancia.Events.Attachments.AttachmentsAddEdit_CloseEvent>(AttachmentsAddEdit_CloseEventHandler);
            
            base.OnInitialized();
        }
        public void Dispose()
        {            
            bus.UnSubscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.Attachments.AttachmentsAddEdit_CloseEvent>(AttachmentsAddEdit_CloseEventHandler);

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

            var data = await ramService.FindAll(dataModel);
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
            var result = await ramService.Get(id);
            if (result == null)
            {
                result = new FMV_Ram2TB();
            }
            dataModel.Data = result;
            OpenAddEditDialog = true;
            
            bus.Subscribe<Aig.FarmacoVigilancia.Events.Ram2.AddEdit_Event>(AddEdit_CloseHandler);
            await this.InvokeAsync(StateHasChanged);
        }
        private void AddEdit_CloseHandler(MessageArgs args)
        {
            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.Ram2.AddEdit_Event>(AddEdit_CloseHandler);

            OpenAddEditDialog = false;
            var message = args.GetMessage<Aig.FarmacoVigilancia.Events.Ram2.AddEdit_Event>();

            FetchData();
        }

        private async Task OnDelete(FMV_Ram2TB data)
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
            var result = await ramService.Delete(dataModel.Data?.Id ?? 0);
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
            Stream stream = await ramService.ExportToExcel(dataModel);
            if (stream != null)
            {
                await blazorDownloadFileService.DownloadFile("REACCIONES_ADVERSAS_MEDICAMENTOS.xlsx", stream, "application/actet-stream");
            }
        }
        

        //Add New Attachment
        protected async Task ImportarToExcel(AttachmentTB _attachment = null)
        {
          
            //bus.Subscribe<Aig.FarmacoVigilancia.Events.Attachments.AttachmentsAddEdit_CloseEvent>(AttachmentsAddEdit_CloseEventHandler);

            attachment = _attachment != null ? _attachment : new AttachmentTB();
            openAttachment = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //ON CLOSE ATTACHMENT
        private void AttachmentsAddEdit_CloseEventHandler(MessageArgs args)
        {
            jsRuntime.InvokeVoidAsync("ShowLoading");
            try
            {
                openAttachment = false;

                //bus.UnSubscribe<Aig.FarmacoVigilancia.Events.Attachments.AttachmentsAddEdit_CloseEvent>(AttachmentsAddEdit_CloseEventHandler);

                var message = args.GetMessage<Aig.FarmacoVigilancia.Events.Attachments.AttachmentsAddEdit_CloseEvent>();
                if (message.Attachment != null)
                {
                    importFileService.ImportRAMEsavi(message.Attachment);
                    //message.Attachment.InspeccionId = Inspeccion.Id;
                    //Alerta.Adjunto = Alerta.Adjunto != null ? Alerta.Adjunto : new AttachmentData();
                    //Alerta.Adjunto.LAttachments = Alerta.Adjunto.LAttachments != null ? Alerta.Adjunto.LAttachments : new List<AttachmentTB>();
                    //Alerta.Adjunto.LAttachments.Add(message.Attachment);
                    FetchData();
                }
            }
            catch { }
            finally
            {
                jsRuntime.InvokeVoidAsync("CloseLoading");
                this.InvokeAsync(StateHasChanged);
            }
        }

        private async Task TransferToFadi(long id)
        {
            jsRuntime.InvokeVoidAsync("ShowLoading");
            try
            {
                var data = await ramService.Get(id);
                if (data != null)
                {
                    /*
                     FechaRecibidoCNFV = (DateTime)data.Cell(1).GetValue<DateTime>(),
                                            CodigoNotiFacedra = (string)data.Cell(3).GetValue<string>(),
                                            CodigoCNFV = (string)data.Cell(3).GetValue<string>(),
                                            LFarmacos = new List<FMV_RamFarmacoTB>() {
                                                new FMV_RamFarmacoTB()
                                                {
                                                    FarmacoSospechosoComercial= (string)data.Cell(7).GetValue<string>(),
                                                    FarmacoSospechosoDci= (string)data.Cell(7).GetValue<string>(),
                                                }
                                            }
                     */
                    var dataImport = new ImportFVRE()
                    {
                        NumNotificacion = data.CodigoCNFV,
                        FechaNotificacion = data.FechaRecibidoCNFV,
                        FarmacoNotificado = data.LFarmacos?.FirstOrDefault()?.FarmacoSospechosoDci ?? "",
                        TipoTramiteFVRE = TipoTramiteFVRE.RAM
                    };
                    var result = await importFileService.TransferRAMEsavi(dataImport);
                    if (!string.IsNullOrEmpty(result))
                    {
                        await jsRuntime.InvokeVoidAsync("ShowError", result);
                    }
                    else
                    {
                        await jsRuntime.InvokeVoidAsync("ShowMessage", "Trámite exportado satisfactoriamente");
                    }
                }

            }
            catch { }
            finally
            {
                jsRuntime.InvokeVoidAsync("CloseLoading");
                this.InvokeAsync(StateHasChanged);
            }

        }

    }

}

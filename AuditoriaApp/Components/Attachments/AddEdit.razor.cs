using BlazorComponentBus;
using AuditoriaApp.Services;
using DataModel.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using MudBlazor;
using System.Text.Json;

namespace AuditoriaApp.Components.Attachments
{
    public partial class AddEdit
    {
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        [Inject]
        IUploadService mainService { get; set; }

        private JsonSerializerOptions _options { get; set; }

        [Parameter]
        public DataModel.AttachmentTB Data { get; set; } = null;

        IBrowserFile selectedFile { get; set; }

        bool loading { get; set; } = false;

        int maxFileSize { get; set; } = 1024 * 1024 * 10;

        private DotNetObjectReference<AuditoriaApp.Components.Attachments.AddEdit>? objRef;

        protected async override Task OnInitializedAsync()
        {
            objRef = DotNetObjectReference.Create(this);

            //Subscribe Component to Language Change Event
            //bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await FetchData();
            }
        }

        public void Dispose()
        {
            //bus.UnSubscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
        }

        
        /// <summary>
        /// Saving Data
        /// </summary>

        protected async Task FetchData()
        {
            loading = false;
            Data = Data != null ? Data : new DataModel.AttachmentTB();

            await this.InvokeAsync(StateHasChanged);
        }
        
        protected async Task Cancel()
        {
            MudDialog.Cancel();
        }

        protected async Task SaveData()
        {
            try
            {
                if (selectedFile != null)
                {
                    _options = _options != null ? _options : new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    if (selectedFile.Size > maxFileSize)
                    {
                        snackbar.Add(string.Format("Ha excedido el máximo de 10MB"), Severity.Error);
                        return;
                    }

                    loading = true;
                    var result = await mainService.UploadFile(selectedFile);
                    if (result != null)
                    {
                        Data.AbsolutePath = result.AbsolutePath;
                        Data.Url = result.Url;
                        Data.FileName = result.FileName;

                        MudDialog.Close(DialogResult.Ok(Data));

                        //Snackbar.Add(languageContainerService.Keys["DataSaveOk"], Severity.Success);

                        return;
                    }
                    //var flag = await jsRuntime.InvokeAsync<bool>("UploadFiles", objRef);
                    //return;                    
                }
                else
                {
                    snackbar.Add("Seleccione un Archivo", Severity.Error);
                    return;
                }
            }
            catch(Exception ex) { snackbar.Add(ex.Message, Severity.Error); }
            finally { loading = false; }

            snackbar.Add("Error al guardar el archivo", Severity.Error);
        }

        [JSInvokable]
        public async Task UploadFileResponse(FileUploadResult result)
        {
            loading = false;
            if (!string.IsNullOrEmpty(result.FileName))
            {
                Data.AbsolutePath = result.AbsolutePath;
                Data.Url = result.Url;
                Data.FileName = result.FileName;

                //await bus.Publish(new AttachmentsAddEdit_CloseEvent() { Attachment = attachment });
                MudDialog.Close(DialogResult.Ok(Data));
                return;
            }
            else
            {
                snackbar.Add("Error al guardar el archivo", Severity.Error);
            }
            await this.InvokeAsync(StateHasChanged);
        }

        private void UploadFiles(IBrowserFile file)
        {
            selectedFile = file;
        }

    }

}

using Aig.FarmacoVigilancia.Events.Attachments;
using Aig.FarmacoVigilancia.Events.Country;
using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Net.Mail;

namespace Aig.FarmacoVigilancia.Components.Attachments
{   
    public partial class AddEditAttachment
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IAttachmentsService attachmentsService { get; set; }
        [Inject]
        IWebHostEnvironment env { get; set; }

        [Parameter]
        public DataModel.AttachmentTB attachment { get; set; } = null;

        IBrowserFile selectedFile { get; set; }

        int maxFileSize { get; set; } = 1024 * 1024 * 10;

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);

            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await getUserLanguaje();
                await FetchData();
            }
        }

        //CHANGE LANGUAJE
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

        //Fill Data
        protected async Task FetchData()
        {
            attachment = attachment!=null? attachment : new DataModel.AttachmentTB();
                        
            await this.InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Saving Data
        /// </summary>

        //Save Data and Close
        protected async Task SaveData()
        {
            try {
                if (selectedFile != null)
                {
                    if(selectedFile.Size > maxFileSize)
                    {
                        await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["YouExceedMaximumSizeOf"] + " 10MB");
                        return;
                    }

                    Stream stream = selectedFile.OpenReadStream(maxFileSize);
                    var fileName = string.Format("{0}.{1}", Guid.NewGuid().ToString(), selectedFile.Name.Split(".").LastOrDefault());
                    var path = System.IO.Path.Combine(env.WebRootPath, "files", fileName);
                    //$"{env.WebRootPath}\\{selectedFile.Name}";
                    FileStream fs = File.Create(path);
                    await stream.CopyToAsync(fs);
                    stream.Close();
                    fs.Close();

                    attachment.AbsolutePath = path;
                    attachment.Url = string.Format("/files/{0}", fileName);
                    attachment.FileName = fileName;

                    await bus.Publish(new AttachmentsAddEdit_CloseEvent() { Attachment = attachment });
                    return;
                }
            }
            catch { }
            await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);

        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new AttachmentsAddEdit_CloseEvent() { Attachment = null });
        }
        private void OnFileSelection(InputFileChangeEventArgs e)
        {
            selectedFile = e.GetMultipleFiles(1).FirstOrDefault(); // e.GetMultipleFiles();
            //Message = $"{selectedFiles.Count} file(s) selected";
        }
                
    }

}

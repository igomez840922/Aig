using Aig.FarmacoVigilancia.Events.Attachments;
using Aig.FarmacoVigilancia.Events.Country;
using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel;
using DataModel.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Net.Mail;
using System.Text.Json;

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
        [Inject]
        IApiConnectionFileUploadService apiConnectionFileUploadService { get; set; }

        private JsonSerializerOptions _options;

        [Parameter]
        public DataModel.AttachmentTB attachment { get; set; } = null;

        IBrowserFile selectedFile { get; set; }

        int maxFileSize { get; set; } = 1024 * 1024 * 50;

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
            try
            {

                if (selectedFile != null)
                {
                    _options = _options != null ? _options : new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    if (selectedFile.Size > maxFileSize)
                    {
                        await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["YouExceedMaximumSizeOf"] + " 50MB");
                        return;
                    }

                    ////await using FileStream fs = new(path, FileMode.Create);
                    ////await selectedFile.OpenReadStream().CopyToAsync(fs);
                    //Stream stream = selectedFile.OpenReadStream(maxFileSize);
                    var fileName = string.Format("{0}.{1}", Guid.NewGuid().ToString(), selectedFile.Name.Split(".").LastOrDefault());
                    var path = System.IO.Path.Combine(env.WebRootPath, "files", fileName);
                    ////$"{env.WebRootPath}\\{selectedFile.Name}";
                    //FileStream fs = File.Create(path);
                    //await stream.CopyToAsync(fs);
                    //stream.Close();
                    //fs.Close();
                                        
                    await using FileStream writeStream = new(path, FileMode.Create);
                    using var readStream = selectedFile.OpenReadStream(maxFileSize);
                    var bytesRead = 0;
                    var totalRead = 0;
                    var buffer = new byte[1024 * 10];

                    while ((bytesRead = await readStream.ReadAsync(buffer)) != 0)
                    {
                        totalRead += bytesRead;

                        await writeStream.WriteAsync(buffer, 0, bytesRead);
                        //progressPercent = Decimal.Divide(totalRead, file.Size);
                        //StateHasChanged();
                    }

                    attachment.AbsolutePath = path;
                    attachment.Url = string.Format("/files/{0}", fileName);
                    attachment.FileName = fileName;

                    await bus.Publish(new AttachmentsAddEdit_CloseEvent() { Attachment = attachment });
                    return;
                    //////////////////////////////////
                    ///

                    //try
                    //{
                    //    //var file = e.File;

                    //    // Just load into .NET memory to show it can be done
                    //    // Alternatively it could be saved to disk, or parsed in memory, or similar
                    //    var ms = new MemoryStream();
                    //    await selectedFile.OpenReadStream(maxFileSize).CopyToAsync(ms);
                    //    //status = $"Finished loading {file.Size} bytes from {file.Name}";
                    //    var content = new MultipartFormDataContent { { new ByteArrayContent(ms.GetBuffer()), "\"upload\"", selectedFile.Name } };
                    //    var result = await apiConnectionFileUploadService.Client.PostAsync("FileUpload/UploadFile", content);

                    //    var resultContent = await result.Content.ReadAsStringAsync();
                    //    var model = JsonSerializer.Deserialize<FileUploadResult>(resultContent, _options);
                    //    if (result.IsSuccessStatusCode)
                    //    {
                    //        attachment.AbsolutePath = model.AbsolutePath;
                    //        attachment.Url = model.Url;
                    //        attachment.FileName = model.FileName;

                    //        await bus.Publish(new AttachmentsAddEdit_CloseEvent() { Attachment = attachment });
                    //        return;
                    //    }
                    //    else
                    //    {
                    //        //await jsRuntime.InvokeVoidAsync("ShowError", result.Content.); return;
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    await jsRuntime.InvokeVoidAsync("ShowError", ex.Message); return;
                    //}
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

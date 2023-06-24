using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Pages.Inspections;
using Aig.Auditoria.Services;
using BlazorComponentBus;
using DataModel;
using DataModel.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Mobsites.Blazor;
using System.Net.Mail;

namespace Aig.Auditoria.Components.Inspections._10__AperturaFabCosmetico
{
    public partial class Cap04
    {
        [Inject]
        IInspectionsService inspeccionService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }

        [Parameter]
        public long Id { get; set; }
        DataModel.AUD_InspeccionTB Inspeccion { get; set; } = null;


        private EditContext? editContext;
        private System.Timers.Timer timer = new(60 * 1000);
        bool exit { get; set; } = false;

        bool openAttachment { get; set; } = false;
        AttachmentTB attachment { get; set; } = null;


        protected async override Task OnInitializedAsync()
        {
            timer.Elapsed += (sender, eventArgs) => {
                _ = InvokeAsync(() =>
                {
                    SaveData();
                });
            };
            timer.Start();

            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);

            base.OnInitialized();
        }

        public void Dispose()
        {
            timer?.Dispose();

            bus.UnSubscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
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
            
            Inspeccion = await inspeccionService.Get(Id);
            if (Inspeccion != null)
            {
                editContext = editContext != null ? editContext : new(Inspeccion);

                Inspeccion.InspAperFabricanteCosmetMed.ProdFabrican = Inspeccion.InspAperFabricanteCosmetMed.ProdFabrican != null ? Inspeccion.InspAperFabricanteCosmetMed.ProdFabrican : new AUD_InspAperFabricanteProdFabrican();
            }
            else { Cancel(); }

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            try
            {
                var result = await inspeccionService.Save_AperFabricanteCosmeticosDesin_Cap4(Inspeccion);
                if (result != null)
                {
                    await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                    Inspeccion = result;

                    if (exit)
                        await bus.Publish(new Aig.Auditoria.Events.Inspections.ChapterChangeEvent { Inspeccion = Inspeccion });
                }
                else
                    await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
            }
            catch (Exception ex)
            {
                await jsRuntime.InvokeVoidAsync("ShowError", ex.Message);
            }
            finally
            {
                await this.InvokeAsync(StateHasChanged);
            }
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.Auditoria.Events.Inspections.ChapterChangeEvent { Inspeccion = null });
            await this.InvokeAsync(StateHasChanged);
        }


        //Add New Attachment
        protected async Task OpenAttachment(AttachmentTB _attachment = null)
        {
            bus.Subscribe<Aig.Auditoria.Events.Attachments.AttachmentsAddEdit_CloseEvent>(AttachmentsAddEdit_CloseEventHandler);

            attachment = _attachment != null ? _attachment : new AttachmentTB();
            openAttachment = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //RemoveAttachment
        protected async Task RemoveAttachment(AttachmentTB attachment)
        {
            if (attachment != null)
            {
                try
                {
                    File.Delete(attachment.AbsolutePath);
                }
                catch { }

                Inspeccion.InspAperFabricanteCosmetMed.ProdFabrican.LAttachments.Remove(attachment);
                this.InvokeAsync(StateHasChanged);
            }
        }
        //ON CLOSE ATTACHMENT
        private void AttachmentsAddEdit_CloseEventHandler(MessageArgs args)
        {
            openAttachment = false;

            bus.UnSubscribe<Aig.Auditoria.Events.Attachments.AttachmentsAddEdit_CloseEvent>(AttachmentsAddEdit_CloseEventHandler);

            var message = args.GetMessage<Aig.Auditoria.Events.Attachments.AttachmentsAddEdit_CloseEvent>();

            if (message.Attachment != null)
            {
                //message.Attachment.InspeccionId = Inspeccion.Id;
                Inspeccion.InspAperFabricanteCosmetMed.ProdFabrican.LAttachments = Inspeccion.InspAperFabricanteCosmetMed.ProdFabrican.LAttachments != null ? Inspeccion.InspAperFabricanteCosmetMed.ProdFabrican.LAttachments : new List<AttachmentTB>();

                Inspeccion.InspAperFabricanteCosmetMed.ProdFabrican.LAttachments.Add(message.Attachment);
            }

            this.InvokeAsync(StateHasChanged);
        }


    }

}

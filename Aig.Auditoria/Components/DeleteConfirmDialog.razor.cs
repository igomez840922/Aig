using Aig.Auditoria.Events.DeleteConfirmationDlg;
using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.Auditoria.Components
{
    public partial class DeleteConfirmDialog
    {
        [Inject]
        IProfileService profileService { get; set; }

        bool OpenDialog { get; set; }
        string Caption { get; set; }
        string Message { get; set; } 

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<DeleteConfirmationOpenEvent>(DeleteConfirmationOpenEventHandler);

            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await getUserLanguaje();
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

        //OPEN MODAL TO ADD/Edit new payment order
        private void DeleteConfirmationOpenEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<DeleteConfirmationOpenEvent>();

            Caption = message.Caption;
            Message = message.Message;

            OpenDialog = true;

            this.InvokeAsync(StateHasChanged);
        }


        /// <summary>
        /// Saving Data
        /// </summary>

        protected async Task OptionYes()
        {
            OpenDialog = false;

            await bus.Publish(new DeleteConfirmationCloseEvent {  YesNo = true });           
        }

        protected async Task OptionNo()
        {
            OpenDialog = false;
            await bus.Publish(new DeleteConfirmationCloseEvent { YesNo = false });
            await this.InvokeAsync(StateHasChanged);
        }

    }

}

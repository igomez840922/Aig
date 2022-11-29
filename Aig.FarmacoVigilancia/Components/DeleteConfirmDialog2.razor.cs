using Aig.FarmacoVigilancia.Events.DeleteConfirmationDlg;
using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using Microsoft.AspNetCore.Components;

namespace Aig.FarmacoVigilancia.Components
{    
    public partial class DeleteConfirmDialog2
    {
        [Inject]
        IProfileService profileService { get; set; }

        [Parameter]
        public string Caption { get; set; } = "Confirmar Desición";
        [Parameter]
        public string Message { get; set; } = "Está seguro desea eliminar el dato seleccionado?";

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
            }
        }

        //CHANGE LANGUAJE
        protected async Task getUserLanguaje(string language = null)
        {
            language = string.IsNullOrEmpty(language) ? await profileService.GetLanguage() : language;
            languageContainerService.SetLanguage(System.Globalization.CultureInfo.GetCultureInfo(language));
            this.InvokeAsync(StateHasChanged);
        }
        private void LanguageChangeEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<LanguageChangeEvent>();

            getUserLanguaje(message.Language);
        }

        /// <summary>
        /// Saving Data
        /// </summary>

        protected async Task OptionYes()
        {
            await bus.Publish(new DeleteConfirmationCloseEvent { YesNo = true });
        }

        protected async Task OptionNo()
        {
            await bus.Publish(new DeleteConfirmationCloseEvent { YesNo = false });
        }

    }

}

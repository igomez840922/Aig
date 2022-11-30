using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using Microsoft.AspNetCore.Components;

namespace Aig.FarmacoVigilancia.Components.FT
{
    public partial class AddEditNotification
    {
        [Inject]
        IProfileService profileService { get; set; }

        [Parameter]
        public DataModel.FMV_FtNotificacionTB Notification { get; set; } = null;

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

            await this.InvokeAsync(StateHasChanged);
        }


        /// <summary>
        /// Saving Data
        /// </summary>

        protected async Task SaveData()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.FTNotification.AddEdit_CloseEvent { Data = Notification });
            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task Cancel()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.FTNotification.AddEdit_CloseEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }

    }

}

using Aig.FarmacoVigilancia.Nomenclators;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using DataModel.Helper;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Aig.FarmacoVigilancia.Events.Language;

namespace Aig.FarmacoVigilancia.Components.Ram2
{
    public partial class Concominante
    {

        [Inject]
        IProfileService profileService { get; set; }

        [Parameter]
        public DataModel.FMV_RamFarmacoConcominante Data { get; set; }


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

        //Save Data and Close
        protected async Task SaveData()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.RamConcominante.AddEdit_Event { Data = Data });
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.RamConcominante.AddEdit_Event { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }


    }

}

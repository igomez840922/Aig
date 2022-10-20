using Aig.Auditoria.Events.Country;
using Aig.Auditoria.Events.Establishments;
using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.Auditoria.Components.Contries
{    
    public partial class AddEditCountry
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        ICountriesService countriesService { get; set; }
        bool OpenDialog { get; set; }
        DataModel.PaisTB Pais { get; set; } = null;

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<CountryAddEdit_OpenEvent>(CountryAddEdit_OpenEventHandler);

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

        //OPEN MODAL TO ADD/Edit 
        private void CountryAddEdit_OpenEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<CountryAddEdit_OpenEvent>();

            Pais = message.Data != null ? message.Data : new DataModel.PaisTB();

            OpenDialog = true;

            this.InvokeAsync(StateHasChanged);
        }


        /// <summary>
        /// Saving Data
        /// </summary>

        //Save Data and Close
        protected async Task SaveData()
        {
            var result = await countriesService.Save(Pais);
            if (result != null)
            {
                OpenDialog = false;

                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Pais = result;
                await bus.Publish(new CountryAddEdit_CloseEvent { });

                await this.InvokeAsync(StateHasChanged);
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            OpenDialog = false;
            await bus.Publish(new CountryAddEdit_CloseEvent { });
            await this.InvokeAsync(StateHasChanged);
        }


    }

}

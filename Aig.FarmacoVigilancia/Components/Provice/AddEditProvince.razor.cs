using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Events.Province;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.FarmacoVigilancia.Components.Provice
{    
    public partial class AddEditProvince
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        ICountriesService countriesService { get; set; }
        [Inject]
        IProvicesService provicesService { get; set; }
        bool OpenDialog { get; set; }

        List<PaisTB> LPaises { get; set; }

        DataModel.ProvinciaTB Provincia { get; set; } = null;

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<ProvinceAddEdit_OpenEvent>(ProvinceAddEdit_OpenEventHandler);

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

        private async Task FetchData()
        {
            if(LPaises== null|| LPaises.Count <=0)
            {
                LPaises = await countriesService.GetAll();
            }

            await this.InvokeAsync(StateHasChanged);
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
        private void ProvinceAddEdit_OpenEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<ProvinceAddEdit_OpenEvent>();

            Provincia = message.Data != null ? message.Data : new DataModel.ProvinciaTB();

            OpenDialog = true;

            this.InvokeAsync(StateHasChanged);
        }


        /// <summary>
        /// Saving Data
        /// </summary>

        //Save Data and Close
        protected async Task SaveData()
        {
            var result = await provicesService.Save(Provincia);
            if (result != null)
            {
                OpenDialog = false;

                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Provincia = result;
                await bus.Publish(new ProvinceAddEdit_CloseEvent { });

                await this.InvokeAsync(StateHasChanged);
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            OpenDialog = false;
            await bus.Publish(new ProvinceAddEdit_CloseEvent { });
            await this.InvokeAsync(StateHasChanged);
        }


    }

}

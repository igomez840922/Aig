using Aig.FarmacoVigilancia.Events.District;
using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Events.Province;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel;
using DocumentFormat.OpenXml.EMMA;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.FarmacoVigilancia.Components.District
{   
    public partial class AddEditDistrict
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        ICountriesService countriesService { get; set; }
        [Inject]
        IProvicesService provicesService { get; set; }
        [Inject]
        IDistrictService districtService { get; set; }
        bool OpenDialog { get; set; }

        List<PaisTB> LPaises { get; set; }
        List<ProvinciaTB> LProvincias { get; set; }

        long IdPais { get; set; }
        long IdProvincia { get; set; }
        DataModel.DistritoTB Distrito { get; set; } = null;

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<DistrictAddEdit_OpenEvent>(DistrictAddEdit_OpenEventHandler);

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
            if (LPaises == null || LPaises.Count <= 0)
            {
                LPaises = await countriesService.GetAll();
            }

            IdPais = Distrito?.Provincia?.Pais?.Id ?? 0;
            IdProvincia = 0;
            if (IdPais > 0)
            {
                LProvincias = LPaises.Where(x => x.Id == IdPais).FirstOrDefault()?.LProvincia?.ToList();
                IdProvincia = LProvincias.Where(x => x.Id == (Distrito?.ProvinciaId??0)).FirstOrDefault()?.Id ?? 0;
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
        private async void DistrictAddEdit_OpenEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<DistrictAddEdit_OpenEvent>();

            Distrito = message.Data != null ? message.Data : new DistritoTB() { Provincia = new ProvinciaTB() { Pais = new PaisTB() } };

            OpenDialog = true;

            await FetchData();
            //this.InvokeAsync(StateHasChanged);
        }


        /// <summary>
        /// Saving Data
        /// </summary>

        //Save Data and Close
        protected async Task SaveData()
        {
            Distrito.Provincia = null;
            Distrito.ProvinciaId = IdProvincia;
            if (Distrito.ProvinciaId != null && Distrito.ProvinciaId > 0)
            {
                Distrito.Provincia = await provicesService.Get(IdProvincia);
            }
            var result = await districtService.Save(Distrito);
            if (result != null)
            {
                OpenDialog = false;

                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Distrito = result;
                await bus.Publish(new DistrictAddEdit_CloseEvent { });

                await this.InvokeAsync(StateHasChanged);
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            OpenDialog = false;
            await bus.Publish(new DistrictAddEdit_CloseEvent { });
            await this.InvokeAsync(StateHasChanged);
        }


        protected async Task OnCountryChange(long Id)
        {
            IdPais = Id;
            LProvincias = LPaises.Where(x => x.Id == IdPais).FirstOrDefault()?.LProvincia;
            IdProvincia = LProvincias?.FirstOrDefault()?.Id??0;
            Distrito.ProvinciaId = IdProvincia > 0? IdProvincia: null;
        }
        protected async Task OnProvincesChange(long Id)
        {
            IdProvincia = Id;
            //LProvincias = LPaises.Where(x => x.Id == IdPais).FirstOrDefault()?.LProvincia;
            //IdProvincia = 0;
            Distrito.ProvinciaId = IdProvincia > 0 ? IdProvincia : null;
        }

    }

}

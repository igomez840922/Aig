using Aig.FarmacoVigilancia.Events.Corregimiento;
using Aig.FarmacoVigilancia.Events.District;
using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.FarmacoVigilancia.Components.Corregimiento
{
    public partial class AddEditCorregimiento
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        ICountriesService countriesService { get; set; }
        [Inject]
        IProvicesService provicesService { get; set; }
        [Inject]
        IDistrictService districtService { get; set; }
        [Inject]
        ICorregimientoService corregimientoService { get; set; }
        bool OpenDialog { get; set; }

        List<PaisTB> LPaises { get; set; }
        List<ProvinciaTB> LProvincias { get; set; }
        List<DistritoTB> LDistrito { get; set; }

        long IdPais { get; set; }
        long IdProvincia { get; set; }
        long IdDistrito { get; set; }
        DataModel.CorregimientoTB Corregimiento { get; set; } = null;

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<CorregimientoAddEdit_OpenEvent>(CorregimientoAddEdit_OpenEventHandler);

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

            IdPais = Corregimiento?.Distrito?.Provincia?.Pais?.Id ?? 0;
            IdProvincia = 0;
            IdDistrito = 0;
            if (IdPais > 0)
            {
                LProvincias = LPaises.Where(x => x.Id == IdPais).FirstOrDefault()?.LProvincia?.ToList();
                IdProvincia = LProvincias.Where(x => x.Id == (Corregimiento.Distrito?.ProvinciaId ?? 0)).FirstOrDefault()?.Id ?? 0;
                if (IdProvincia > 0)
                {
                    LDistrito = LProvincias.Where(x => x.Id == IdProvincia).FirstOrDefault()?.LDistritos?.ToList();
                    IdDistrito = LDistrito.Where(x => x.Id == (Corregimiento.DistritoId ?? 0)).FirstOrDefault()?.Id ?? 0;
                }
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
        private async void CorregimientoAddEdit_OpenEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<CorregimientoAddEdit_OpenEvent>();

            Corregimiento = message.Data != null ? message.Data : new CorregimientoTB() { Distrito = new DistritoTB() { Provincia = new ProvinciaTB() { Pais = new PaisTB() } } };

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
            Corregimiento.Distrito = null;
            Corregimiento.DistritoId = IdDistrito;
            if (Corregimiento.DistritoId!=null && Corregimiento.DistritoId > 0)
            {
                Corregimiento.Distrito = await districtService.Get(IdDistrito);
            }
            var result = await corregimientoService.Save(Corregimiento);
            if (result != null)
            {
                OpenDialog = false;

                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Corregimiento = result;
                await bus.Publish(new CorregimientoAddEdit_CloseEvent { });

                await this.InvokeAsync(StateHasChanged);
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            OpenDialog = false;
            await bus.Publish(new CorregimientoAddEdit_CloseEvent { });
            await this.InvokeAsync(StateHasChanged);
        }


        protected async Task OnCountryChange(long Id)
        {
            IdPais = Id;
            LProvincias = LPaises.Where(x => x.Id == IdPais).FirstOrDefault()?.LProvincia;
            IdProvincia = LProvincias?.FirstOrDefault()?.Id ?? 0;
            LDistrito = LProvincias.Where(x => x.Id == IdProvincia).FirstOrDefault()?.LDistritos;
            IdDistrito = LDistrito?.FirstOrDefault()?.Id ?? 0;
            Corregimiento.DistritoId = IdDistrito > 0 ? IdDistrito : null;
        }
        protected async Task OnProvincesChange(long Id)
        {
            IdProvincia = Id;
            LDistrito = LProvincias.Where(x => x.Id == IdProvincia).FirstOrDefault()?.LDistritos;
            IdDistrito = LDistrito?.FirstOrDefault()?.Id ?? 0; 
            Corregimiento.DistritoId = IdDistrito > 0 ? IdDistrito : null;
        }
        protected async Task OnDistrictChange(long Id)
        {
            IdDistrito = Id;
            Corregimiento.DistritoId = IdDistrito > 0 ? IdDistrito : null;
        }
    }

}

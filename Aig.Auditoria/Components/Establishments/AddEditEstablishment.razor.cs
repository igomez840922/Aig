using Aig.Auditoria.Data;
using Aig.Auditoria.Events.Establishments;
using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.Auditoria.Components.Establishments
{
    //AGREGAR O EDITAR PRODUCTOS AL FORMULARIO
    public partial class AddEditEstablishment
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IEstablishmentsService establishmentsService { get; set; }

        [Inject]
        IProvicesService provicesService { get; set; }
        [Inject]
        IDistrictService districtService { get; set; }
        [Inject]
        ICorregimientoService corregimientoService { get; set; }
                
        List<ProvinciaTB> LProvincias { get; set; }
        List<DistritoTB> LDistritos { get; set; }
        List<CorregimientoTB> LCorregimiento { get; set; }

        long IdProvincia { get; set; }
        long IdDistrito { get; set; }
        long IdCorregimiento { get; set; }

        bool OpenDialog { get; set; }
        DataModel.AUD_EstablecimientoTB Establecimiento { get; set; } = null;

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<EstablishmentsAddEdit_OpenEvent>(EstablishmentsAddEdit_OpenEventHandler);

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
            if (LProvincias == null || LProvincias.Count <= 0)
            {
                LProvincias = await provicesService.GetAll();
            }

            IdProvincia = Establecimiento?.ProvinciaId ?? 0;//?? LProvincias?.FirstOrDefault()?.Id??0;
            IdDistrito = 0;
            IdCorregimiento = 0;
            if (IdProvincia > 0)
            {
                LDistritos = LProvincias.Where(x => x.Id == IdProvincia).FirstOrDefault()?.LDistritos?.ToList()??null;
                IdDistrito = LDistritos?.Where(x => x.Id == (Establecimiento?.DistritoId ?? 0)).FirstOrDefault()?.Id ?? LDistritos?.FirstOrDefault()?.Id??0;
                if (IdDistrito > 0)
                {
                    LCorregimiento = LDistritos.Where(x => x.Id == IdDistrito).FirstOrDefault()?.LCorregimientos?.ToList() ?? null;
                    IdCorregimiento = LCorregimiento?.Where(x => x.Id == (Establecimiento?.CorregimientoId ?? 0)).FirstOrDefault()?.Id ?? LCorregimiento?.FirstOrDefault()?.Id??0;
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
        private void EstablishmentsAddEdit_OpenEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<EstablishmentsAddEdit_OpenEvent>();

            Establecimiento = message.Data != null ? message.Data : new DataModel.AUD_EstablecimientoTB();

            OpenDialog = true;

            FetchData();
        }


        /// <summary>
        /// Saving Data
        /// </summary>

        //Save Data and Close
        protected async Task SaveData()
        {
            if (Establecimiento.ProvinciaId != null && Establecimiento.ProvinciaId > 0)
            {
                Establecimiento.Provincia = await provicesService.Get(Establecimiento.ProvinciaId.Value);
            }
            if (Establecimiento.DistritoId != null && Establecimiento.DistritoId > 0)
            {
                Establecimiento.Distrito = await districtService.Get(Establecimiento.DistritoId.Value);
            }
            if (Establecimiento.CorregimientoId != null && Establecimiento.CorregimientoId > 0)
            {
                Establecimiento.Corregimiento = await corregimientoService.Get(Establecimiento.CorregimientoId.Value);
            }

            var result = await establishmentsService.Save(Establecimiento);
            if (result != null)
            {
                OpenDialog = false;

                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Establecimiento = result;
                await bus.Publish(new EstablishmentsAddEdit_CloseEvent { });

                await this.InvokeAsync(StateHasChanged);
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            OpenDialog = false;
            await bus.Publish(new EstablishmentsAddEdit_CloseEvent { });
            await this.InvokeAsync(StateHasChanged);
        }


        protected async Task OnProvinceChange(long Id)
        {
            IdProvincia = Id;
            LDistritos = LProvincias?.Where(x => x.Id == IdProvincia).FirstOrDefault()?.LDistritos??null;
            IdDistrito = LDistritos?.FirstOrDefault()?.Id ?? 0;
            LCorregimiento = LDistritos?.Where(x => x.Id == IdDistrito).FirstOrDefault()?.LCorregimientos ?? null;
            IdCorregimiento = LCorregimiento?.FirstOrDefault()?.Id ?? 0;
            Establecimiento.ProvinciaId = IdProvincia > 0 ? IdProvincia : null;
            Establecimiento.DistritoId = IdDistrito > 0 ? IdDistrito : null;
            Establecimiento.CorregimientoId = IdCorregimiento > 0 ? IdCorregimiento : null;
        }
        protected async Task OnDistrictChange(long Id)
        {
            IdDistrito = Id;
            LCorregimiento = LDistritos?.Where(x => x.Id == IdDistrito).FirstOrDefault()?.LCorregimientos ?? null;
            IdCorregimiento = LCorregimiento?.FirstOrDefault()?.Id ?? 0;
            Establecimiento.ProvinciaId = IdProvincia > 0 ? IdProvincia : null;
            Establecimiento.DistritoId = IdDistrito > 0 ? IdDistrito : null;
            Establecimiento.CorregimientoId = IdCorregimiento > 0 ? IdCorregimiento : null;
        }
        protected async Task OnCorregimientoChange(long Id)
        {
            IdCorregimiento = Id;
            Establecimiento.ProvinciaId = IdProvincia > 0 ? IdProvincia : null;
            Establecimiento.DistritoId = IdDistrito > 0 ? IdDistrito : null;
            Establecimiento.CorregimientoId = IdCorregimiento > 0 ? IdCorregimiento : null;
        }
    }
}

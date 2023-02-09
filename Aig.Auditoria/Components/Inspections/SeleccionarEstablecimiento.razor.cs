using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using Aig.Auditoria.Events.Establishments;
using Microsoft.JSInterop;
using Aig.Auditoria.Pages.Inspections;

namespace Aig.Auditoria.Components.Inspections
{
    public partial class SeleccionarEstablecimiento
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

        bool OpenDialog { get; set; }
        [Parameter]
        public DataModel.AUD_DatosEstablecimientoTB Data { get; set; } = null;

        bool showSearchEstablishment { get; set; } = false;

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
            Data = Data != null ? Data : new AUD_DatosEstablecimientoTB();

            LProvincias = LProvincias?.Count>0? LProvincias: await provicesService.GetAll();
            LDistritos = LDistritos?.Count > 0 ? LDistritos : await districtService.GetAll();
            LCorregimiento = LCorregimiento?.Count > 0 ? LCorregimiento : await corregimientoService.GetAll();
            
            OpenDialog = true;

            await this.InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            bus.UnSubscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            OpenDialog = false;
            await bus.Publish(new Aig.Auditoria.Events.SeleccionarEstablecimiento.AddEditEvent { Data = Data });
            await this.InvokeAsync(StateHasChanged);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            OpenDialog = false;
            await bus.Publish(new Aig.Auditoria.Events.SeleccionarEstablecimiento.AddEditEvent { Data=null });
            await this.InvokeAsync(StateHasChanged);
        }


        /////////
        ///        
        protected async Task OpenSearchEstablishment()
        {
            bus.Subscribe<Aig.Auditoria.Events.Establishments.SearchEvent>(Establishments_SearchEventHandler);
            showSearchEstablishment = true;
            await this.InvokeAsync(StateHasChanged);
        }
        private void Establishments_SearchEventHandler(MessageArgs args)
        {
            showSearchEstablishment = false;
            bus.UnSubscribe<Aig.Auditoria.Events.Establishments.SearchEvent>(Establishments_SearchEventHandler);
            var message = args.GetMessage<Aig.Auditoria.Events.Establishments.SearchEvent>();
            if (message.Data != null)
            {
                Data.EstablecimientoId = message.Data.Id;
                Data.Establecimiento = message.Data;
                Data.Direccion = message.Data.Ubicacion;
                Data.Telefono = message.Data.Telefono1 ?? "";
                Data.Correo = message.Data.Email;
                Data.Nombre = message.Data.Nombre;
                Data.NumLicencia = message.Data.NumLicencia;
                Data.AvisoOperaciones = message.Data.AvisoOperaciones;
                Data.Provincia = message.Data.Provincia;
                Data.Distrito = message.Data.Distrito;
                Data.Corregimiento = message.Data.Corregimiento;
                Data.ReciboPago = message.Data.ReciboPago;
            }

            this.InvokeAsync(StateHasChanged);
        }


    }

}


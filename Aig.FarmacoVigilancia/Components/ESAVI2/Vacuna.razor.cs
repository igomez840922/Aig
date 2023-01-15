using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;

namespace Aig.FarmacoVigilancia.Components.ESAVI2
{
    public partial class Vacuna
    {
        [Inject]
        IProfileService profileService { get; set; }

        [Parameter]
        public DataModel.FMV_EsaviVacunaTB Data { get; set; }

        [Inject]
        ITipoVacunaService tipoVacunaService { get; set; }
        List<TipoVacunaTB> ltipoVacuna { get; set; } = new List<TipoVacunaTB>();
        
        [Inject]
        ILabsService labsService { get; set; }
        List<LaboratorioTB> lLaboratorios { get; set; } = new List<LaboratorioTB>();

        bool showSearchMedicine { get; set; } = false;

        protected async override Task OnInitializedAsync()
        {

            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            base.OnInitialized();
        }

        //-----------------------RAM Rules--------------------------------

        #region ESAVI Rules

        protected async Task OnTipoVacunaChange(long? Id)
        {
            try {
                var dat = ltipoVacuna.Where(x => x.Id == Id).FirstOrDefault();

                Data.TipoVacuna = dat;

                //await FetchData();
            }
            catch (Exception ex) { }            
        }

        protected async Task OnLaboratorioChange(long? Id)
        {
            try
            {
                var dat = lLaboratorios.Where(x => x.Id == Id).FirstOrDefault();

                Data.Laboratorio = dat;

                //await FetchData();
            }
            catch (Exception ex) { }           
        }

        #endregion


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
            ltipoVacuna = ltipoVacuna != null && ltipoVacuna.Count > 0 ? ltipoVacuna : await tipoVacunaService.GetAll();
            lLaboratorios = lLaboratorios != null && lLaboratorios.Count > 0 ? lLaboratorios : await labsService.GetAll();
                        
            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.ESAVIVacuna.AddEditEvent { Data = Data });
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.ESAVIVacuna.AddEditEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }


        /////////
        ///        
        protected async Task OpenSearchMedicine()
        {
            bus.Subscribe<Aig.FarmacoVigilancia.Events.SearchMedicines.SearchMedicinesEvent>(MedicineSearchEventHandler);

            showSearchMedicine = true;

            await this.InvokeAsync(StateHasChanged);
        }
        private void MedicineSearchEventHandler(MessageArgs args)
        {
            showSearchMedicine = false;

            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.SearchMedicines.SearchMedicinesEvent>(MedicineSearchEventHandler);

            var message = args.GetMessage<Aig.FarmacoVigilancia.Events.SearchMedicines.SearchMedicinesEvent>();

            if (message.Data != null)
            {
                //Data.RegSanitario = message.Data.numReg;
                Data.VacunaComercial = message.Data.nombre;
                //Data.Presentacion = message.Data.presentacion;
                //Data.Concentracion = message.Data.concentracion;
                //Data.FormaFarmaceutica = message.Data.formaFarmaceutica?.nombre ?? "";
                Data.RegSanitario = string.IsNullOrEmpty(message.Data.numReg) ? Data.RegSanitario : message.Data.numReg;
                //Data.principio = string.IsNullOrEmpty(message.Data.principio) ? Ips.PrincActivo : message.Data.principio;
            }

            this.InvokeAsync(StateHasChanged);
        }

    }
}

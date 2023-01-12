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

    }
}

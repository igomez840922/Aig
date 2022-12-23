using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;

namespace Aig.FarmacoVigilancia.Components.ESAVI
{
    public partial class AddEditNotification
    {
        [Inject]
        IProfileService profileService { get; set; }
        

        [Parameter]
        public DataModel.FMV_EsaviNotificacionTB Notification { get; set; } = null;

        [Inject]
        ISocService socService { get; set; }
        List<FMV_SocTB> lSoc { get; set; } = new List<FMV_SocTB>();

        [Inject]
        IIntensidadEsaviService intensidadEsaviService { get; set; }
        List<IntensidadEsaviTB> lintensidad { get; set; } = new List<IntensidadEsaviTB>();
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
            lSoc = lSoc != null && lSoc.Count > 0 ? lSoc : await socService.GetAll();

            lintensidad = lintensidad != null && lintensidad.Count > 0 ? lintensidad : await intensidadEsaviService.GetAll();
            ltipoVacuna = ltipoVacuna != null && ltipoVacuna.Count > 0? ltipoVacuna :await tipoVacunaService.GetAll();
            lLaboratorios = lLaboratorios!=null && lLaboratorios.Count > 0 ? lLaboratorios :await labsService.GetAll();

            await this.InvokeAsync(StateHasChanged);
        }


        /// <summary>
        /// Saving Data
        /// </summary>

        protected async Task SaveData()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.ESAVINotification.AddEdit_CloseEvent { Data = Notification });
            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task Cancel()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.ESAVINotification.AddEdit_CloseEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task OnSocChange(long? Id)
        {
            var soc = lSoc.Where(x => x.Id == Id).FirstOrDefault();

            Notification.Soc = soc?.Nombre ?? "";

            //await FetchData();
        }
        protected async Task OnIntensidadChange(long? Id)
        {
            var dat = lintensidad.Where(x => x.Id == Id).FirstOrDefault();

            Notification.IntensidadEsavi = dat;

            //await FetchData();
        }
        protected async Task OnTipoVacunaChange(long? Id)
        {
            var dat = ltipoVacuna.Where(x => x.Id == Id).FirstOrDefault();

            Notification.TipoVacuna = dat;

            //await FetchData();
        }
        protected async Task OnLaboratorioChange(long? Id)
        {
            var dat = lLaboratorios.Where(x => x.Id == Id).FirstOrDefault();

            Notification.Laboratorio = dat;

            //await FetchData();
        }
    }

}

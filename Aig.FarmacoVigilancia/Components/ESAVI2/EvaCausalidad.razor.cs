using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Nomenclators;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using Microsoft.AspNetCore.Components;

namespace Aig.FarmacoVigilancia.Components.ESAVI2
{
    public partial class EvaCausalidad
    {

        [Inject]
        IProfileService profileService { get; set; }


        [Parameter]
        public DataModel.FMV_EsaviVacunaEsaviTB Data { get; set; }


        protected async override Task OnInitializedAsync()
        {

            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            base.OnInitialized();
        }

        //-----------------------RAM Rules--------------------------------

        #region RAM Rules

        protected async Task CheckOtrosCritSeleccion()
        {
            Data.ElegibleEvaluacionCausal = "Regular";
            switch (Data.InvDetalleCaso)
            {
                case DataModel.Helper.enumOpcionSiNo.Si:
                    {
                        if (Data.Gravedad != null && Data.Gravedad.Contains("Grave"))
                        {
                            Data.ElegibleEvaluacionCausal = "Prioridad";
                        }

                        switch (Data.OtrosCriterios)
                        {
                            case DataModel.Helper.enumFMV_EsaviOtroCriterio.NA:
                                {
                                    break;
                                }
                            default:
                                {
                                    Data.ElegibleEvaluacionCausal = "Prioridad";
                                    break;
                                }
                        }
                        break;
                    }
            }
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

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.ESAVIVacunaEsavi.AddEditEvent { Data = Data });
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.ESAVIVacunaEsavi.AddEditEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }


    }

}

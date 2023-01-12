using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;

namespace Aig.FarmacoVigilancia.Components.ESAVI2
{    

    public partial class Esavi
    {

        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        ISocService socService { get; set; }
        [Inject]
        ITerMedraService terMedraService { get; set; }

        [Parameter]
        public DataModel.FMV_EsaviVacunaEsaviTB Data { get; set; }

        [Parameter]
        public List<DataModel.FMV_EsaviVacunaTB> LVacunas { get; set; }

        List<FMV_SocTB> lSoc { get; set; } = new List<FMV_SocTB>();
        List<FMV_TerMedraTB> lTerMedra { get; set; } = new List<FMV_TerMedraTB>();

        [Inject]
        IIntensidadEsaviService intensidadEsaviService { get; set; }
        List<IntensidadEsaviTB> lintensidad { get; set; } = new List<IntensidadEsaviTB>();


        protected async override Task OnInitializedAsync()
        {

            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            base.OnInitialized();
        }

        //-----------------------RAM Rules--------------------------------

        #region RAM Rules



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
            lintensidad = lintensidad != null && lintensidad.Count > 0 ? lintensidad : await intensidadEsaviService.GetAll();
            lSoc = lSoc != null && lSoc.Count > 0 ? lSoc : await socService.GetAll();
            
            await OnSocChange(Data.SocId);

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


        ////////////////////
        ///

        protected async Task OnSocChange(long? Id)
        {
            var soc = lSoc.Where(x => x.Id == Id).FirstOrDefault();
            Data.Soc = soc?.Nombre ?? "";

            lTerMedra = new List<FMV_TerMedraTB>();
            if (Id != null)
            {
                lTerMedra = await terMedraService.FindAll(x => x.SocId == Id);
            }

            //await FetchData();
        }
        protected async Task OnTerMedraChange(long? Id)
        {
            var term = lTerMedra.Where(x => x.Id == Id).FirstOrDefault();

            Data.TerWhoArt = term?.Nombre ?? "";

            //await FetchData();
        }

        void OnRAMDateChange(DateTime? value, string name, string format)
        {
            //UpdateGrado0();
        }
        //private void UpdateGrado0()
        //{   // Grado 0
        //    /* FÓRMULA: Si [farSosDCI]="", [hayRam]="", [fechaTratamiento]="" y [hayRam]="" entonces grado0=""
        //                 sino: Si [farSosDCI]!="", [hayRam]="Sí hay RAM" entonces
        //                            Si [fechaTratamiento]="" o [hayRam]="" entonces grado0=Grado 0
        //                            sino: grado0=""
        //    */
        //    var value = string.Empty;
        //    if (Data.RamType == enumFMV_RAMType.SiRam && Data.FechaTratamiento == null && Data.FechaRam == null)
        //        value = "Grado 0";
        //    Data.Grado = value;
        //}
        private void OnEvoDosisChange(object args)
        {
            if (args != null)
            {
                //var value = args.Value.ToString();
                //Data.EvoDosis = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMEvolucionDosis>(value);
                //UpdateIncongruenciaCondDosisEvo();
            }
        }
        private void OnEvoTerapiaChange(object args)
        {
            if (args != null)
            {
                //var value = args.Value.ToString();
                // Data.EvaluacionCalidadInfo.EvoTerapia = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMEvolucionTerapia>(value);
                //UpdateIncongruenciaCondTerapiaEvo();
            }
        }
        private void OnConReexposicionChange(object args)
        {
            if (args != null)
            {
                //var value = args.Value.ToString();
                //Data.EvaluacionCalidadInfo.ConReexposicion = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMConsecuenciaReexposicion>(value);
                //UpdateIncongruenciaConReex();
            }
        }

        protected async Task OnIntensidadChange(long? Id)
        {
            var dat = lintensidad.Where(x => x.Id == Id).FirstOrDefault();

            Data.IntensidadEsavi = dat;
            Data.Gravedad = dat?.Gravedad ?? "";

            CheckOtrosCritSeleccion();
            //await FetchData();
        }
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

    }

}

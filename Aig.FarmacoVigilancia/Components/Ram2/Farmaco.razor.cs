using Aig.FarmacoVigilancia.Nomenclators;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using DataModel.Helper;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Aig.FarmacoVigilancia.Events.Language;

namespace Aig.FarmacoVigilancia.Components.Ram2
{    
    public partial class Farmaco
    {

        [Inject]
        IProfileService profileService { get; set; }
        
        [Parameter]
        public DataModel.FMV_RamFarmacoTB Data { get; set; }
                
        
        protected async override Task OnInitializedAsync()
        {

            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            base.OnInitialized();
        }

        //-----------------------RAM Rules--------------------------------

        #region RAM Rules

        public void OnAtcChanged()
        {
            Data.SubGrupoTerapeutico = "";
            Data.Atc = Data.Atc?.Replace(" ", "")??"";
            if (!string.IsNullOrEmpty(Data.Atc) && Data.Atc.Length >= 3)
                Data.SubGrupoTerapeutico = Helper.Helper.GetATC2doNivel(Data.Atc);
        }

        void OnFechaTratamientoChange(DateTime? value, string name, string format)
        {
            //UpdateGrado0();
        }

        private void OnConductaDosisChange(object value)
        {
            if (value != null)
            {
                //var value = args.Value.ToString();
                //Data.ConductaDosis = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMConductaDosis>(value);                
            }
            //UpdateIncongruenciaCondDosisEvo();
        }

        private void OnConductaTerapiaChange(object value)
        {
            if (value != null)
            {
                //var value = args.Value.ToString();
                //Data.ConductaTerapia = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMConductaTerapia>(value);
                //UpdateIncongruenciaCondTerapiaEvo();
                //UpdateIncongruenciaCondSuspTerapiaReex();
                //UpdateIncongruenciaCondMantTerapiaReex();
            }            
        }
        private void OnReexposicionChange(object value)
        {
            if (value != null)
            {
                //var value = args.Value.ToString();
                //Data.Reexposicion = DataModel.Helper.Helper.ParseEnum<enumOpcionSiNo>(value);
                //UpdateIncongruenciaCondSuspTerapiaReex();
                //UpdateIncongruenciaCondMantTerapiaReex();
                //UpdateIncongruenciaConReex();
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
            await bus.Publish(new Aig.FarmacoVigilancia.Events.RamFarmaco.AddEdit_Event { Data = Data });
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.RamFarmaco.AddEdit_Event { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }


    }

}

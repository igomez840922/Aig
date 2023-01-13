using Aig.FarmacoVigilancia.Nomenclators;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using DataModel.Helper;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Aig.FarmacoVigilancia.Events.Language;
using System.Text.Json;

namespace Aig.FarmacoVigilancia.Components.Ram2
{
    public partial class EvaCausalidad
    {

        [Inject]
        IProfileService profileService { get; set; }
        

        [Parameter]
        public DataModel.FMV_RamFarmacoRamTB Data { get; set; }
        

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
            
            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.RamFarmacoRam.AddEdit_Event { Data = Data });
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.RamFarmacoRam.AddEdit_Event { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }
                
        ////////////////////
        ///

        private void OnSecTemporalChange(object args)
        {
            Data.Stemp = GetSTEMP(DataModel.Helper.Helper.GetDescription(Data.SecTemporal));
        }
        private int GetSTEMP(string term)
        {
            int value = 0;
            if (string.IsNullOrEmpty(term)) return value;
            var result = Helper.Helper.GetNomenclatorValue("STEMP.json");
            if (string.IsNullOrEmpty(result)) return value;
            var jsonData = JsonSerializer.Deserialize<List<STEMPModel>>(result);
            STEMPModel find;
            if ((find = jsonData!.FirstOrDefault(p => p.STEMP.ToLower() == term.ToLower())) != null)
                value = find.Puntuacion;
            return value;
        }

        private void OnConPrevioChange(object args)
        {
            //var value = args.Value.ToString();
            //Data.EvaluacionCausalidad.ConPrevio = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMConocimientoPrev>(value);
            Data.Cprev = GetCPREV(DataModel.Helper.Helper.GetDescription(Data.ConPrevio));
        }
        private int GetCPREV(string term)
        {
            int value = 0;
            if (string.IsNullOrEmpty(term)) return value;
            var result = Helper.Helper.GetNomenclatorValue("CPREV.json");
            if (string.IsNullOrEmpty(result)) return value;
            var jsonData = JsonSerializer.Deserialize<List<CPREVModel>>(result);
            CPREVModel find;
            if ((find = jsonData!.FirstOrDefault(p => p.CPREV.ToLower() == term.ToLower())) != null)
                value = find.Puntuacion;
            return value;
        }

        private void OnEfecRetiradaChange(object args)
        {
            //var value = args.Value.ToString();
            //Data.EvaluacionCausalidad.EfecRetirada = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMEfectoRetirada>(value);
            Data.Reti = GetRETI(DataModel.Helper.Helper.GetDescription(Data.EfecRetirada));
        }
        private int GetRETI(string term)
        {
            int value = 0;
            if (string.IsNullOrEmpty(term)) return value;
            var result = Helper.Helper.GetNomenclatorValue("RETI.json");
            if (string.IsNullOrEmpty(result)) return value;
            var jsonData = JsonSerializer.Deserialize<List<RETIModel>>(result);
            RETIModel find;
            if ((find = jsonData!.FirstOrDefault(p => p.RETI.ToLower() == term.ToLower())) != null)
                value = find.Puntuacion;
            return value;
        }

        private void OnEfecReexposicionChange(object args)
        {
            //var value = args.Value.ToString();
            //Data.EvaluacionCausalidad.EfecReexposicion = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMEfectoReexposicion>(value);
            Data.Reex = GetREEXP(DataModel.Helper.Helper.GetDescription(Data.EfecReexposicion));
        }
        private int GetREEXP(string term)
        {
            int value = 0;
            if (string.IsNullOrEmpty(term)) return value;
            var result = Helper.Helper.GetNomenclatorValue("REEXP.json");
            if (string.IsNullOrEmpty(result)) return value;
            var jsonData = JsonSerializer.Deserialize<List<REEXPModel>>(result);
            REEXPModel find;
            if ((find = jsonData!.FirstOrDefault(p => p.REEXP.ToLower() == term.ToLower())) != null)
                value = find.Puntuacion;
            return value;
        }

        private void OnCausasAlterChange(object args)
        {
            //var value = args.Value.ToString();
            //Data.EvaluacionCausalidad.CausasAlter = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMCausaAlternat>(value);
            Data.Alter = GetALTER(DataModel.Helper.Helper.GetDescription(Data.CausasAlter));
        }
        private int GetALTER(string term)
        {
            int value = 0;
            if (string.IsNullOrEmpty(term)) return value;
            var result = Helper.Helper.GetNomenclatorValue("ALTER.json");
            if (string.IsNullOrEmpty(result)) return value;
            var jsonData = JsonSerializer.Deserialize<List<ALTERModel>>(result);
            ALTERModel find;
            if ((find = jsonData!.FirstOrDefault(p => p.ALTER.ToLower() == term.ToLower())) != null)
                value = find.Puntuacion;
            return value;
        }

        private void OnFactContribuyentesChange(object args)
        {
            //var value = args.Value.ToString();
            //Data.EvaluacionCausalidad.FactContribuyentes = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMFactContribuyente>(value);
            Data.Facon = GetFACON(DataModel.Helper.Helper.GetDescription(Data.FactContribuyentes));
        }
        private int GetFACON(string term)
        {
            int value = 0;
            if (string.IsNullOrEmpty(term)) return value;
            var result = Helper.Helper.GetNomenclatorValue("FACON.json");
            if (string.IsNullOrEmpty(result)) return value;
            var jsonData = JsonSerializer.Deserialize<List<FACONModel>>(result);
            FACONModel find;
            if ((find = jsonData!.FirstOrDefault(p => p.FACON.ToLower() == term.ToLower())) != null)
                value = find.Puntuacion;
            return value;
        }

        private void OnExpComplementariasChange(object args)
        {
            //var value = args.Value.ToString();
            //Data.EvaluacionCausalidad.ExpComplementarias = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMExploracionContemp>(value);
            Data.Xplc = GetXPLC(DataModel.Helper.Helper.GetDescription(Data.ExpComplementarias));
        }
        private int GetXPLC(string term)
        {
            int value = 0;
            if (string.IsNullOrEmpty(term)) return value;
            var result = Helper.Helper.GetNomenclatorValue("XPLC.json");
            if (string.IsNullOrEmpty(result)) return value;
            var jsonData = JsonSerializer.Deserialize<List<XPLCModel>>(result);
            XPLCModel find;
            if ((find = jsonData!.FirstOrDefault(p => p.XPLC.ToLower() == term.ToLower())) != null)
                value = find.Puntuacion;
            return value;
        }

        private void OnIntRamChange(object args)
        {
            //var value = args.Value.ToString();
            //Data.EvaluacionCausalidad.IntRam = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMIntensidad>(value);
            Data.Gravedad = GetGRAVEDAD(DataModel.Helper.Helper.GetDescription(Data.IntRam));
        }
        private string GetGRAVEDAD(string term)
        {
            string value = string.Empty;
            if (string.IsNullOrEmpty(term)) return value;
            var result = Helper.Helper.GetNomenclatorValue("GRAVEDAD.json");
            if (string.IsNullOrEmpty(result)) return value;
            var jsonData = JsonSerializer.Deserialize<List<GRAVEDADModel>>(result);
            GRAVEDADModel find;
            if ((find = jsonData!.FirstOrDefault(p => p.RAM.ToLower() == term.ToLower())) != null)
                value = find.Gravedad;
            return value;
        }
    }


}

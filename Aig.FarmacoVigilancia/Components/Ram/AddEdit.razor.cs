using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Nomenclators;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using DataModel;
using DataModel.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;

namespace Aig.FarmacoVigilancia.Components.Ram
{   

    public partial class AddEdit
    {
        [Inject]
        IRamService ramService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IWorkerPersonService evaluatorService { get; set; }
        [Inject]
        IPdfGenerationService pdfGenerationService { get; set; }
        [Inject]
        ISocService socService { get; set; }

        [Parameter]
        public DataModel.FMV_RamTB Data { get; set; }
        List<PersonalTrabajadorTB> lEvaluators { get; set; } = new List<PersonalTrabajadorTB>();
        List<FMV_SocTB> lSoc { get; set; } = new List<FMV_SocTB>();

        bool OpenAddEditNotification { get; set; } = false;
        FMV_RamNotificacionTB Notificacion { get; set; } = null;

        [Inject]
        ITipoInstitucionService tipoInstitucionService { get; set; }
        [Inject]
        IProvicesService provicesService { get; set; }
        [Inject]
        IDestinyInstituteService destinyInstituteService { get; set; }

        List<TipoInstitucionTB> lTipoInstitucion { get; set; } = new List<TipoInstitucionTB>();
        List<ProvinciaTB> lProvincias { get; set; } = new List<ProvinciaTB>();
        List<InstitucionDestinoTB> lInstitucionDestino { get; set; } = new List<InstitucionDestinoTB>();

        protected async override Task OnInitializedAsync()
        {
            Data.EvaluacionCausalidad.Stemp = GetSTEMP(DataModel.Helper.Helper.GetDescription(Data.EvaluacionCausalidad.SecTemporal));
            Data.EvaluacionCausalidad.Cprev = GetCPREV(DataModel.Helper.Helper.GetDescription(Data.EvaluacionCausalidad.ConPrevio));
            Data.EvaluacionCausalidad.Reti = GetRETI(DataModel.Helper.Helper.GetDescription(Data.EvaluacionCausalidad.EfecRetirada));
            Data.EvaluacionCausalidad.Reex = GetRETI(DataModel.Helper.Helper.GetDescription(Data.EvaluacionCausalidad.EfecReexposicion));
            Data.EvaluacionCausalidad.Alter = GetALTER(DataModel.Helper.Helper.GetDescription(Data.EvaluacionCausalidad.CausasAlter));
            Data.EvaluacionCausalidad.Facon = GetFACON(DataModel.Helper.Helper.GetDescription(Data.EvaluacionCausalidad.FactContribuyentes));
            Data.EvaluacionCausalidad.Xplc = GetXPLC(DataModel.Helper.Helper.GetDescription(Data.EvaluacionCausalidad.ExpComplementarias));
            Data.EvaluacionCausalidad.Gravedad = GetGRAVEDAD(DataModel.Helper.Helper.GetDescription(Data.EvaluacionCausalidad.IntRam));

            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            base.OnInitialized();
        }

        //-----------------------Nomenclators--------------------------------
      
     
        public void OnAtcChanged()
        {
            Data.SubGrupoTerapeutico = GetATC2doNivel(Data.Atc);
        }

        private string GetATC2doNivel(string term){
            string value = string.Empty;
            if (string.IsNullOrEmpty(term)) return value;
            var search = term.Trim();
            if(search.Length>3)
               search = term.Trim()[..3].ToString();
            var result = Helper.Helper.GetNomenclatorValue("ATC2doNivel.json");
            if (string.IsNullOrEmpty(result)) return value;
            var jsonData = JsonSerializer.Deserialize<List<ATC2doNivelModel>>(result);
            ATC2doNivelModel find;
            if ((find = jsonData!.FirstOrDefault(p => p.ATC2doNivel.ToLower().StartsWith(search.ToLower()))) != null)
                value = find.Subgrupo;
            return value;
        }

        private void OnSecTemporalChange(ChangeEventArgs args)
        {
            var value = args.Value.ToString();
            Data.EvaluacionCausalidad.SecTemporal = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMSecuenciaTemp>(value);
            Data.EvaluacionCausalidad.Stemp = GetSTEMP(DataModel.Helper.Helper.GetDescription(Data.EvaluacionCausalidad.SecTemporal));
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

        private void OnConPrevioChange(ChangeEventArgs args)
        {
            var value = args.Value.ToString();
            Data.EvaluacionCausalidad.ConPrevio = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMConocimientoPrev>(value);
            Data.EvaluacionCausalidad.Cprev = GetCPREV(DataModel.Helper.Helper.GetDescription(Data.EvaluacionCausalidad.ConPrevio));
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
        private void OnEfecRetiradaChange(ChangeEventArgs args)
        {
            var value = args.Value.ToString();
            Data.EvaluacionCausalidad.EfecRetirada = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMEfectoRetirada>(value);
            Data.EvaluacionCausalidad.Reti = GetRETI(DataModel.Helper.Helper.GetDescription(Data.EvaluacionCausalidad.EfecRetirada));
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
        private void OnEfecReexposicionChange(ChangeEventArgs args)
        {
            var value = args.Value.ToString();
            Data.EvaluacionCausalidad.EfecReexposicion = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMEfectoReexposicion>(value);
            Data.EvaluacionCausalidad.Reex = GetREEXP(DataModel.Helper.Helper.GetDescription(Data.EvaluacionCausalidad.EfecReexposicion));
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
        private void OnCausasAlterChange(ChangeEventArgs args)
        {
            var value = args.Value.ToString();
            Data.EvaluacionCausalidad.CausasAlter = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMCausaAlternat>(value);
            Data.EvaluacionCausalidad.Alter = GetALTER(DataModel.Helper.Helper.GetDescription(Data.EvaluacionCausalidad.CausasAlter));
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
        private void OnFactContribuyentesChange(ChangeEventArgs args)
        {
            var value = args.Value.ToString();
            Data.EvaluacionCausalidad.FactContribuyentes = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMFactContribuyente>(value);
            Data.EvaluacionCausalidad.Facon = GetFACON(DataModel.Helper.Helper.GetDescription(Data.EvaluacionCausalidad.FactContribuyentes));
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

        private void OnExpComplementariasChange(ChangeEventArgs args)
        {
            var value = args.Value.ToString();
            Data.EvaluacionCausalidad.ExpComplementarias = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMExploracionContemp>(value);
            Data.EvaluacionCausalidad.Xplc = GetXPLC(DataModel.Helper.Helper.GetDescription(Data.EvaluacionCausalidad.ExpComplementarias));
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

        private void OnIntRamChange(ChangeEventArgs args)
        {
            var value = args.Value.ToString();
            Data.EvaluacionCausalidad.IntRam = DataModel.Helper.Helper.ParseEnum<enumFMV_RAMIntensidad>(value);
            Data.EvaluacionCausalidad.Gravedad = GetGRAVEDAD(DataModel.Helper.Helper.GetDescription(Data.EvaluacionCausalidad.IntRam));
        }
        //-----------------------Nomenclators--------------------------------

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
            lEvaluators = lEvaluators != null && lEvaluators.Count > 0 ? lEvaluators : await evaluatorService.GetAll();
            lTipoInstitucion = lTipoInstitucion != null && lTipoInstitucion.Count > 0 ? lTipoInstitucion : await tipoInstitucionService.GetAll();
            lProvincias = lProvincias != null && lProvincias.Count > 0 ? lProvincias : await provicesService.GetAll();

            lInstitucionDestino = await destinyInstituteService.FindAll(x => (Data.TipoInstitucionId != null ? x.TipoInstitucionId == Data.TipoInstitucionId : true) && (Data.ProvinciaId != null ? x.ProvinciaId == Data.ProvinciaId : true));

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            var result = await ramService.Save(Data);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Data = result;

                await bus.Publish(new Aig.FarmacoVigilancia.Events.Ram.AddEdit_CloseEvent { Data = Data });
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.Ram.AddEdit_CloseEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }

        ////Add New Product
        //protected async Task OpenProduct(FMV_RamNotificacionTB notificacion = null)
        //{
        //    bus.Subscribe<Aig.FarmacoVigilancia.Events.RamNotification.AddEdit_CloseEvent>(Notification_AddEditCloseEventHandlerHandler);

        //    Notificacion = notificacion != null ? notificacion : new FMV_RamNotificacionTB() {RamId=Data.Id};
        //    OpenAddEditNotification = true;

        //    await this.InvokeAsync(StateHasChanged);
        //}
        ////Remove Product
        //protected async Task RemoveProduct(FMV_RamNotificacionTB notificacion)
        //{
        //    if (notificacion != null)
        //    {
        //        Data.LNotificaciones.Remove(notificacion);
        //        this.InvokeAsync(StateHasChanged);
        //    }
        //}
        ////ON CLOSE PRODUCT MODAL 
        //private void Notification_AddEditCloseEventHandlerHandler(MessageArgs args)
        //{
        //    bus.UnSubscribe<Aig.FarmacoVigilancia.Events.RamNotification.AddEdit_CloseEvent>(Notification_AddEditCloseEventHandlerHandler);

        //    var message = args.GetMessage<Aig.FarmacoVigilancia.Events.RamNotification.AddEdit_CloseEvent>();

        //    Notificacion = null;
        //    OpenAddEditNotification = false;
        //    if (message.Data != null)
        //    {
        //        Data.LNotificaciones = Data.LNotificaciones != null ? Data.LNotificaciones : new List<FMV_RamNotificacionTB>();
                
        //        if(!Data.LNotificaciones.Contains(message.Data))
        //            Data.LNotificaciones.Add(message.Data);
        //    }

        //    this.InvokeAsync(StateHasChanged);
        //}

        
        protected async Task OnEvaluatorChange(long? Id)
        {
            Data.EvaluadorId = Id;
            Data.Evaluador = lEvaluators.Where(x => x.Id == Id).FirstOrDefault();
        }

        protected async Task OnChangeTipoInstitucion(long? Id)
        {
            Data.TipoInstitucionId = Id;
            Data.TipoInstitucion = lTipoInstitucion.Where(x => x.Id == Id).FirstOrDefault();
            await FetchData();
        }

        protected async Task OnChangeProvincia(long? Id)
        {
            Data.ProvinciaId = Id;
            Data.Provincia = lProvincias.Where(x => x.Id == Id).FirstOrDefault();
            await FetchData();
        }

        protected async Task OnSocChange(long? Id)
        {
            var soc = lSoc.Where(x => x.Id == Id).FirstOrDefault();

            Data.EvaluacionCausalidad.Soc = soc?.Nombre ?? "";

            //await FetchData();
        }
        

    }

}

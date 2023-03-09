using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Pages.IPS;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using DataAccess;
using DataModel;
using DataModel.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.FarmacoVigilancia.Components.FF
{
    public partial class AddEdit
    {
        [Inject]
        IFFService ffService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IWorkerPersonService evaluatorService { get; set; }
        [Inject]
        IPdfGenerationService pdfGenerationService { get; set; }
        [Parameter]
        public DataModel.FMV_FfTB Data { get; set; }
        List<PersonalTrabajadorTB> lEvaluators { get; set; }

        [Inject]
        ITipoInstitucionService tipoInstitucionService { get; set; }
        [Inject]
        IProvicesService provicesService { get; set; }
        [Inject]
        IDestinyInstituteService destinyInstituteService { get; set; }
        [Inject]
        ILabsService labsService { get; set; }
        List<LaboratorioTB> Labs { get; set; } = new List<LaboratorioTB>();

        List<TipoInstitucionTB> lTipoInstitucion { get; set; }
        List<ProvinciaTB> lProvincias { get; set; }
        List<InstitucionDestinoTB> lInstitucionDestino { get; set; }

        bool openAttachment { get; set; } = false;
        AttachmentTB attachment { get; set; } = null;
        bool Exit { get; set; } = false;
        bool showSearchMedicine { get; set; } = false;
        bool showSearchFarmaco { get; set; } = false;

        bool openLote { get; set; } = false;
        FMV_LoteTB lote { get; set; } = null;

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
            lEvaluators = lEvaluators != null && lEvaluators.Count > 0 ? lEvaluators : await evaluatorService.GetAll();
            lTipoInstitucion = lTipoInstitucion != null && lTipoInstitucion.Count > 0 ? lTipoInstitucion : await tipoInstitucionService.GetAll();
            lProvincias = lProvincias != null && lProvincias.Count > 0 ? lProvincias : await provicesService.GetAll();
            Labs = Labs != null && Labs.Count > 0 ? Labs : await labsService.GetAll();

            lInstitucionDestino = await destinyInstituteService.FindAll(x => (Data.TipoInstitucionId != null ? x.TipoInstitucionId == Data.TipoInstitucionId : true) && (Data.ProvinciaId != null ? x.ProvinciaId == Data.ProvinciaId : true));

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            try {
                UpdateGrado();

                //verificar CodigoCNFV
                if (!string.IsNullOrEmpty(Data.CodCNFV))
                {
                    var tmpData = (await ffService.FindAll(x => x.CodCNFV.Contains(Data.CodCNFV) && x.Id != Data.Id)).FirstOrDefault();
                    if (tmpData != null)
                    {
                        await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["El código de CNFV ya existe"]);
                        return;
                    }
                }

                //verificar Cod Externo
                if (!string.IsNullOrEmpty(Data.CodExt))
                {
                    var tmpData = (await ffService.FindAll(x => x.CodExt.Contains(Data.CodExt) && x.Id != Data.Id)).FirstOrDefault();
                    if (tmpData != null)
                    {
                        await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["El código Externo ya existe"]);
                        return;
                    }
                }

                if (Data.RegSanitario != null && string.IsNullOrEmpty(Data.RegSanitario))
                {
                    Data.RegSanitario = "Excepción al Registro Sanitario";
                }

                var result = await ffService.Save(Data);
                if (result != null)
                {
                    await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                    Data = result;

                    if (Exit)
                        await bus.Publish(new Aig.FarmacoVigilancia.Events.FF.AddEdit_CloseEvent { Data = Data });
                }
                else
                    await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
            }
            catch (Exception ex) { }
            finally { Exit = false; }
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.FF.AddEdit_CloseEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }

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

        //Add New Attachment
        protected async Task OpenAttachment(AttachmentTB _attachment = null)
        {
            bus.Subscribe<Aig.FarmacoVigilancia.Events.Attachments.AttachmentsAddEdit_CloseEvent>(AttachmentsAddEdit_CloseEventHandler);

            attachment = _attachment != null ? _attachment : new AttachmentTB();
            openAttachment = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //RemoveAttachment
        protected async Task RemoveAttachment(AttachmentTB attachment)
        {
            if (attachment != null)
            {
                try
                {
                    File.Delete(attachment.AbsolutePath);
                }
                catch { }

                Data.Adjunto.LAttachments.Remove(attachment);
                this.InvokeAsync(StateHasChanged);
            }
        }
        //ON CLOSE ATTACHMENT
        private void AttachmentsAddEdit_CloseEventHandler(MessageArgs args)
        {
            openAttachment = false;

            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.Attachments.AttachmentsAddEdit_CloseEvent>(AttachmentsAddEdit_CloseEventHandler);

            var message = args.GetMessage<Aig.FarmacoVigilancia.Events.Attachments.AttachmentsAddEdit_CloseEvent>();

            if (message.Attachment != null)
            {
                //message.Attachment.InspeccionId = Inspeccion.Id;
                Data.Adjunto = Data.Adjunto != null ? Data.Adjunto : new AttachmentData();
                Data.Adjunto.LAttachments = Data.Adjunto.LAttachments != null ? Data.Adjunto.LAttachments : new List<AttachmentTB>();

                Data.Adjunto.LAttachments.Add(message.Attachment);
            }

            this.InvokeAsync(StateHasChanged);
        }

        //////////////////////
        ///

        public void OnAtcChanged()
        {
            Data.SubGrupoTerapeutico = "";
            Data.ATC = Data.ATC?.Replace(" ", "");
            if (!string.IsNullOrEmpty(Data.ATC) && Data.ATC.Length >= 3)
                Data.SubGrupoTerapeutico = Helper.Helper.GetATC2doNivel(Data.ATC);
        }

        /////////////
        ///
        private void UpdateGrado()
        {            

            string nombreFarmaco = Data.NombreComercial;
            string nombreDci = Data.NombreDci;
            string concent = Data.Concentracion;
            string regSanitario = Data.RegSanitario;
            string formaFarm = Data.FormaFarmaceutica;
            string fabricante = Data.Fabricant?.Nombre??"";
            string lotes = Data.LLotes?.Count > 0?"lotes":null;
            string fechaExp = Data.LLotes?.Where(x=>x.FechaExpira!=null)?.Count()>0?"fecha expira" : null; //Data.FechaExpira?.ToString("dd/MM/yyyy");
            string fallaFarmaceutica = 
                Data.FallaReportada?.Olor == enumOpcionSiNo.Si?"Si":
                (Data.FallaReportada?.Color == enumOpcionSiNo.Si ? "Si" :
                (Data.FallaReportada?.Sabor == enumOpcionSiNo.Si ? "Si" :
                (Data.FallaReportada?.SepFases == enumOpcionSiNo.Si ? "Si" :
                (Data.FallaReportada?.ParExtrana == enumOpcionSiNo.Si ? "Si" :
                (Data.FallaReportada?.Contaminacion == enumOpcionSiNo.Si ? "Si" :
                (Data.FallaReportada?.ProDisolucion == enumOpcionSiNo.Si ? "Si":
                (Data.FallaReportada?.ProDesintegracion == enumOpcionSiNo.Si ? "Si":
                (Data.FallaReportada?.Precipitacion == enumOpcionSiNo.Si ? "Si" :
                (Data.FallaReportada?.Otros == enumOpcionSiNo.Si ? "Si" :
                Data.FallaReportada?.DetFallaReport??"")))))))));
            string notificador = Data.Notificador;
            string tipoNotificador = Data.TipoNotificacion != enumFMV_RAMNotificationType.NOREP?DataModel.Helper.Helper.GetDescription(Data.TipoNotificacion) :null;
            string organizacion = Data.TipoInstitucionId?.ToString() ?? null;
            string presentacion = Data.Presentacion;

            
            //if (string.IsNullOrEmpty(nombreFarmaco) && string.IsNullOrEmpty(concent) && string.IsNullOrEmpty(formaFarm) 
            //    && string.IsNullOrEmpty(fabricante) && string.IsNullOrEmpty(lotes) && string.IsNullOrEmpty(fechaExp) && string.IsNullOrEmpty(fallaFarmaceutica))
            //{
            //    Data.Grado = "Grado 0";
            //}
            if (!string.IsNullOrEmpty(nombreFarmaco) && !string.IsNullOrEmpty(concent) && !string.IsNullOrEmpty(formaFarm) && !string.IsNullOrEmpty(lotes) && !string.IsNullOrEmpty(fechaExp)
                  && !string.IsNullOrEmpty(fallaFarmaceutica) && !string.IsNullOrEmpty(notificador))
            {
                Data.Grado = "Grado 1";
                if (!string.IsNullOrEmpty(fabricante) && !string.IsNullOrEmpty(regSanitario) && !string.IsNullOrEmpty(organizacion))
                {
                    Data.Grado = "Grado 2";
                    if (!string.IsNullOrEmpty(nombreDci) && !string.IsNullOrEmpty(presentacion) && !string.IsNullOrEmpty(tipoNotificador))
                    {
                        Data.Grado = "Grado 3";
                    }
                }
            }
            //if (!string.IsNullOrEmpty(nombreFarmaco) && !string.IsNullOrEmpty(nombreDci) && !string.IsNullOrEmpty(concent)
            //   && !string.IsNullOrEmpty(regSanitario) && !string.IsNullOrEmpty(formaFarm) && !string.IsNullOrEmpty(fabricante)
            //   && !string.IsNullOrEmpty(lotes) && !string.IsNullOrEmpty(fechaExp) && !string.IsNullOrEmpty(fallaFarmaceutica)
            //   && !string.IsNullOrEmpty(notificador) && !string.IsNullOrEmpty(instSalud) && !string.IsNullOrEmpty(presentacion))
            //{
            //    Data.Grado = "Grado 4";
            //}

            Data.Grado = !string.IsNullOrEmpty(Data.Grado) ? Data.Grado : "Grado 0";
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
                Data.NombreComercial = message.Data.nombre;
                Data.Presentacion = message.Data.presentacion;
                Data.Concentracion = message.Data.concentracion;
                Data.FormaFarmaceutica = message.Data.formaFarmaceutica?.nombre??"";
                Data.RegSanitario = string.IsNullOrEmpty(message.Data.numReg) ? Data.RegSanitario : message.Data.numReg;
                //Data.principio = string.IsNullOrEmpty(message.Data.principio) ? Ips.PrincActivo : message.Data.principio;
            }

            this.InvokeAsync(StateHasChanged);
        }

        //////////////
        ////
         //Add New Attachment
        protected async Task OpenLote(FMV_LoteTB lote = null) {
            bus.Subscribe<Aig.FarmacoVigilancia.Events.Lotes.AddEditEvent>(LoteAddEditEvent_Handler);

            this.lote = lote != null ? lote : new FMV_LoteTB();
            openLote = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //RemoveAttachment
        protected async Task RemoveLote(FMV_LoteTB lote) {
            if (lote != null) {               
                Data.LLotes.Remove(lote);
                this.InvokeAsync(StateHasChanged);
            }
        }
        //ON CLOSE ATTACHMENT
        private void LoteAddEditEvent_Handler(MessageArgs args) {
            openLote = false;

            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.Lotes.AddEditEvent>(LoteAddEditEvent_Handler);

            var message = args.GetMessage<Aig.FarmacoVigilancia.Events.Lotes.AddEditEvent>();

            if (message.Data != null) {
                Data.LLotes = Data.LLotes!=null ? Data.LLotes : new List<FMV_LoteTB>();      
                if(!Data.LLotes.Contains(message.Data)) {
                    Data.LLotes.Add(message.Data);
                }
            }

            this.InvokeAsync(StateHasChanged);
        }

        ////////////
        ///

        protected async Task OpenSearchFarmaco() {
            bus.Subscribe<Aig.FarmacoVigilancia.Events.Farmaco.AddEditEvent>(SearchFarmacoEventHandler);
            showSearchFarmaco = true;
            await this.InvokeAsync(StateHasChanged);
        }
        private void SearchFarmacoEventHandler(MessageArgs args) {
            showSearchFarmaco = false;
            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.Farmaco.AddEditEvent>(SearchFarmacoEventHandler);
            var message = args.GetMessage<Aig.FarmacoVigilancia.Events.Farmaco.AddEditEvent>();
            if (message.Data != null) {
                Data.NombreDci = message.Data.NombreDCI;
                Data.NombreComercial = string.IsNullOrEmpty(message.Data.NombreComercial) ? Data.NombreComercial : message.Data.NombreComercial;
            }
            this.InvokeAsync(StateHasChanged);
        }


    }

}

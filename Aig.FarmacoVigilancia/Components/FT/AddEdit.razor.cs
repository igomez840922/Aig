﻿using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using DataModel;
using DataModel.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.FarmacoVigilancia.Components.FT
{
    public partial class AddEdit
    {
        [Inject]
        IFTService ftService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IWorkerPersonService evaluatorService { get; set; }
        [Inject]
        IPdfGenerationService pdfGenerationService { get; set; }
        [Parameter]
        public DataModel.FMV_FtTB Data { get; set; }
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

        bool OpenAddEditConcominante { get; set; } = false;
        FMV_RamFarmacoConcominante FarmacoConcominante { get; set; } = null;

        bool openAttachment { get; set; } = false;
        AttachmentTB attachment { get; set; } = null;
        bool Exit { get; set; } = false;
        bool showSearchMedicine { get; set; } = false;

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
                //verificar CodigoCNFV
                if (!string.IsNullOrEmpty(Data.CodCNFV))
                {
                    var tmpData = (await ftService.FindAll(x => x.CodCNFV.Contains(Data.CodCNFV) && x.Id != Data.Id)).FirstOrDefault();
                    if (tmpData != null)
                    {
                        await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["El código de CNFV ya existe"]);
                        return;
                    }
                }

                //verificar Cod Externo
                if (!string.IsNullOrEmpty(Data.CodExt))
                {
                    var tmpData = (await ftService.FindAll(x => x.CodExt.Contains(Data.CodExt) && x.Id != Data.Id)).FirstOrDefault();
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

                var result = await ftService.Save(Data);
                if (result != null)
                {
                    await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                    Data = result;

                    if (Exit) 
                        await bus.Publish(new Aig.FarmacoVigilancia.Events.FT.AddEdit_CloseEvent { Data = Data });
                }
                else
                    await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
            
            }
            catch (Exception ex) { }
            finally { Exit=false; }
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.FT.AddEdit_CloseEvent { Data = null });
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
            Data.ATC = Data.ATC.Replace(" ", "");
            if (!string.IsNullOrEmpty(Data.ATC) && Data.ATC.Length >= 3)
                Data.SubGrupoTerapeutico = Helper.Helper.GetATC2doNivel(Data.ATC);
        }


        /////////////
        ///
        private void UpdateGrado()
        {
            Data.OtrasEspecificaciones.Grado = "";

            string nombreFarmaco = Data.NombreComercial;
            string nombreDci = Data.NombreDci;
            string concent = Data.Concentracion;
            string regSanitario = Data.RegSanitario;
            string formaFarm = Data.FormaFarmaceutica;
            string fabricante = Data.Fabricant?.Nombre ?? "";
            string lotes = Data.Lote;
            string fechaExp = Data.FechaExpira?.ToString("dd/MM/yyyy");
            //string fallaFarmaceutica =
            //    Data.FallaReportada?.Olor == enumOpcionSiNo.Si ? "Si" :
            //    (Data.FallaReportada?.Color == enumOpcionSiNo.Si ? "Si" :
            //    (Data.FallaReportada?.Sabor == enumOpcionSiNo.Si ? "Si" :
            //    (Data.FallaReportada?.SepFases == enumOpcionSiNo.Si ? "Si" :
            //    (Data.FallaReportada?.ParExtrana == enumOpcionSiNo.Si ? "Si" :
            //    (Data.FallaReportada?.Contaminacion == enumOpcionSiNo.Si ? "Si" :
            //    (Data.FallaReportada?.ProDisolucion == enumOpcionSiNo.Si ? "Si" :
            //    (Data.FallaReportada?.ProDesintegracion == enumOpcionSiNo.Si ? "Si" :
            //    (Data.FallaReportada?.Precipitacion == enumOpcionSiNo.Si ? "Si" :
            //    (Data.FallaReportada?.Otros == enumOpcionSiNo.Si ? "Si" :
            //    Data.FallaReportada?.DetFallaReport ?? "")))))))));
            string notificador = Data.Notificador;
            string instSalud = Data.InstitucionDestino?.Nombre ?? "";
            string presentacion = Data.Presentacion;

            if (string.IsNullOrEmpty(nombreFarmaco) && string.IsNullOrEmpty(concent) && string.IsNullOrEmpty(formaFarm)
                && string.IsNullOrEmpty(fabricante) && string.IsNullOrEmpty(lotes) && string.IsNullOrEmpty(fechaExp) )
            {
                Data.OtrasEspecificaciones.Grado = "Grado 0";
            }
            if (!string.IsNullOrEmpty(nombreFarmaco) && !string.IsNullOrEmpty(lotes) && !string.IsNullOrEmpty(fechaExp)
                && !string.IsNullOrEmpty(concent) && !string.IsNullOrEmpty(formaFarm) && !string.IsNullOrEmpty(notificador))
            {
                Data.OtrasEspecificaciones.Grado = "Grado 1";
                if (!string.IsNullOrEmpty(fabricante) && !string.IsNullOrEmpty(regSanitario) && !string.IsNullOrEmpty(instSalud))
                {
                    Data.OtrasEspecificaciones.Grado = "Grado 2";
                    if (!string.IsNullOrEmpty(nombreDci) && !string.IsNullOrEmpty(presentacion))
                    {
                        Data.OtrasEspecificaciones.Grado = "Grado 3";
                    }
                }
            }
            if (!string.IsNullOrEmpty(nombreFarmaco) && !string.IsNullOrEmpty(nombreDci) && !string.IsNullOrEmpty(concent)
               && !string.IsNullOrEmpty(regSanitario) && !string.IsNullOrEmpty(formaFarm) && !string.IsNullOrEmpty(fabricante)
               && !string.IsNullOrEmpty(lotes) && !string.IsNullOrEmpty(fechaExp) 
               && !string.IsNullOrEmpty(notificador) && !string.IsNullOrEmpty(instSalud) && !string.IsNullOrEmpty(presentacion))
            {
                Data.OtrasEspecificaciones.Grado = "Grado 4";
            }

            //Data.Grado = !string.IsNullOrEmpty(grado0) ? grado0 : (!string.IsNullOrEmpty(grado1) ? grado1 : (!string.IsNullOrEmpty(grado2) ? grado2 : (!string.IsNullOrEmpty(grado3) ? grado3 : (!string.IsNullOrEmpty(grado4) ? grado4 : "No Aplica"))));

        }

        /////////////////////
        ///

        //Add New Concominante
        protected async Task OpenConcominante(FMV_RamFarmacoConcominante farmaco = null)
        {
            bus.Subscribe<Aig.FarmacoVigilancia.Events.RamConcominante.AddEdit_Event>(FarmacoConcominante_AddEditEventHandler);

            FarmacoConcominante = farmaco != null ? farmaco : new FMV_RamFarmacoConcominante();
            OpenAddEditConcominante = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //Remove Farmaco
        protected async Task RemoveConcominante(FMV_RamFarmacoConcominante farmaco)
        {
            if (farmaco != null)
            {
                Data.Concominantes.LProductos.Remove(farmaco);

                this.InvokeAsync(StateHasChanged);
            }
        }
        //on close Farmaco MODAL 
        private void FarmacoConcominante_AddEditEventHandler(MessageArgs args)
        {
            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.RamConcominante.AddEdit_Event>(FarmacoConcominante_AddEditEventHandler);

            var message = args.GetMessage<Aig.FarmacoVigilancia.Events.RamConcominante.AddEdit_Event>();

            FarmacoConcominante = null;
            OpenAddEditConcominante = false;
            if (message.Data != null)
            {
                Data.Concominantes = Data.Concominantes != null ? Data.Concominantes : new FMV_RamConcominantes();
                Data.Concominantes.LProductos = Data.Concominantes.LProductos != null ? Data.Concominantes.LProductos : new List<FMV_RamFarmacoConcominante>();

                if (!Data.Concominantes.LProductos.Contains(message.Data))
                    Data.Concominantes.LProductos.Add(message.Data);
            }

            this.InvokeAsync(StateHasChanged);
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
                Data.FormaFarmaceutica = message.Data.formaFarmaceutica?.nombre ?? "";
                Data.RegSanitario = string.IsNullOrEmpty(message.Data.numReg) ? Data.RegSanitario : message.Data.numReg;
                //Data.principio = string.IsNullOrEmpty(message.Data.principio) ? Ips.PrincActivo : message.Data.principio;
            }

            this.InvokeAsync(StateHasChanged);
        }
    }

}

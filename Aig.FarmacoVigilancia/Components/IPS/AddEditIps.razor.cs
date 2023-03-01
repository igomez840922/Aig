using Aig.FarmacoVigilancia.Components.ESAVI2;
using Aig.FarmacoVigilancia.Events.IPS;
using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Events.PMR;
using Aig.FarmacoVigilancia.Pages.Alert;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Mail;

namespace Aig.FarmacoVigilancia.Components.IPS
{    
    public partial class AddEditIps
    {
        [Inject]
        IIpsService ipsService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IWorkerPersonService workerPersonService { get; set; }
        [Inject]
        ILabsService labsService { get; set; }
        [Parameter]
        public DataModel.FMV_IpsTB Ips { get; set; }
        List<PersonalTrabajadorTB> lPersons { get; set; } = new List<PersonalTrabajadorTB>();
        List<LaboratorioTB> Labs { get; set; } = new List<LaboratorioTB>();

        bool openAttachment { get; set; } = false;
        AttachmentTB attachment { get; set; } = null;

        //bool showSearchMedicine { get; set; } = false;

        FMV_IpsMedicamentoTB Medicamento { get; set; } = null;
        bool OpenAddEditMedicamento { get; set; } = false;

        bool Exit { get; set; } = false;

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
            if (lPersons == null || lPersons.Count < 1)
            {
                lPersons = await workerPersonService.GetAll();
            }
            if (Labs == null || Labs.Count < 1)
            {
                Labs = await labsService.GetAll();
            }

            //if (Ips != null)
            //    Ips.UpdateRule();

            //if (Pmr != null)
            //{
            //    if (Pmr.EvaluadorId == null)
            //    {
            //        Pmr.EvaluadorId = lEvaluators?.FirstOrDefault()?.Id ?? null;
            //        if (Pmr.EvaluadorId != null)
            //        {
            //            Pmr.Evaluador = lEvaluators.Where(x => x.Id == Pmr.EvaluadorId.Value).FirstOrDefault();
            //        }
            //    }
            //}

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            try
            {
                //verificar num de la nota
                if (!string.IsNullOrEmpty(Ips.NoInforme))
                {
                    var tmpData = (await ipsService.FindAll(x => x.NoInforme.Contains(Ips.NoInforme) && x.Id != Ips.Id))?.FirstOrDefault();
                    if (tmpData != null)
                    {
                        await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["El Número de Informe ya Existe"]);
                        return;
                    }
                }

                if (Ips.EvaluadorId != null && Ips.EvaluadorId > 0)
                {
                    Ips.Evaluador = lPersons?.Where(x => x.Id == Ips.EvaluadorId.Value).FirstOrDefault();
                }
                if (Ips.TramitadorId != null && Ips.TramitadorId > 0)
                {
                    Ips.Tramitador = lPersons?.Where(x => x.Id == Ips.TramitadorId.Value).FirstOrDefault();
                }
                if (Ips.RegistradorId != null && Ips.RegistradorId > 0)
                {
                    Ips.Registrador = lPersons?.Where(x => x.Id == Ips.RegistradorId.Value).FirstOrDefault();
                }

                if (Ips.EstatusRecepcion == DataModel.Helper.enumFMV_IpsStatusRecepcion.Rejected)
                {
                    Ips.StatusRevision = DataModel.Helper.enumFMV_IpsStatusRevision.Rejected;
                }

                var result = await ipsService.Save(Ips);
                if (result != null)
                {
                    await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                    Ips = result;

                    if (Exit)
                        await bus.Publish(new IpsAddEdit_CloseEvent { Data = null });
                }
                else
                    await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);

            }
            catch (Exception ex)
            {
            }
            finally { Exit = false; }
            //verificar CodigoCNFV

        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new IpsAddEdit_CloseEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
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

                Ips.Adjunto.LAttachments.Remove(attachment);
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
                Ips.Adjunto = Ips.Adjunto != null ? Ips.Adjunto : new AttachmentData();
                Ips.Adjunto.LAttachments = Ips.Adjunto.LAttachments != null ? Ips.Adjunto.LAttachments : new List<AttachmentTB>();
                Ips.Adjunto.LAttachments.Add(message.Attachment);
            }
            this.InvokeAsync(StateHasChanged);
        }

        /////////
        ///        
        //protected async Task OpenSearchMedicine()
        //{
        //    bus.Subscribe<Aig.FarmacoVigilancia.Events.SearchMedicines.SearchMedicinesEvent>(MedicineSearchEventHandler);

        //    showSearchMedicine = true;

        //    await this.InvokeAsync(StateHasChanged);
        //}
        //private void MedicineSearchEventHandler(MessageArgs args)
        //{
        //    showSearchMedicine = false;

        //    bus.UnSubscribe<Aig.FarmacoVigilancia.Events.SearchMedicines.SearchMedicinesEvent>(MedicineSearchEventHandler);

        //    var message = args.GetMessage<Aig.FarmacoVigilancia.Events.SearchMedicines.SearchMedicinesEvent>();

        //    if (message.Data != null)
        //    {
        //        Ips.RegSanitario = message.Data.numReg;
        //        Ips.NomComercial = message.Data.nombre;
        //        Ips.PrincActivo = string.IsNullOrEmpty(message.Data.principio) ? Ips.PrincActivo : message.Data.principio;
        //    }

        //    this.InvokeAsync(StateHasChanged);
        //}


        //Add New Farmaco
        protected async Task OpenMedicamento(FMV_IpsMedicamentoTB medicamento = null)
        {
            bus.Subscribe<Aig.FarmacoVigilancia.Events.IPSMedicamento.AddEditEvent>(Medicamento_AddEditEventHandler);

            Medicamento = medicamento != null ? medicamento : new FMV_IpsMedicamentoTB();
            OpenAddEditMedicamento = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //Remove Farmaco
        protected async Task RemoveMedicamento(FMV_IpsMedicamentoTB medicamento)
        {
            if (medicamento != null)
            {
                Ips.LMedicamentos.Remove(medicamento);

                this.InvokeAsync(StateHasChanged);
            }
        }
        //on close Farmaco MODAL 
        private void Medicamento_AddEditEventHandler(MessageArgs args)
        {
            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.IPSMedicamento.AddEditEvent>(Medicamento_AddEditEventHandler);

            var message = args.GetMessage<Aig.FarmacoVigilancia.Events.IPSMedicamento.AddEditEvent>();

            Medicamento = null;
            OpenAddEditMedicamento = false;
            if (message.Data != null)
            {
                Ips.LMedicamentos = Ips.LMedicamentos != null ? Ips.LMedicamentos : new List<FMV_IpsMedicamentoTB>();

                if (!Ips.LMedicamentos.Contains(message.Data))
                    Ips.LMedicamentos.Add(message.Data);
            }

            this.InvokeAsync(StateHasChanged);
        }

    }

}

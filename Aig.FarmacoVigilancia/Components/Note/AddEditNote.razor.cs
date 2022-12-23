using Aig.FarmacoVigilancia.Events.Alerta;
using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Events.Nota;
using Aig.FarmacoVigilancia.Pages.Alert;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.FarmacoVigilancia.Components.Note
{    
    public partial class AddEditNote
    {
        [Inject]
        INoteService noteService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IWorkerPersonService personService { get; set; }
        [Inject]
        INotaDestinoService destinyInstituteService { get; set; }
        [Parameter]
        public DataModel.FMV_NotaTB Nota { get; set; }
        List<PersonalTrabajadorTB> LPerson { get; set; }
        List<FMV_NotaDestinoTB> LInstitucionDestino { get; set; }
        List<FMV_NotaDestinoTB> LInstitucionDestinoFiltered { get; set; } 

        bool openAttachment { get; set; } = false;
        AttachmentTB attachment { get; set; } = null;

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
            if (LPerson == null || LPerson.Count < 1)
            {
                LPerson = await personService.GetAll();
            }
            if (LInstitucionDestino == null || LInstitucionDestino.Count < 1)
            {
                LInstitucionDestino = await destinyInstituteService.GetAll();
            }

            await OnTipoNotaChange();

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            if (Nota.EvaluadorId != null && Nota.EvaluadorId > 0)
            {
                Nota.Evaluador = LPerson?.Where(x => x.Id == Nota.EvaluadorId.Value).FirstOrDefault();
            }
            //if (Nota.InstitucionDestinoId != null && Nota.InstitucionDestinoId > 0)
            //{
            //    Nota.InstitucionDestino = LInstitucionDestino?.Where(x => x.Id == Nota.InstitucionDestinoId.Value).FirstOrDefault();
            //}

            //verificar el numero de nota unico
            if (!string.IsNullOrEmpty(Nota.NumNota))
            {
                var tmpData = (await noteService.FindAll(x => x.NumNota.Contains(Nota.NumNota) && x.Id!=Nota.Id)).FirstOrDefault();
                if(tmpData != null)
                {
                    await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["El Número de Nota ya Existe"]);
                    return;
                }
            }

            var result = await noteService.Save(Nota);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Nota = result;

                await bus.Publish(new NotaAddEdit_CloseEvent { Data = null });
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new NotaAddEdit_CloseEvent { Data = null });
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

                Nota.Adjunto.LAttachments.Remove(attachment);
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
                Nota.Adjunto = Nota.Adjunto != null ? Nota.Adjunto : new AttachmentData();
                Nota.Adjunto.LAttachments = Nota.Adjunto.LAttachments != null ? Nota.Adjunto.LAttachments : new List<AttachmentTB>();
                Nota.Adjunto.LAttachments.Add(message.Attachment);
            }
            this.InvokeAsync(StateHasChanged);
        }

        private async Task OnTipoNotaChange()
        {
            try 
            {
                if(Nota!=null && Nota.TipoNota != null)
                {
                    LInstitucionDestinoFiltered =  LInstitucionDestino.Where(x => x.NotaClasificacion.LClasificaciones.Any(o=>o.NoteType == Nota.TipoNota)).ToList();
                }
            }
            catch { }

            LInstitucionDestinoFiltered = LInstitucionDestinoFiltered!=null && LInstitucionDestinoFiltered.Count > 0? LInstitucionDestinoFiltered: LInstitucionDestino;
            
            this.InvokeAsync(StateHasChanged);
        }

    }

}

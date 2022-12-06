using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Services;
using BlazorComponentBus;
using DataModel;
using DataModel.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Mobsites.Blazor;

namespace Aig.Auditoria.Components.Inspections
{    
    public partial class RutinaVigilanciaFarmacia
    {
        [Inject]
        IInspectionsService inspeccionService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IEstablishmentsService establecimientoService { get; set; }
        [Inject]
        ICountriesService countriesService { get; set; }
        [Inject]
        IPdfGenerationService pdfGenerationService { get; set; }
        [Parameter]
        public DataModel.AUD_InspeccionTB Inspeccion { get; set; }
        List<AUD_EstablecimientoTB> lEstablecimientos { get; set; }
        List<PaisTB> lPaises { get; set; }

        enum_StatusInspecciones StatusInspecciones { get; set; } = enum_StatusInspecciones.Pending;

        bool showSignasure { get; set; } = false;
        List<SignaturePad> lSignaturePads { get; set; } = new List<SignaturePad>();
        SignaturePad signaturePad
        {
            get { return null; }
            set { lSignaturePads.Add(value); }
        }
        SignaturePad signaturePad5;
        SignaturePad signaturePad6;
        SignaturePad.SupportedSaveAsTypes signatureType { get; set; } = SignaturePad.SupportedSaveAsTypes.png;

        bool OpenHourModal { get; set; } = false;
        AUD_DatosHorario DatosHorario { get; set; } = null;

        bool showParticipant { get; set; } = false;
        Participante participante { get; set; } = null;

        bool showTechnicalPerson { get; set; } = false;
        PersonalTecnico personalTecnico { get; set; } = null;

        bool showExpColaborador { get; set; } = false;
        ExpedienteColaborador expedienteColaborador { get; set; } = null;

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
                StatusInspecciones = Inspeccion?.StatusInspecciones ?? enum_StatusInspecciones.Pending;
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
            
            if (lEstablecimientos == null || lEstablecimientos.Count < 1)
            {
                lEstablecimientos = await establecimientoService.GetAll();
            }
            if (lPaises == null || lPaises.Count < 1)
            {
                lPaises = await countriesService.GetAll();
            }

            if (Inspeccion != null)
            {
                if (Inspeccion.EstablecimientoId == null)
                {
                    Inspeccion.EstablecimientoId = lEstablecimientos?.FirstOrDefault()?.Id ?? null;
                    if (Inspeccion.EstablecimientoId != null)
                    {
                        Inspeccion.UbicacionEstablecimiento = lEstablecimientos.Where(x => x.Id == Inspeccion.EstablecimientoId.Value).FirstOrDefault()?.Ubicacion ?? "";
                    }
                }

                if (signaturePad5 != null)
                    signaturePad5.Image = Inspeccion.InspRutinaVigFarmacia.DatosConclusiones.FirmaRepresentanteLegal;
                if (signaturePad6 != null)
                    signaturePad6.Image = Inspeccion.InspRutinaVigFarmacia.DatosConclusiones.FirmaRegente;

                foreach (var partic in Inspeccion.InspRutinaVigFarmacia.DatosConclusiones.LParticipantes)
                {
                    try
                    {
                        lSignaturePads[Inspeccion.InspRutinaVigFarmacia.DatosConclusiones.LParticipantes.IndexOf(partic)].Image = partic.Firma;
                    }
                    catch (Exception ex) { }
                }
            }

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            if (Inspeccion.EstablecimientoId != null && Inspeccion.EstablecimientoId > 0)
            {
                Inspeccion.Establecimiento = await establecimientoService.Get(Inspeccion.EstablecimientoId.Value);
            }

            var result = await inspeccionService.Save(Inspeccion);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Inspeccion = result;

                await bus.Publish(new Aig.Auditoria.Events.Inspections.AddEditCloseEvent { Inspeccion = null });
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.Auditoria.Events.Inspections.AddEditCloseEvent { Inspeccion = null });
            await this.InvokeAsync(StateHasChanged);
        }


        protected async Task OnEstablishmentChange(long? Id)
        {
            Inspeccion.EstablecimientoId = Id;
            Inspeccion.UbicacionEstablecimiento = lEstablecimientos.Where(x => x.Id == Id).FirstOrDefault()?.Ubicacion ?? "";
            Inspeccion.TelefonoEstablecimiento = lEstablecimientos.Where(x => x.Id == Id).FirstOrDefault()?.Telefono1 ?? "";
        }


        protected async Task OnShowSignasure()
        {
            if (!showSignasure && Inspeccion.InspRutinaVigFarmacia.DatosConclusiones.LParticipantes.Count > 0)
            {
                lSignaturePads.Clear();
                showSignasure = true;
                DelayToShowSignasure();
            }
            //await this.InvokeAsync(StateHasChanged);
        }
        async Task DelayToShowSignasure()
        {
            await Task.Delay(2000);
            await FetchData();
        }

        protected async Task OnSignatureChange5(ChangeEventArgs eventArgs)
        {
            RemoveSignatureImg5();
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspRutinaVigFarmacia.DatosConclusiones.FirmaRepresentanteLegal = await signaturePad5.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg5()
        {
            Inspeccion.InspRutinaVigFarmacia.DatosConclusiones.FirmaRepresentanteLegal = null;
            signaturePad5.Image = null;
        }
        protected async Task OnSignatureChange6(ChangeEventArgs eventArgs)
        {
            RemoveSignatureImg6();
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspRutinaVigFarmacia.DatosConclusiones.FirmaRegente = await signaturePad6.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg6()
        {
            Inspeccion.InspRutinaVigFarmacia.DatosConclusiones.FirmaRegente = null;
            signaturePad6.Image = null;
        }


        ////////
        ///
        protected async Task OnSignatureChange(Participante _participante)
        {
            await RemoveSignatureImg(_participante);
            var _signaturePad = lSignaturePads[Inspeccion.InspRutinaVigFarmacia.DatosConclusiones.LParticipantes.IndexOf(_participante)];
            _participante.Firma = await _signaturePad.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg(Participante _participante)
        {
            _participante.Firma = null;
            var _signaturePad = lSignaturePads[Inspeccion.InspRutinaVigFarmacia.DatosConclusiones.LParticipantes.IndexOf(_participante)];
            _signaturePad.Image = null;
        }

        ///

        //AGREGA PARTICIPANTE
        protected async Task OpenParticipant(Participante _participante=null)
        {
            bus.Subscribe<Aig.Auditoria.Events.Participants.ParticipantsAddEdit_CloseEvent>(ParticipantsAddEdit_CloseEventHandler);

            participante = _participante!=null? _participante: new Participante();
            showParticipant = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //Eliminar
        protected async Task RemoveParticipant(Participante _participante)
        {
            if (_participante != null)
            {
                try
                {
                    Inspeccion.InspRutinaVigFarmacia.DatosConclusiones.LParticipantes.Remove(_participante);
                }
                catch { }

                this.InvokeAsync(StateHasChanged);
            }
        }
        //ON CLOSE ATTACHMENT
        private void ParticipantsAddEdit_CloseEventHandler(MessageArgs args)
        {
            showSignasure = false;
            showParticipant = false;

            bus.UnSubscribe<Aig.Auditoria.Events.Participants.ParticipantsAddEdit_CloseEvent>(ParticipantsAddEdit_CloseEventHandler);

            var message = args.GetMessage<Aig.Auditoria.Events.Participants.ParticipantsAddEdit_CloseEvent>();

            if (message.Data != null)
            {
                if(!Inspeccion.InspRutinaVigFarmacia.DatosConclusiones.LParticipantes.Contains(message.Data))
                    Inspeccion.InspRutinaVigFarmacia.DatosConclusiones.LParticipantes.Add(message.Data);
            }

            this.InvokeAsync(StateHasChanged);
        }

        //AGREGA PERSONAL TECNICO
        protected async Task OpenPersonalTec(PersonalTecnico _personalTecnico=null)
        {
            bus.Subscribe<Aig.Auditoria.Events.TechnicalPersonal.TechnicalPersonalAddEdit_CloseEvent>(TechnicalPersonalAddEdit_CloseEventHandler);

            personalTecnico = _personalTecnico!=null? _personalTecnico: new PersonalTecnico();
            showTechnicalPerson = true;

            await this.InvokeAsync(StateHasChanged);
        }
        protected async Task RemovePersonalTec(PersonalTecnico _personaltecnico)
        {
            if (_personaltecnico != null)
            {
                try
                {
                    Inspeccion.InspRutinaVigFarmacia.DatosPersonalTecnico.LPersonalTecnico.Remove(_personaltecnico);
                }
                catch { }

                this.InvokeAsync(StateHasChanged);
            }
        }
        private void TechnicalPersonalAddEdit_CloseEventHandler(MessageArgs args)
        {
            showSignasure = false;
            showParticipant = false;

            bus.UnSubscribe<Aig.Auditoria.Events.TechnicalPersonal.TechnicalPersonalAddEdit_CloseEvent>(TechnicalPersonalAddEdit_CloseEventHandler);

            var message = args.GetMessage<Aig.Auditoria.Events.TechnicalPersonal.TechnicalPersonalAddEdit_CloseEvent>();

            if (message.Data != null)
            {
                if(Inspeccion.InspRutinaVigFarmacia.DatosPersonalTecnico.LPersonalTecnico.Contains(message.Data))
                    Inspeccion.InspRutinaVigFarmacia.DatosPersonalTecnico.LPersonalTecnico.Add(message.Data);
            }

            this.InvokeAsync(StateHasChanged);
        }

        //EXPEDIENTE COLABORADOR
        protected async Task OpenExpColaborador(ExpedienteColaborador _expedienteColaborador=null)
        {
            bus.Subscribe<Aig.Auditoria.Events.ColaboratorFile.ColaboratorFileAddEdit_CloseEvent>(ColaboratorFileAddEdit_CloseEventHandler);

            expedienteColaborador = _expedienteColaborador!=null? _expedienteColaborador: new ExpedienteColaborador();
            showExpColaborador = true;

            await this.InvokeAsync(StateHasChanged);
        }
        protected async Task RemoveExpColaborador(ExpedienteColaborador _expedienteColaborador)
        {
            if (_expedienteColaborador != null)
            {
                try
                {
                    Inspeccion.InspRutinaVigFarmacia.DatosExpedienteColaborador.LColaboradores.Remove(_expedienteColaborador);
                }
                catch { }

                this.InvokeAsync(StateHasChanged);
            }
        }
        private void ColaboratorFileAddEdit_CloseEventHandler(MessageArgs args)
        {
            showSignasure = false;
            showExpColaborador = false;

            bus.UnSubscribe<Aig.Auditoria.Events.ColaboratorFile.ColaboratorFileAddEdit_CloseEvent>(ColaboratorFileAddEdit_CloseEventHandler);

            var message = args.GetMessage<Aig.Auditoria.Events.ColaboratorFile.ColaboratorFileAddEdit_CloseEvent>();

            if (message.Data != null)
            {
                if(!Inspeccion.InspRutinaVigFarmacia.DatosExpedienteColaborador.LColaboradores.Contains(message.Data))
                    Inspeccion.InspRutinaVigFarmacia.DatosExpedienteColaborador.LColaboradores.Add(message.Data);
            }

            this.InvokeAsync(StateHasChanged);
        }


    }

}

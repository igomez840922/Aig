using Aig.Auditoria.Services;
using BlazorComponentBus;
using DataModel.Helper;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Mobsites.Blazor;
using Aig.Auditoria.Events.Language;
using Microsoft.AspNetCore.Components.Forms;

namespace Aig.Auditoria.Components.Inspections
{
    public partial class GuiaBPM_BPA
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
        //List<AUD_EstablecimientoTB> lEstablecimientos { get; set; }
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
        bool showPersona { get; set; } = false;
        DataModel.DatosPersona datosPersona { get; set; } = null;

        List<PropositoInspeccion> LPropositos { get; set; } = new List<PropositoInspeccion>();

        bool showSearchEstablishment { get; set; } = false;

        bool exit { get; set; } = false;
        bool isOpen { get; set; } = true;

        private EditContext? editContext;
        private System.Timers.Timer timer = new(60 * 1000);

        protected async override Task OnInitializedAsync()
        {
            editContext = new(Inspeccion);
            timer.Elapsed += (sender, eventArgs) => {
                _ = InvokeAsync(() =>
                {
                    SaveData();
                });
            };
            timer.Start();

            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);

            base.OnInitialized();
        }

        public void Dispose()
        {
            timer?.Dispose();
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
            if (LPropositos.Count <= 0)
            {
                foreach (enum_PropositoInspec dt in Enum.GetValues(typeof(enum_PropositoInspec)))
                {
                    LPropositos.Add(new PropositoInspeccion() {  PropositoType = dt });
                }
            }
            //if (lEstablecimientos == null || lEstablecimientos.Count < 1)
            //{
            //    lEstablecimientos = await establecimientoService.GetAll();
            //}
            if (lPaises == null || lPaises.Count < 1)
            {
                lPaises = await countriesService.GetAll();
            }

            if (Inspeccion != null)
            {
                //if (Inspeccion.EstablecimientoId == null)
                //{
                //    Inspeccion.EstablecimientoId = lEstablecimientos?.FirstOrDefault()?.Id ?? null;
                //    if (Inspeccion.EstablecimientoId != null)
                //    {
                //        Inspeccion.UbicacionEstablecimiento = lEstablecimientos.Where(x => x.Id == Inspeccion.EstablecimientoId.Value).FirstOrDefault()?.Ubicacion ?? "";
                //    }
                //}

                if (signaturePad5 != null)
                    signaturePad5.Image = Inspeccion.InspGuiaBPM_Bpa.RepresentLegal.Firma;
                if (signaturePad6 != null)
                    signaturePad6.Image = Inspeccion.InspGuiaBPM_Bpa.RegenteFarmaceutico.Firma;

                foreach (var partic in Inspeccion.InspGuiaBPM_Bpa.DatosConclusiones.LParticipantes)
                {
                    try
                    {
                        lSignaturePads[Inspeccion.InspGuiaBPM_Bpa.DatosConclusiones.LParticipantes.IndexOf(partic)].Image = partic.Firma;
                    }
                    catch (Exception ex) { }
                }
            }

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            try
            {
                if (!editContext?.Validate() ?? false)
                    return;

                if (Inspeccion.InspGuiaBPM_Bpa?.DatosConclusiones?.LParticipantes?.Count <= 0)
                {
                    await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["Seleccione los participantes antes de continuar"]);
                    return;
                }

                if (Inspeccion.EstablecimientoId != null && Inspeccion.EstablecimientoId > 0)
                {
                    Inspeccion.Establecimiento = await establecimientoService.Get(Inspeccion.EstablecimientoId.Value);
                }

                var result = await inspeccionService.Save(Inspeccion);
                if (result != null)
                {
                    await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                    Inspeccion = result;

                    if (exit)
                        await bus.Publish(new Aig.Auditoria.Events.Inspections.AddEditCloseEvent { Inspeccion = null });
                }
                else
                    await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
            }
            catch { }
            finally
            {
                exit = false;
                await this.InvokeAsync(StateHasChanged);
            }
        }
                
        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.Auditoria.Events.Inspections.AddEditCloseEvent { Inspeccion = null });
            await this.InvokeAsync(StateHasChanged);
        }


        //protected async Task OnEstablishmentChange(long? Id)
        //{
        //    Inspeccion.EstablecimientoId = Id;
        //    var establecimiento = lEstablecimientos.Where(x => x.Id == Id).FirstOrDefault();
        //    Inspeccion.UbicacionEstablecimiento = establecimiento?.Ubicacion ?? "";
        //    Inspeccion.TelefonoEstablecimiento = establecimiento?.Telefono1 ?? "";
        //    Inspeccion.InspGuiaBPM_Bpa.GeneralesEmpresa.Email = establecimiento?.Email ?? "";
        //    Inspeccion.InspGuiaBPM_Bpa.GeneralesEmpresa.Telefono = establecimiento?.Telefono1 ?? "";
        //    Inspeccion.InspGuiaBPM_Bpa.GeneralesEmpresa.Nombre = establecimiento?.Nombre ?? "";
        //    Inspeccion.InspGuiaBPM_Bpa.GeneralesEmpresa.Direccion = establecimiento?.Ubicacion ?? "";
        //    Inspeccion.InspGuiaBPM_Bpa.GeneralesEmpresa.Ciudad = establecimiento?.Provincia?.Nombre ?? "";
        //}


        protected async Task OnShowSignasure()
        {
            if (!showSignasure && Inspeccion.InspGuiaBPM_Bpa.DatosConclusiones.LParticipantes.Count > 0)
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
            Inspeccion.InspGuiaBPM_Bpa.RepresentLegal.Firma = await signaturePad5.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg5()
        {
            Inspeccion.InspGuiaBPM_Bpa.RepresentLegal.Firma = null;
            signaturePad5.Image = null;
        }
        protected async Task OnSignatureChange6(ChangeEventArgs eventArgs)
        {
            RemoveSignatureImg6();
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspGuiaBPM_Bpa.RegenteFarmaceutico.Firma = await signaturePad6.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg6()
        {
            Inspeccion.InspGuiaBPM_Bpa.RegenteFarmaceutico.Firma = null;
            signaturePad6.Image = null;
        }


        ////////
        ///
        protected async Task OnSignatureChange(Participante _participante)
        {
            await RemoveSignatureImg(_participante);
            var _signaturePad = lSignaturePads[Inspeccion.InspGuiaBPM_Bpa.DatosConclusiones.LParticipantes.IndexOf(_participante)];
            _participante.Firma = await _signaturePad.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg(Participante _participante)
        {
            _participante.Firma = null;
            var _signaturePad = lSignaturePads[Inspeccion.InspGuiaBPM_Bpa.DatosConclusiones.LParticipantes.IndexOf(_participante)];
            _signaturePad.Image = null;
        }

        ///

        //ADD PARTICIPANTE
        protected async Task OpenParticipant(Participante _participante = null)
        {
            bus.Subscribe<Aig.Auditoria.Events.Participants.ParticipantsAddEdit_CloseEvent>(ParticipantsAddEdit_CloseEventHandler);

            participante = _participante != null ? _participante : new Participante();
            showParticipant = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //RemoveAttachment
        protected async Task RemoveParticipant(Participante _participante)
        {
            if (_participante != null)
            {
                try
                {
                    Inspeccion.InspGuiaBPM_Bpa.DatosConclusiones.LParticipantes.Remove(_participante);
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
                if (!Inspeccion.InspGuiaBPM_Bpa.DatosConclusiones.LParticipantes.Contains(message.Data))
                    Inspeccion.InspGuiaBPM_Bpa.DatosConclusiones.LParticipantes.Add(message.Data);
            }

            this.InvokeAsync(StateHasChanged);
        }

        //ADD PERSONA
        protected async Task OpenPersona(DataModel.DatosPersona _datosPersona = null)
        {
            bus.Subscribe<Aig.Auditoria.Events.DatosPersona.AddEdit_CloseEvent>(PersonaAddEdit_CloseEventHandler);

            datosPersona = _datosPersona != null ? _datosPersona : new DataModel.DatosPersona();
            showPersona = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //RemoveAttachment
        protected async Task RemovePersona(DataModel.DatosPersona _datosPersona)
        {
            if (_datosPersona != null)
            {
                try
                {
                    Inspeccion.InspGuiaBPM_Bpa.OtrosFuncionarios.LPersona.Remove(_datosPersona);
                }
                catch { }

                this.InvokeAsync(StateHasChanged);
            }
        }
        //ON CLOSE ATTACHMENT
        private void PersonaAddEdit_CloseEventHandler(MessageArgs args)
        {
            showPersona = false;

            bus.UnSubscribe<Aig.Auditoria.Events.DatosPersona.AddEdit_CloseEvent>(PersonaAddEdit_CloseEventHandler);

            var message = args.GetMessage<Aig.Auditoria.Events.DatosPersona.AddEdit_CloseEvent>();

            if (message.Data != null)
            {
                if (!Inspeccion.InspGuiaBPM_Bpa.OtrosFuncionarios.LPersona.Contains(message.Data))
                    Inspeccion.InspGuiaBPM_Bpa.OtrosFuncionarios.LPersona.Add(message.Data);
            }

            this.InvokeAsync(StateHasChanged);
        }

        /////////
        ///        
        protected async Task OpenSearchEstablishment()
        {
            bus.Subscribe<Aig.Auditoria.Events.Establishments.SearchEvent>(Establishments_SearchEventHandler);

            showSearchEstablishment = true;

            await this.InvokeAsync(StateHasChanged);
        }
        private void Establishments_SearchEventHandler(MessageArgs args)
        {
            showSearchEstablishment = false;

            bus.UnSubscribe<Aig.Auditoria.Events.Establishments.SearchEvent>(Establishments_SearchEventHandler);

            var message = args.GetMessage<Aig.Auditoria.Events.Establishments.SearchEvent>();

            if (message.Data != null)
            {
                Inspeccion.EstablecimientoId = message.Data.Id;
                Inspeccion.Establecimiento = message.Data;
                Inspeccion.UbicacionEstablecimiento = message.Data?.Ubicacion ?? "";
                Inspeccion.TelefonoEstablecimiento = message.Data?.Telefono1 ?? "";
                Inspeccion.InspGuiaBPM_Bpa.GeneralesEmpresa.Email = message.Data?.Email ?? "";
                Inspeccion.InspGuiaBPM_Bpa.GeneralesEmpresa.Telefono = message.Data?.Telefono1 ?? "";
                Inspeccion.InspGuiaBPM_Bpa.GeneralesEmpresa.Nombre = message.Data?.Nombre ?? "";
                Inspeccion.InspGuiaBPM_Bpa.GeneralesEmpresa.Direccion = message.Data?.Ubicacion ?? "";
                Inspeccion.InspGuiaBPM_Bpa.GeneralesEmpresa.Ciudad = message.Data?.Provincia?.Nombre ?? "";
            }

            this.InvokeAsync(StateHasChanged);
        }


    }

}

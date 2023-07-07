using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Pages.Inspections;
using Aig.Auditoria.Services;
using BlazorComponentBus;
using DataModel;
using DataModel.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Mobsites.Blazor;

namespace Aig.Auditoria.Components.Inspections._11_BpmFabMedicamentos
{
    public partial class Cap01
    {
        [Inject]
        IInspectionsService inspeccionService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IEstablishmentsService establecimientoService { get; set; }

        [Parameter]
        public long Id { get; set; }
        DataModel.AUD_InspeccionTB Inspeccion { get; set; } = null;

        bool showSearchEstablishment { get; set; } = false;

        bool showParticipant { get; set; } = false;
        Participante participante { get; set; } = null;

        private EditContext? editContext;
        private System.Timers.Timer timer = new(60 * 1000);
        bool exit { get; set; } = false;

        [Inject]
        IProvicesService provicesService { get; set; }
        [Inject]
        IDistrictService districtService { get; set; }
        [Inject]
        ICorregimientoService corregimientoService { get; set; }

        List<ProvinciaTB> LProvincias { get; set; }
        List<DistritoTB> LDistritos { get; set; }
        List<CorregimientoTB> LCorregimiento { get; set; }

        bool disabledBtns { get; set; }
        protected async override Task OnInitializedAsync()
        {
            timer.Elapsed += (sender, eventArgs) => {
                _ = InvokeAsync(() =>
                {
                    if (disabledBtns)
                        return;

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

            bus.UnSubscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
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
            LProvincias = LProvincias?.Count > 0 ? LProvincias : await provicesService.GetAll();
            LDistritos = LDistritos?.Count > 0 ? LDistritos : await districtService.GetAll();
            LCorregimiento = LCorregimiento?.Count > 0 ? LCorregimiento : await corregimientoService.GetAll();

            Inspeccion = await inspeccionService.Get(Id);
            if (Inspeccion != null)
            {
                switch (Inspeccion.StatusInspecciones)
                {
                    case enum_StatusInspecciones.Completed:
                        {
                            disabledBtns = true;
                            break;
                        }
                }
                editContext = editContext!=null? editContext: new(Inspeccion);

            }
            else { Cancel(); }
            
            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            try
            {
                var result = await inspeccionService.Save_GeneralData(Inspeccion);
                if (result != null)
                {
                    await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                    Inspeccion = result;

                    if (exit)
                        await bus.Publish(new Aig.Auditoria.Events.Inspections.ChapterChangeEvent { Inspeccion = Inspeccion });
                }
                else
                    await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
            }
            catch(Exception ex) 
            {
                await jsRuntime.InvokeVoidAsync("ShowError", ex.Message);
            }
            finally
            {
                await this.InvokeAsync(StateHasChanged);
            }
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.Auditoria.Events.Inspections.ChapterChangeEvent { Inspeccion = null });
            await this.InvokeAsync(StateHasChanged);
        }

        ////////////////////
        /// Establecimientos
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
                Inspeccion.DatosEstablecimiento = Inspeccion.DatosEstablecimiento != null ? Inspeccion.DatosEstablecimiento : new AUD_DatosEstablecimientoTB();
                Inspeccion.DatosEstablecimiento.EstablecimientoId = message.Data.Id;
                Inspeccion.DatosEstablecimiento.Establecimiento = message.Data;
                Inspeccion.DatosEstablecimiento.Direccion = message.Data.Ubicacion;
                Inspeccion.DatosEstablecimiento.Telefono = message.Data.Telefono1 ?? "";
                Inspeccion.DatosEstablecimiento.Correo = message.Data.Email;
                Inspeccion.DatosEstablecimiento.Nombre = message.Data.Nombre;
                Inspeccion.DatosEstablecimiento.NumLicencia = message.Data.NumLicencia;
                Inspeccion.DatosEstablecimiento.AvisoOperaciones = message.Data.AvisoOperaciones;
                Inspeccion.DatosEstablecimiento.Provincia = message.Data.Provincia; Inspeccion.DatosEstablecimiento.ProvinciaId = message.Data.Provincia?.Id;
                Inspeccion.DatosEstablecimiento.Distrito = message.Data.Distrito;
                Inspeccion.DatosEstablecimiento.Corregimiento = message.Data.Corregimiento;
                Inspeccion.DatosEstablecimiento.ReciboPago = message.Data.ReciboPago;
            }

            this.InvokeAsync(StateHasChanged);
        }
        ////////////////////
        ///Participantes DNFD
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
            try
            {
                if (_participante != null)
                {
                    Inspeccion.ParticipantesDNFD.LParticipantes.Remove(_participante);
                }
            }
            catch { }
            
            this.InvokeAsync(StateHasChanged);
        }
        //ON CLOSE ATTACHMENT
        private void ParticipantsAddEdit_CloseEventHandler(MessageArgs args)
        {
            try {
                showParticipant = false;
                bus.UnSubscribe<Aig.Auditoria.Events.Participants.ParticipantsAddEdit_CloseEvent>(ParticipantsAddEdit_CloseEventHandler);
                var message = args.GetMessage<Aig.Auditoria.Events.Participants.ParticipantsAddEdit_CloseEvent>();
                if (message.Data != null)
                {
                    Inspeccion.ParticipantesDNFD = Inspeccion.ParticipantesDNFD != null ? Inspeccion.ParticipantesDNFD : new AUD_ParticipantesDNFD();

                    if (!Inspeccion.ParticipantesDNFD.LParticipantes.Contains(message.Data))
                        Inspeccion.ParticipantesDNFD.LParticipantes.Add(message.Data);
                }
            }
            catch { }
            this.InvokeAsync(StateHasChanged);
        }

    }

}

using Aig.Auditoria.Services;
using BlazorComponentBus;
using DataModel.Helper;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Mobsites.Blazor;
using Aig.Auditoria.Events.Language;

namespace Aig.Auditoria.Components.Inspections
{   
    public partial class DisposicionFinal
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
        bool showInvProduct { get; set; } = false;
        DataModel.AUD_InvProducto producto { get; set; } = null;

        bool showSearchEstablishment { get; set; } = false;

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
                    signaturePad5.Image = Inspeccion.InspDisposicionFinal.DatosResponsable.Firma;
                //if (signaturePad6 != null)
                //    signaturePad6.Image = Inspeccion.InspDisposicionFinal.DatosRegente.Firma;

                foreach (var partic in Inspeccion.InspDisposicionFinal.DatosConclusiones.LParticipantes)
                {
                    try
                    {
                        lSignaturePads[Inspeccion.InspDisposicionFinal.DatosConclusiones.LParticipantes.IndexOf(partic)].Image = partic.Firma;
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


        //protected async Task OnEstablishmentChange(long? Id)
        //{
        //    Inspeccion.EstablecimientoId = Id;
        //    var establecimiento = lEstablecimientos.Where(x => x.Id == Id).FirstOrDefault();
        //    Inspeccion.UbicacionEstablecimiento = establecimiento?.Ubicacion ?? "";
        //    Inspeccion.TelefonoEstablecimiento = establecimiento?.Telefono1 ?? "";
        //    Inspeccion.InspDisposicionFinal.GeneralesEmpresa.NumLicOperacion = establecimiento?.NumLicencia ?? "";
        //    Inspeccion.InspDisposicionFinal.GeneralesEmpresa.FechaVencLicOperacion = establecimiento?.FechaExpiracion ?? null;
        //    Inspeccion.InspDisposicionFinal.GeneralesEmpresa.Email = establecimiento?.Email ?? "";
        //    Inspeccion.InspDisposicionFinal.GeneralesEmpresa.Telefono = establecimiento?.Telefono1 ?? "";
        //    Inspeccion.InspDisposicionFinal.GeneralesEmpresa.Nombre = establecimiento?.Nombre ?? "";
        //    Inspeccion.InspDisposicionFinal.GeneralesEmpresa.Direccion = establecimiento?.Ubicacion ?? "";
        //    Inspeccion.InspDisposicionFinal.GeneralesEmpresa.Ciudad = establecimiento?.Provincia?.Nombre ?? "";
        //    Inspeccion.InspDisposicionFinal.GeneralesEmpresa.Provincia = establecimiento?.Provincia?.Nombre ?? "";
        //    Inspeccion.InspDisposicionFinal.GeneralesEmpresa.Distrito = establecimiento?.Distrito?.Nombre ?? "";
        //    Inspeccion.InspDisposicionFinal.GeneralesEmpresa.Corregimiento = establecimiento?.Corregimiento?.Nombre ?? "";
        //}

        protected async Task OnShowSignasure()
        {
            if (!showSignasure && Inspeccion.InspDisposicionFinal.DatosConclusiones.LParticipantes.Count > 0)
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
            Inspeccion.InspDisposicionFinal.DatosResponsable.Firma = await signaturePad5.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg5()
        {
            Inspeccion.InspDisposicionFinal.DatosResponsable.Firma = null;
            signaturePad5.Image = null;
        }
        //protected async Task OnSignatureChange6(ChangeEventArgs eventArgs)
        //{
        //    RemoveSignatureImg6();
        //    if (eventArgs?.Value != null)
        //    {
        //        var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
        //    }
        //    Inspeccion.InspDisposicionFinal.DatosRegente.Firma = await signaturePad6.ToDataURL(signatureType);
        //}
        //protected async Task RemoveSignatureImg6()
        //{
        //    Inspeccion.InspDisposicionFinal.DatosRegente.Firma = null;
        //    signaturePad6.Image = null;
        //}


        ////////
        ///
        protected async Task OnSignatureChange(Participante _participante)
        {
            await RemoveSignatureImg(_participante);
            var _signaturePad = lSignaturePads[Inspeccion.InspDisposicionFinal.DatosConclusiones.LParticipantes.IndexOf(_participante)];
            _participante.Firma = await _signaturePad.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg(Participante _participante)
        {
            _participante.Firma = null;
            var _signaturePad = lSignaturePads[Inspeccion.InspDisposicionFinal.DatosConclusiones.LParticipantes.IndexOf(_participante)];
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
                    Inspeccion.InspDisposicionFinal.DatosConclusiones.LParticipantes.Remove(_participante);
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
                if (!Inspeccion.InspDisposicionFinal.DatosConclusiones.LParticipantes.Contains(message.Data))
                    Inspeccion.InspDisposicionFinal.DatosConclusiones.LParticipantes.Add(message.Data);
            }

            this.InvokeAsync(StateHasChanged);
        }

        ////////////////
        ///
        //Add New Product
        protected async Task OpenProduct(AUD_InvProducto product = null)
        {
            bus.Subscribe<Aig.Auditoria.Events.InvProduct.CloseEvent>(AddEditCloseEventHandler);

            product = product != null ? product : new AUD_InvProducto();

            this.producto = product;
            showInvProduct = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //Remove Product
        protected async Task RemoveProduct(AUD_InvProducto product)
        {
            if (product != null)
            {
                Inspeccion.InspDisposicionFinal.InventarioMedicamento.LProductos.Remove(product);
            }
            await this.InvokeAsync(StateHasChanged);
        }
        //ON CLOSE PRODUCT MODAL 
        private void AddEditCloseEventHandler(MessageArgs args)
        {
            this.producto = null;
            showInvProduct = false;

            bus.UnSubscribe<Aig.Auditoria.Events.InvProduct.CloseEvent>(AddEditCloseEventHandler);

            var message = args.GetMessage<Aig.Auditoria.Events.InvProduct.CloseEvent>();

            if (message.Data != null)
            {
                Inspeccion.InspDisposicionFinal.InventarioMedicamento.LProductos = Inspeccion.InspDisposicionFinal.InventarioMedicamento.LProductos != null ? Inspeccion.InspDisposicionFinal.InventarioMedicamento.LProductos : new List<AUD_InvProducto>();

                if (!Inspeccion.InspDisposicionFinal.InventarioMedicamento.LProductos.Contains(message.Data))
                    Inspeccion.InspDisposicionFinal.InventarioMedicamento.LProductos.Add(message.Data);

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
                Inspeccion.UbicacionEstablecimiento = message.Data.Ubicacion;
                Inspeccion.TelefonoEstablecimiento = message.Data.Telefono1 ?? "";

                Inspeccion.InspDisposicionFinal.GeneralesEmpresa.NumLicOperacion = message.Data?.NumLicencia ?? "";
                Inspeccion.InspDisposicionFinal.GeneralesEmpresa.FechaVencLicOperacion = message.Data?.FechaExpiracion ?? null;
                Inspeccion.InspDisposicionFinal.GeneralesEmpresa.Email = message.Data?.Email ?? "";
                Inspeccion.InspDisposicionFinal.GeneralesEmpresa.Telefono = message.Data?.Telefono1 ?? "";
                Inspeccion.InspDisposicionFinal.GeneralesEmpresa.Nombre = message.Data?.Nombre ?? "";
                Inspeccion.InspDisposicionFinal.GeneralesEmpresa.Direccion = message.Data?.Ubicacion ?? "";
                Inspeccion.InspDisposicionFinal.GeneralesEmpresa.Ciudad = message.Data?.Provincia?.Nombre ?? "";
                Inspeccion.InspDisposicionFinal.GeneralesEmpresa.Provincia = message.Data?.Provincia?.Nombre ?? "";
                Inspeccion.InspDisposicionFinal.GeneralesEmpresa.Distrito = message.Data?.Distrito?.Nombre ?? "";
                Inspeccion.InspDisposicionFinal.GeneralesEmpresa.Corregimiento = message.Data?.Corregimiento?.Nombre ?? "";
            }

            this.InvokeAsync(StateHasChanged);
        }

    }

}

using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Services;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Mobsites.Blazor;

namespace Aig.Auditoria.Components.Inspections
{    
    public partial class AperturaCambUbicaFarmacia
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

        SignaturePad signaturePad1;
        SignaturePad signaturePad2;
        SignaturePad signaturePad3;
        SignaturePad signaturePad4;
        SignaturePad signaturePad5;
        SignaturePad signaturePad6;
        SignaturePad.SupportedSaveAsTypes signatureType { get; set; } = SignaturePad.SupportedSaveAsTypes.png;

        bool OpenHourModal { get; set; }=false;
        AUD_DatosHorario DatosHorario { get; set; } = null;

        bool showSignasure { get; set; } = false;

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

                if (signaturePad1 != null)
                {
                    signaturePad1.Image = Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaInspector1;
                }
                if (signaturePad2 != null)
                {
                    signaturePad2.Image = Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaInspector2;
                }
                if (signaturePad3 != null)
                {
                    signaturePad3.Image = Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaInspector3;
                }
                if (signaturePad4 != null)
                {
                    signaturePad4.Image = Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaInspector4;
                }
                if (signaturePad5 != null)
                {
                    signaturePad5.Image = Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaRepresentanteLegal;
                }
                if (signaturePad6 != null)
                {
                    signaturePad6.Image = Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaRegente;
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


        protected async Task OpenHour()
        {
            bus.Subscribe<Aig.Auditoria.Events.OpenHours.OpenHoursAddEdit_CloseEvent>(OpenHour_AddEditCloseEventHandler);
            DatosHorario = new AUD_DatosHorario();
            OpenHourModal = true;
            await this.InvokeAsync(StateHasChanged);
            //await bus.Publish(new Aig.Auditoria.Events.OpenHours.OpenHoursAddEdit_OpenEvent { Data = new AUD_DatosHorario() });
        }
        private void OpenHour_AddEditCloseEventHandler(MessageArgs args)
        {
            OpenHourModal = false;
            DatosHorario = null;
            bus.UnSubscribe<Aig.Auditoria.Events.OpenHours.OpenHoursAddEdit_CloseEvent>(OpenHour_AddEditCloseEventHandler);
            var message = args.GetMessage<Aig.Auditoria.Events.OpenHours.OpenHoursAddEdit_CloseEvent>();
            if (message.Data != null)
            {                
                Inspeccion.InspAperCambUbicFarm?.DatosEstructuraOrganizacional?.HorariosAtencion?.Add(message.Data);
            }
            this.InvokeAsync(StateHasChanged);
        }
        protected async Task RemoveHour(AUD_DatosHorario horario)
        {
            OpenHourModal = false;
            DatosHorario = null;
            Inspeccion.InspAperCambUbicFarm?.DatosEstructuraOrganizacional?.HorariosAtencion?.Remove(horario); 
            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task OnShowSignasure()
        {
            if (!showSignasure)
            {
                showSignasure = true;
                DelayToShowSignasure();
            }            
        }
        async Task DelayToShowSignasure()
        {
            await Task.Delay(2000);
            await FetchData();
        }
        protected async Task OnSignatureChange1(ChangeEventArgs eventArgs)
        {
            Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaInspector1 = null;
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaInspector1 = await signaturePad1.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg1()
        {
            Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaInspector1 = null;
            signaturePad1.Image = null;
        }
        protected async Task OnSignatureChange2(ChangeEventArgs eventArgs)
        {
            Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaInspector2 = null;
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaInspector2 = await signaturePad2.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg2()
        {
            Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaInspector2 = null;
            signaturePad2.Image = null;
        }
        protected async Task OnSignatureChange3(ChangeEventArgs eventArgs)
        {
            Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaInspector3 = null;
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaInspector3 = await signaturePad3.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg3()
        {
            Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaInspector3 = null;
            signaturePad3.Image = null;
        }
        protected async Task OnSignatureChange4(ChangeEventArgs eventArgs)
        {
            Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaInspector4 = null;
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaInspector4 = await signaturePad4.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg4()
        {
            Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaInspector4 = null;
            signaturePad4.Image = null;
        }
        protected async Task OnSignatureChange5(ChangeEventArgs eventArgs)
        {
            Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaRepresentanteLegal = null;
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaRepresentanteLegal = await signaturePad5.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg5()
        {
            Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaRepresentanteLegal = null;
            signaturePad5.Image = null;
        }
        protected async Task OnSignatureChange6(ChangeEventArgs eventArgs)
        {
            Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaRegente = null;
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaRegente = await signaturePad6.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg6()
        {
            Inspeccion.InspAperCambUbicFarm.DatosConclusiones.FirmaRegente = null;
            signaturePad6.Image = null;
        }

    }

}

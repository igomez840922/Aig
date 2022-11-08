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
        SignaturePad.SupportedSaveAsTypes signatureType { get; set; } = SignaturePad.SupportedSaveAsTypes.png;


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
                signaturePad1.Image = Inspeccion.FirmaDNFD1;

                if (Inspeccion.EstablecimientoId == null)
                {
                    Inspeccion.EstablecimientoId = lEstablecimientos?.FirstOrDefault()?.Id ?? null;
                    if (Inspeccion.EstablecimientoId != null)
                    {
                        Inspeccion.UbicacionEstablecimiento = lEstablecimientos.Where(x => x.Id == Inspeccion.EstablecimientoId.Value).FirstOrDefault()?.Ubicacion ?? "";
                    }
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
            await bus.Publish(new Aig.Auditoria.Events.OpenHours.OpenHoursAddEdit_OpenEvent { Data = new AUD_DatosHorario() });
            await this.InvokeAsync(StateHasChanged);
        }
        private void OpenHour_AddEditCloseEventHandler(MessageArgs args)
        {
            bus.UnSubscribe<Aig.Auditoria.Events.OpenHours.OpenHoursAddEdit_CloseEvent>(OpenHour_AddEditCloseEventHandler);
            var message = args.GetMessage<Aig.Auditoria.Events.OpenHours.OpenHoursAddEdit_CloseEvent>();
            if (message.Data != null)
            {                
                Inspeccion.InspAperCambUbicFarm?.DatosEstructuraOrganizacional?.HorariosAtencion?.Add(message.Data);
                this.InvokeAsync(StateHasChanged);
            }
        }
        protected async Task RemoveHour(AUD_DatosHorario horario)
        {
            Inspeccion.InspAperCambUbicFarm?.DatosEstructuraOrganizacional?.HorariosAtencion?.Remove(horario); 
            await this.InvokeAsync(StateHasChanged);
        }


        protected async Task OnSignatureChange1(ChangeEventArgs eventArgs)
        {
            Inspeccion.FirmaDNFD1 = null;
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.FirmaDNFD1 = await signaturePad1.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg1()
        {
            signaturePad1.Image = null;
        }

    }

}

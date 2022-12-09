using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel.Helper;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Duende.IdentityServer.Models;

namespace Aig.Auditoria.Components.Inspections
{   
    public partial class InspectionType
    {
        [Inject]
        IInspectionsService inspeccionService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }


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
                //await FetchData();
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

        
        protected async Task FetchData()
        {            

            await this.InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Saving Data
        /// </summary>        

        protected async Task Cancel()
        {
            bus.Publish(new Aig.Auditoria.Events.Inspections.AddEditCloseEvent { Inspeccion =  null });
            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task SelectInspectionType(enumAUD_TipoActa tipoActa)
        {
            try {
                AUD_InspeccionTB data = null;
                switch (tipoActa)
                {
                    case enumAUD_TipoActa.RR:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, InspRetiroRetencion = new AUD_InspRetiroRetencionTB() };
                            break;
                        }
                    case enumAUD_TipoActa.AF:
                    case enumAUD_TipoActa.CUF:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, InspAperCambUbicFarm = new AUD_InspAperCambUbicFarmTB() };
                            break;
                        }
                    case enumAUD_TipoActa.AA:
                    case enumAUD_TipoActa.CUA:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, InspAperCambUbicAgen = new AUD_InspAperCambUbicAgenTB() };
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.AFM:
                    case DataModel.Helper.enumAUD_TipoActa.AFC:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, InspAperFabricante = new AUD_InspAperFabricanteTB() };
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.VF:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, InspRutinaVigFarmacia = new AUD_InspRutinaVigFarmaciaTB() };
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.INV:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, InspInvestigacion = new AUD_InspInvestigacionTB() };
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.BPMCD:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, InspGuiBPMFabMedicamento = new AUD_InspGuiBPMFabMedicamentoTB() };
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.AECA:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, InspAperturaCosmetArtesanal = new AUD_InspAperturaCosmetArtesanalTB () };
                            break;
                        }
                    default:
                        {
                            return;
                        }
                }

                bus.Publish(new Aig.Auditoria.Events.Inspections.AddEditCloseEvent { Inspeccion = data });
                await this.InvokeAsync(StateHasChanged);
            }
            catch(Exception ex) { }
            
        }

       

    }

}

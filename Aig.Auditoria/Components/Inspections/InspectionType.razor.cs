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
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspRetiroRetencion = new AUD_InspRetiroRetencionTB() };
                            break;
                        }
                    case enumAUD_TipoActa.AF:
                    case enumAUD_TipoActa.CUF:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspAperCambUbicFarm = new AUD_InspAperCambUbicFarmTB() };
                            break;
                        }
                    case enumAUD_TipoActa.AA:
                    case enumAUD_TipoActa.CUA:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspAperCambUbicAgen = new AUD_InspAperCambUbicAgenTB() };
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.AFM:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspAperFabricante = new AUD_InspAperFabricanteTB() };
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.AFC:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspAperFabricanteCosmetMed = new AUD_InspAperFabricanteCosmetMedTB() };
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.VF:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspRutinaVigFarmacia = new AUD_InspRutinaVigFarmaciaTB() };
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.VA:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspRutinaVigAgencia = new AUD_InspRutinaVigAgenciaTB() };
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.INV:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspInvestigacion = new AUD_InspInvestigacionTB() };
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.BPMCD:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspGuiBPMFabCosmeticoMed = new AUD_InspGuiBPMFabCosmeticoMedTB() };
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.AECA:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspAperturaCosmetArtesanal = new AUD_InspAperturaCosmetArtesanalTB () };
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.BPMMN:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspGuiBPMFabNatMedicina = new AUD_InspGuiBPMFabNatMedicinaTB() };
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.COP:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspCierreOperacion = new AUD_InspCierreOperacionTB() };
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.DFP:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspDisposicionFinal = new AUD_InspDisposicionFinalTB() };
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.BPMFM:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspGuiaBPMFabricanteMed = new AUD_InspGuiaBPMFabricanteMedTB() };
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.BPMAM:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspGuiaBPMLabAcondicionador = new AUD_InspGuiaBPMLabAcondicionadorTB() };
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.BPA:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspGuiaBPM_Bpa = new AUD_InspGuiaBPM_BpaTB() };
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.ABP:
                    case DataModel.Helper.enumAUD_TipoActa.CUBP:
                        {
                            data = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspAperCambUbicBotiquin = new AUD_InspAperCambUbicBotiquinTB() };
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

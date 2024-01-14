using AuditoriaApp.Services;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Helper;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AuditoriaApp.Pages.Inspections
{
    public partial class New
    {
        [Inject]
        IInspectionService inspectionService { get; set; }

        [Inject]
        IDialogService DialogService { get; set; }

        [Inject]
        IProvinciaService provinciaService { get; set; }
        [Inject]
        ICorregimientoService corregimientoService { get; set; }
        [Inject]
        IDistritoService distritoService { get; set; }

       
        List<InspectionTypeMenuOptionModel> MenuOptions { get; set; } = new List<InspectionTypeMenuOptionModel>();

        List<ProvinciaTB> LProvincias { get; set; }
        List<DistritoTB> LDistritos { get; set; }
        List<CorregimientoTB> LCorregimientos { get; set; }

        public APP_Inspeccion model { get; set; } 

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            //bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            base.OnInitialized();
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {

                await FetchData();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        public void Dispose()
        {
            //bus.UnSubscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
        }

        protected async Task FetchData()
        {
            try
            {
                foreach (enumAUD_TipoActa dt in Enum.GetValues(typeof(enumAUD_TipoActa)))
                {
                    if (dt != enumAUD_TipoActa.None)
                    {
                        MenuOptions.Add(new InspectionTypeMenuOptionModel() { Name = DataModel.Helper.Helper.GetDescription<enumAUD_TipoActa>(dt), InspectionType = dt });
                    }
                }

                LoadData();
            }
            catch { }
            finally { await this.InvokeAsync(StateHasChanged); }

        }

        protected async Task LoadData()
        {
            
            LProvincias = LProvincias?.Count > 0 ? LProvincias : (await provinciaService.GetAll());
            LDistritos = LDistritos?.Count > 0 ? LDistritos : (await distritoService.GetAllByProv(model?.Inspeccion?.DatosEstablecimiento?.Provincia?.Id ?? 0));
            LCorregimientos = LCorregimientos?.Count > 0 ? LCorregimientos : (await corregimientoService.GetAllByDist(model?.Inspeccion?.DatosEstablecimiento?.Distrito?.Id ?? 0));

            //await this.InvokeAsync(StateHasChanged);
        }

        protected async Task Cancel()
        {
            try
            {
                navigationManager.NavigateTo($"inspections");
            }
            catch { }
            finally { await this.InvokeAsync(StateHasChanged); }

        }

        protected async Task InspectionTypeSelected(enumAUD_TipoActa tipoActa)
        {
            try
            {
                if(tipoActa != enumAUD_TipoActa.None)
                {
                    model = new APP_Inspeccion() { NumActa = "000000"};
                    
                    switch (tipoActa)
                    {
                        case enumAUD_TipoActa.RR:
                            {
                                model.Inspeccion = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspRetiroRetencion = new AUD_InspRetiroRetencionTB() };
                                break;
                            }
                        case enumAUD_TipoActa.AF:
                        case enumAUD_TipoActa.CUF:
                            {
                                model.Inspeccion = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspAperCambUbicFarm = new AUD_InspAperCambUbicFarmTB() };
                                break;
                            }
                        case enumAUD_TipoActa.AA:
                        case enumAUD_TipoActa.CUA:
                            {
                                model.Inspeccion = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspAperCambUbicAgen = new AUD_InspAperCambUbicAgenTB() };
                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.AFM:
                            {
                                model.Inspeccion = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspAperFabricante = new AUD_InspAperFabricanteTB() };
                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.AFC:
                            {
                                model.Inspeccion = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspAperFabricanteCosmetMed = new AUD_InspAperFabricanteCosmetMedTB() };
                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.VF:
                            {
                                model.Inspeccion = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspRutinaVigFarmacia = new AUD_InspRutinaVigFarmaciaTB() };
                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.VA:
                            {
                                model.Inspeccion = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspRutinaVigAgencia = new AUD_InspRutinaVigAgenciaTB() };
                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.INV:
                            {
                                model.Inspeccion = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspInvestigacion = new AUD_InspInvestigacionTB() };
                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.BPMCD:
                            {
                                model.Inspeccion = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspGuiBPMFabCosmeticoMed = new AUD_InspGuiBPMFabCosmeticoMedTB() };
                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.AECA:
                            {
                                model.Inspeccion = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspAperturaCosmetArtesanal = new AUD_InspAperturaCosmetArtesanalTB() };
                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.BPMMN:
                            {
                                model.Inspeccion = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspGuiBPMFabNatMedicina = new AUD_InspGuiBPMFabNatMedicinaTB() };
                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.COP:
                            {
                                model.Inspeccion = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspCierreOperacion = new AUD_InspCierreOperacionTB() };
                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.DFP:
                            {
                                model.Inspeccion = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspDisposicionFinal = new AUD_InspDisposicionFinalTB() };
                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.BPMFM:
                            {
                                model.Inspeccion = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspGuiaBPMFabricanteMed = new AUD_InspGuiaBPMFabricanteMedTB() };
                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.BPMAM:
                            {
                                model.Inspeccion = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspGuiaBPMLabAcondicionador = new AUD_InspGuiaBPMLabAcondicionadorTB() };
                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.BPA:
                            {
                                model.Inspeccion = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspGuiaBPM_Bpa = new AUD_InspGuiaBPM_BpaTB() };
                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.ABP:
                        case DataModel.Helper.enumAUD_TipoActa.CUBP:
                            {
                                model.Inspeccion = new AUD_InspeccionTB() { TipoActa = tipoActa, DatosEstablecimiento = new AUD_DatosEstablecimientoTB(), InspAperCambUbicBotiquin = new AUD_InspAperCambUbicBotiquinTB() };
                                break;
                            }
                        default:
                            {
                                return;
                            }
                    }

                    model.Inspeccion.TipoActa = tipoActa;
                    model.Inspeccion.NumActa = model.NumActa;
                    model.Inspeccion.EstablecimientoId = 0;
                    model.Inspeccion.ParticipantesDNFD.LParticipantes = new List<Participante>();
                    model.Inspeccion.DatosEstablecimiento.EstablecimientoId = model.Inspeccion.EstablecimientoId;
                    model.Inspeccion.DatosEstablecimiento.NumLicencia = "000000";
                }
            }
            catch { }
            finally { await this.InvokeAsync(StateHasChanged); }

        }

        protected async Task Save()
        {
            try
            {
                model.PendingUpdate = true;
                model.Inspeccion.PendingUpdate = true;
                model.Inspeccion.DatosEstablecimiento.PendingUpdate = true;
                model.Inspeccion.ParticipantesDNFD.PendingUpdate = true;
                var data = await inspectionService.Save(model);
                if (data != null)
                {
                    snackbar.Add("Datos guardados satisfactoriamente", Severity.Info);
                    navigationManager.NavigateTo($"inspectionsedit/{data.Id}");
                    return;
                }
            }
            catch (Exception ex)
            {
                snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                await this.InvokeAsync(StateHasChanged);
            }
            snackbar.Add("Error al guardar los datos", Severity.Error);
        }

        //////////////////////////////
        ///
        private async Task OnProvinciaChanged(ProvinciaTB provincia)
        {
            model.Inspeccion.DatosEstablecimiento.Distrito = null;
            model.Inspeccion.DatosEstablecimiento.Corregimiento = null;
            LDistritos = null; LCorregimientos = null;
            LDistritos = LDistritos?.Count > 0 ? LDistritos : (await distritoService.GetAllByProv(provincia?.Id ?? 0));
            LDistritos = LDistritos != null ? LDistritos : new List<DistritoTB>();
            LCorregimientos = LCorregimientos != null ? LCorregimientos : new List<CorregimientoTB>();
            await this.InvokeAsync(StateHasChanged);
        }
        private async Task OnDistritoChanged(DistritoTB distrito)
        {
            model.Inspeccion.DatosEstablecimiento.Corregimiento = null;
            LCorregimientos = null;
            LCorregimientos = LCorregimientos?.Count > 0 ? LCorregimientos : (await corregimientoService.GetAllByDist(distrito?.Id ?? 0));
            LCorregimientos = LCorregimientos != null ? LCorregimientos : new List<CorregimientoTB>();
            await this.InvokeAsync(StateHasChanged);
        }

        ////////////////////////////////////
        ///
        private async Task EditParticipant(Participante data = null)
        {
            data = data != null ? data : new Participante();
            var parameters = new DialogParameters { ["Data"] = data };
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<Components.Dialog.Participantes.AddEdit>(data != null ? "Editar Participante" : "Agregar Participante", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                if (result.Data != null)
                {
                    var actividad = (Participante)result.Data;
                    model.Inspeccion.ParticipantesDNFD.LParticipantes = model.Inspeccion.ParticipantesDNFD.LParticipantes?.Count > 0 ? model.Inspeccion.ParticipantesDNFD.LParticipantes : new List<Participante>();
                    if (!model.Inspeccion.ParticipantesDNFD.LParticipantes.Contains(actividad))
                        model.Inspeccion.ParticipantesDNFD.LParticipantes.Add(actividad);
                    await this.InvokeAsync(StateHasChanged);
                }
            }

        }
        private async Task RemoveParticipant(Participante data)
        {
            //Open Modal
            var parameters = new DialogParameters{
             { nameof(Components.Dialog.DialogComponent.ContentText), string.Format("Está seguro desea eliminar el dato seleccionado?") }};
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<Components.Dialog.DialogComponent>("Confirmar Eliminar", parameters, options);
            var result = await dialog.Result;
            if (result.Cancelled)
            {
                return;
            }

            model.Inspeccion.ParticipantesDNFD.LParticipantes.Remove(data);
            await this.InvokeAsync(StateHasChanged);
        }

    }
}

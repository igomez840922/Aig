using AuditoriaApp.Events.Overlay;
using AuditoriaApp.Services;
using DataModel;
using DataModel.Helper;
using DataModel.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AuditoriaApp.Components.Inspections._3_RutinaVigilanciaFarmacia
{
    public partial class Cap01
    {
        [Inject]
        IInspectionService inspectionService { get; set; }
        [Inject]
        IProvinciaService provinciaService { get; set; }
        [Inject]
        ICorregimientoService corregimientoService { get; set; }
        [Inject]
        IDistritoService distritoService { get; set; }

        [Inject]
        IDialogService DialogService { get; set; }

        [Parameter]
        public DataModel.APP_Inspeccion Inspeccion { get; set; }

        [Parameter]
        public EventCallback BackToMain { get; set; }
       

        List<ProvinciaTB> LProvincias { get; set; }
        List<DistritoTB> LDistritos { get; set; }
        List<CorregimientoTB> LCorregimientos { get; set; }

        /////////////////////////
        ///
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

        protected async Task FetchData()
        {
            try
            {
               await LoadData();
            }
            catch { }
            finally
            {
                await this.InvokeAsync(StateHasChanged);
            }
        }

        protected async Task LoadData()
        {
            LProvincias = LProvincias?.Count > 0 ? LProvincias : (await provinciaService.GetAll());
            LDistritos = LDistritos?.Count > 0 ? LDistritos : (await distritoService.GetAllByProv(Inspeccion?.Inspeccion?.DatosEstablecimiento?.Provincia?.Id ?? 0));
            LCorregimientos = LCorregimientos?.Count > 0 ? LCorregimientos : (await corregimientoService.GetAllByDist(Inspeccion?.Inspeccion?.DatosEstablecimiento?.Distrito?.Id ?? 0));

            await this.InvokeAsync(StateHasChanged);
        }

        ////////////////////
        ///

        protected async Task Cancel(bool warning=true)
        {
            try
            {                
                if(warning)
                {
                    var parameters = new DialogParameters{
             { nameof(Components.Dialog.DialogComponent.ContentText), string.Format("Los cambios no guardados se perderán. Está seguro desea salir?") }};
                    var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
                    var dialog = _dialogService.Show<Components.Dialog.DialogComponent>("Confirmar Salir", parameters, options);
                    var result = await dialog.Result;
                    if (result.Cancelled)
                    {
                        return;
                    }
                }
                this.BackToMain.InvokeAsync();
            }
            catch (Exception ex)
            {
                snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                await this.InvokeAsync(StateHasChanged);
            }
        }

        protected async Task<bool> Save()
        {
            try
            {
                Inspeccion.PendingUpdate = true;
                Inspeccion.Inspeccion.PendingUpdate = true;
                Inspeccion.Inspeccion.DatosEstablecimiento.PendingUpdate = true;
                Inspeccion.Inspeccion.ParticipantesDNFD.PendingUpdate = true;
                var data = inspectionService.Save(Inspeccion);
                if(data != null) {
                    snackbar.Add("Datos guardados satisfactoriamente", Severity.Info);
                    return true;
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
            return false;
        }

        protected async Task SaveExit()
        {
            try
            {
                if(await Save())
                {
                    await Cancel(false);
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
        }

        //////////////////////////////
        ///
        private async Task OnProvinciaChanged(ProvinciaTB provincia)
        {
            Inspeccion.Inspeccion.DatosEstablecimiento.Distrito = null;
            Inspeccion.Inspeccion.DatosEstablecimiento.Corregimiento = null;
            LDistritos = null; LCorregimientos = null;
            LDistritos = LDistritos?.Count > 0 ? LDistritos : (await distritoService.GetAllByProv(provincia?.Id ?? 0));
            LDistritos = LDistritos != null ? LDistritos : new List<DistritoTB>();
            LCorregimientos = LCorregimientos != null ? LCorregimientos : new List<CorregimientoTB>();
            await this.InvokeAsync(StateHasChanged);
        }
        private async Task OnDistritoChanged(DistritoTB distrito)
        {
            Inspeccion.Inspeccion.DatosEstablecimiento.Corregimiento = null;
            LCorregimientos = null;
            LCorregimientos = LCorregimientos?.Count > 0 ? LCorregimientos : (await corregimientoService.GetAllByDist(distrito?.Id ?? 0));
            LCorregimientos = LCorregimientos != null ? LCorregimientos : new List<CorregimientoTB>();
            await this.InvokeAsync(StateHasChanged);
        }

        ////////////////////////////////////
        ///
        private async Task EditParticipant(Participante data = null)
        {
            data = data!= null ? data : new Participante();
            var parameters = new DialogParameters { ["Data"] = data };
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<Components.Dialog.Participantes.AddEdit>(data!=null? "Editar Participante" : "Agregar Participante", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                if (result.Data != null)
                {
                    var actividad = (Participante)result.Data;
                    Inspeccion.Inspeccion.ParticipantesDNFD.LParticipantes = Inspeccion.Inspeccion.ParticipantesDNFD.LParticipantes?.Count > 0 ? Inspeccion.Inspeccion.ParticipantesDNFD.LParticipantes : new List<Participante>();
                    if (!Inspeccion.Inspeccion.ParticipantesDNFD.LParticipantes.Contains(actividad))
                        Inspeccion.Inspeccion.ParticipantesDNFD.LParticipantes.Add(actividad);
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

            Inspeccion.Inspeccion.ParticipantesDNFD.LParticipantes.Remove(data);
            await this.InvokeAsync(StateHasChanged);
        }
    }

}

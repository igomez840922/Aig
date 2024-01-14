using AuditoriaApp.Services;
using DataModel;
using DataModel.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AuditoriaApp.Components.Inspections._15_BpmBPA
{
    public partial class Cap04
    {
        [Inject]
        IInspectionService inspectionService { get; set; }
        //[Inject]
        //IPaisService paisService { get; set; }


        [Inject]
        IDialogService dialogService { get; set; }

        [Parameter]
        public DataModel.APP_Inspeccion Inspeccion { get; set; }

        [Parameter]
        public EventCallback BackToMain { get; set; }

        //List<PaisTB> LPaises { get; set; }

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
                Inspeccion.Inspeccion.InspGuiaBPM_Bpa.OtrosFuncionarios = Inspeccion.Inspeccion.InspGuiaBPM_Bpa.OtrosFuncionarios != null ? Inspeccion.Inspeccion.InspGuiaBPM_Bpa.OtrosFuncionarios : new AUD_OtrosFuncionarios();
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
            //LPaises = await paisService.GetAll();

            await this.InvokeAsync(StateHasChanged);
        }

        ////////////////////
        ///

        protected async Task Cancel(bool warning = true)
        {
            try
            {
                if (warning)
                {
                    var parameters = new DialogParameters{
             { nameof(Components.Dialog.DialogComponent.ContentText), string.Format("Los cambios no guardados se perderán. Está seguro desea salir?") }};
                    var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
                    var dialog = dialogService.Show<Components.Dialog.DialogComponent>("Confirmar Salir", parameters, options);
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
                Inspeccion.Inspeccion.InspGuiaBPM_Bpa.PendingUpdate = true;
                Inspeccion.Inspeccion.InspGuiaBPM_Bpa.OtrosFuncionarios.PendingUpdate = true;
                var data = await inspectionService.Save(Inspeccion);
                if (data != null)
                {
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
                if (await Save())
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
        private async Task EditParticipant(DatosPersona data = null)
        {
            try {
                //data = data != null ? data : new DatosPersona();
                var parameters = new DialogParameters { ["Data"] = data };
                var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true, DisableBackdropClick = true };
                var dialog = _dialogService.Show<Components.Dialog.Personas.AddEdit>(data != null ? "Editar Funcionario" : "Agregar Funcionario", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    if (result.Data != null)
                    {
                        var actividad = (DatosPersona)result.Data;
                        Inspeccion.Inspeccion.InspGuiaBPM_Bpa.OtrosFuncionarios.LPersona = Inspeccion.Inspeccion.InspGuiaBPM_Bpa.OtrosFuncionarios.LPersona?.Count > 0 ? Inspeccion.Inspeccion.InspGuiaBPM_Bpa.OtrosFuncionarios.LPersona : new List<DatosPersona>();
                        if (!Inspeccion.Inspeccion.InspGuiaBPM_Bpa.OtrosFuncionarios.LPersona.Contains(actividad))
                            Inspeccion.Inspeccion.InspGuiaBPM_Bpa.OtrosFuncionarios.LPersona.Add(actividad);
                        await this.InvokeAsync(StateHasChanged);
                    }
                }
            }
            catch(Exception ex) 
            { }
        }
        private async Task RemoveParticipant(DatosPersona data)
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

            Inspeccion.Inspeccion.InspGuiaBPM_Bpa.OtrosFuncionarios.LPersona.Remove(data);
            await this.InvokeAsync(StateHasChanged);
        }

    }
}

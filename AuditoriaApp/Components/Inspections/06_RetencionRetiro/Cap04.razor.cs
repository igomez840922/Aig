using AuditoriaApp.Services;
using DataModel;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AuditoriaApp.Components.Inspections._06_RetencionRetiro
{
    public partial class Cap04
    {
        [Inject]
        IInspectionService inspectionService { get; set; }
        [Inject]
        IPaisService paisService { get; set; }


        [Inject]
        IDialogService dialogService { get; set; }

        [Parameter]
        public DataModel.APP_Inspeccion Inspeccion { get; set; }

        [Parameter]
        public EventCallback BackToMain { get; set; }

        List<PaisTB> LPaises { get; set; }

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
                Inspeccion.Inspeccion.InspRetiroRetencion.DatosRetiroRetencion = Inspeccion.Inspeccion.InspRetiroRetencion.DatosRetiroRetencion != null ? Inspeccion.Inspeccion.InspRetiroRetencion.DatosRetiroRetencion : new AUD_DatosRetiroRetencion();
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
            LPaises = await paisService.GetAll();

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
                Inspeccion.Inspeccion.InspRetiroRetencion.PendingUpdate = true;
                Inspeccion.Inspeccion.InspRetiroRetencion.DatosRetiroRetencion.PendingUpdate = true;
                var data = inspectionService.Save(Inspeccion);
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
        private async Task EditProduct(AUD_ProdRetiroRetencionTB data = null)
        {
            data = data != null ? data : new AUD_ProdRetiroRetencionTB();
            var parameters = new DialogParameters { ["Data"] = data };
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<Components.Dialog.ProductosRetirados.AddEdit>(data != null ? "Editar Producto" : "Agregar Producto", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                if (result.Data != null)
                {
                    var actividad = (AUD_ProdRetiroRetencionTB)result.Data;
                    Inspeccion.Inspeccion.InspRetiroRetencion.DatosRetiroRetencion.LProductos = Inspeccion.Inspeccion.InspRetiroRetencion.DatosRetiroRetencion.LProductos?.Count > 0 ? Inspeccion.Inspeccion.InspRetiroRetencion.DatosRetiroRetencion.LProductos : new List<AUD_ProdRetiroRetencionTB>();
                    if (!Inspeccion.Inspeccion.InspRetiroRetencion.DatosRetiroRetencion.LProductos.Contains(actividad))
                        Inspeccion.Inspeccion.InspRetiroRetencion.DatosRetiroRetencion.LProductos.Add(actividad);
                    await this.InvokeAsync(StateHasChanged);
                }
            }

        }
        private async Task RemoveProduct(AUD_ProdRetiroRetencionTB data)
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

            Inspeccion.Inspeccion.InspRetiroRetencion.DatosRetiroRetencion.LProductos.Remove(data);
            await this.InvokeAsync(StateHasChanged);
        }

    }
}

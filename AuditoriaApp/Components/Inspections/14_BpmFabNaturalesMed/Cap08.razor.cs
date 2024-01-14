using AuditoriaApp.Services;
using DataModel;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditoriaApp.Components.Inspections._14_BpmFabNaturalesMed
{
    public partial class Cap08
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

                if (Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.UbicacionDisenoConstruc == null)
                {
                    Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.Inicializa_UbicacionDisenoConstruc();
                }
                if (Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.Almacenes == null)
                {
                    Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.Inicializa_Almacenes();
                }
                if (Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.AreaRecepLimpieza == null)
                {
                    Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.Inicializa_AreaRecepLimpieza();
                }
                if (Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.AreaSecadoMolienda == null)
                {
                    Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.Inicializa_AreaSecadoMolienda();
                }
                if (Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.AreaDispensadoMatPrima == null)
                {
                    Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.Inicializa_AreaDispensadoMatPrima();
                }
                if (Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.AreaProduccion == null)
                {
                    Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.Inicializa_AreaProduccion();
                }
                if (Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.AreaEnvasadoEmpaque == null)
                {
                    Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.Inicializa_AreaEnvasadoEmpaque();
                }
                if (Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.AreaAuxiliares == null)
                {
                    Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.Inicializa_AreaAuxiliares();
                }
                if (Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.AreaControlCalidad == null)
                {
                    Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.Inicializa_AreaControlCalidad();
                }

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
                Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.PendingUpdate = true;
                Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.UbicacionDisenoConstruc.PendingUpdate = true;
                Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.Almacenes.PendingUpdate = true;
                Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.AreaRecepLimpieza.PendingUpdate = true;
                Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.AreaSecadoMolienda.PendingUpdate = true;
                Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.AreaDispensadoMatPrima.PendingUpdate = true;
                Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.AreaProduccion.PendingUpdate = true;
                Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.AreaEnvasadoEmpaque.PendingUpdate = true;
                Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.AreaAuxiliares.PendingUpdate = true;
                Inspeccion.Inspeccion.InspGuiBPMFabNatMedicina.AreaControlCalidad.PendingUpdate = true;
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
    }
}

using AuditoriaApp.Events.Overlay;
using AuditoriaApp.Services;
using DataModel;
using DataModel.Helper;
using DataModel.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AuditoriaApp.Components.Inspections._13_BpmFabCosmeticosDesinf
{
    public partial class Index
    {
        [Inject]
        IInspectionService inspectionService { get; set; }

        [Inject]
        IDialogService DialogService { get; set; }

        [Parameter]
        public long Id { get; set; }

        public DataModel.APP_Inspeccion Inspeccion { get; set; }
        
        [Parameter] 
        public EventCallback BackToMain { get; set; }

        List<MenuOptionModel> MenuOptions { get; set; } = new List<MenuOptionModel>();
        enumSelectedChapter selectedChapter { get; set; } = enumSelectedChapter.None;

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
                MenuOptions = MenuOptions?.Count > 0? MenuOptions: new List<MenuOptionModel>()
                {
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap01,  Name="Información General"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap02,  Name="Información del Representante Legal o Propietario"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap03,  Name="Datos sobre el Regente Farmacéutico de la Empresa"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap04,  Name="Funcionarios de la Empresa"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap05,  Name="Generalidades"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap06,  Name="Administración e Información General"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap07,  Name="ALMACENES - Condiciones Externas"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap08,  Name="ALMACENES - Condiciones Internas"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap09,  Name="ALMACENES - Área de Recepción de Materia Prima"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap10,  Name="ALMACENES - Almacén de Materia Prima"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap11,  Name="ALMACENES - Área de almacenamiento de Materiales de Acondicionamiento, Empaque y Envase"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap12,  Name="ALMACENES - Recepción de Producto Terminado (de producción al almacén)"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap13,  Name="ALMACENES - Almacén de Producto Terminado"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap14,  Name="ALMACENES - Área de productos Devueltos y/o Rechazados"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap15,  Name="ALMACENES - Distribución de Productos Terminados"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap16,  Name="ALMACENES - Manejo de quejas y reclamos de productos comercializados"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap17,  Name="ALMACENES - Retiro de Productos del Mercado"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap18,  Name="SISTEMAS CRITICOS DE APOYO - Sistemas e Instalaciones de Agua"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap19,  Name="SISTEMAS CRITICOS DE APOYO - Osmosis Inversa"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap20,  Name="SISTEMAS CRITICOS DE APOYO - Sistema de Deionización"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap21,  Name="SISTEMAS CRITICOS DE APOYO - Calibraciones y Verificaciones de equipo"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap22,  Name="SISTEMAS CRITICOS DE APOYO - Validaciones"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap23,  Name="SISTEMAS CRITICOS DE APOYO - Mantenimiento de áreas y equipos"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap24,  Name="ÁREAS DE PRODUCCIÓN - Condiciones Externas"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap25,  Name="ÁREAS DE PRODUCCIÓN - Condiciones Internas"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap26,  Name="ÁREAS DE PRODUCCIÓN - Organización y Documentación"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap27,  Name="ÁREAS DE PRODUCCIÓN - Área de Dispensación de Ordenes de Fabricación"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap28,  Name="ÁREAS DE PRODUCCIÓN - Fabricación de Productos Desinfectantes"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap29,  Name="ÁREAS DE PRODUCCIÓN - Fabricación de Plaguicidas"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap30,  Name="ÁREAS DE PRODUCCIÓN - Fabricación de Cosméticos"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap31,  Name="ACONDICIONAMIENTO - Área de Envasado"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap32,  Name="ACONDICIONAMIENTO - Área de Etiquetado y Empaque"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap33,  Name="CONTROL DE CALIDAD - Laboratorio de Control de Calidad"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap34,  Name="CONTROL DE CALIDAD - Análisis por Contrato"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap35,  Name="Inspecciones y Auditoría"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap36,  Name="Conclusiones"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap37,  Name="Firmas"},
                };

                await inspectionService.Reload();

                Inspeccion = await inspectionService.Get(Id);
            }
            catch { }
            finally
            {
                await this.InvokeAsync(StateHasChanged);
            }
        }


        ////////////////////
        ///

        //Abrimos un capitulo Determinado
        protected async Task SelectChapter(enumSelectedChapter selectedChapter)
        {
            try
            { 
                this.selectedChapter = selectedChapter;    
                
                FetchData();
            }
            catch { }
            finally
            {
                await this.InvokeAsync(StateHasChanged);
            }
        }
        protected async Task Cancel()
        {
            try
            {
                this.BackToMain.InvokeAsync();
            }
            catch { }
            finally
            {
                await this.InvokeAsync(StateHasChanged);
            }
        }

        //Call Add/Edit payment Order
        private async Task SyncData()
        {
            await bus.Publish(new OverlayShowEvent { Show = true });
            try
            {
                await inspectionService.Save(Inspeccion);

                if(await inspectionService.InspectionsUploadOne(Inspeccion.Id))
                {
                    //await FetchData();
                    snackbar.Add("Sincronización Finalizada", Severity.Info);

                    await Cancel();
                }
                else
                {
                    snackbar.Add("Error durante la Sincronización", Severity.Error);
                }
            }
            catch
            {
                snackbar.Add("Error durante la Sincronización", Severity.Error);
            }
            finally { await bus.Publish(new OverlayShowEvent { Show = false }); }
        }
    }
}

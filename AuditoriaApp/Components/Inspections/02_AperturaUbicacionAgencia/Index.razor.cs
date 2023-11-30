using AuditoriaApp.Events.Overlay;
using AuditoriaApp.Services;
using DataModel;
using DataModel.Helper;
using DataModel.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AuditoriaApp.Components.Inspections._02_AperturaUbicacionAgencia
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
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap02,  Name="Información del Solicitante"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap03,  Name="Información del Regente"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap04,  Name="Condiciones y Características del Establecimiento"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap05,  Name="Área de Recepción de Productos"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap06,  Name="Área de Almacenamiento"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap07,  Name="Área de Productos Devueltos y Vencidos"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap08,  Name="Área de Productos Retirados del Mercado"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap09,  Name="Área de Despacho de Productos"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap10,  Name="Área de Almacenamiento de Productos que Requieren Cadena de Frío"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap11,  Name="Área de Almacenamiento de Productos Volátiles"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap12,  Name="Área de Almacenamiento de Plaguicidas de Uso Doméstico y de Salud Pública"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap13,  Name="Área de Almacenamiento de Materias Primas para la Indústria Farmacéutica"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap14,  Name="Área de Almacenamiento de Productos Sujetos a Control"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap15,  Name="Procedimientos / Transporte"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap16,  Name="Actividades"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap17,  Name="Productos"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap18,  Name="Conclusiones"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap19,  Name="Firmas"},
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

                var response = await inspectionService.InspectionsUploadOne(Inspeccion.Id);
                if (response.Result)
                {
                    //await FetchData();
                    snackbar.Add("Sincronización Finalizada", Severity.Info);

                    await Cancel();
                }
                else
                {
                    snackbar.Add(string.Format("Error durante la Sincronización. {0}", response.Message), Severity.Error);
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

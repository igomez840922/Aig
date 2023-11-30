using AuditoriaApp.Events.Overlay;
using AuditoriaApp.Services;
using DataModel;
using DataModel.Helper;
using DataModel.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AuditoriaApp.Components.Inspections._14_BpmFabNaturalesMed
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
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap05,  Name="Información General"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap06,  Name="Capítulo 5"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap07,  Name="Capítulo 6"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap08,  Name="Capítulo 7"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap09,  Name="Capítulo 8"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap10,  Name="Capítulo 9"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap11,  Name="Capítulo 10"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap12,  Name="Capítulo 11"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap13,  Name="Capítulo 12"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap14,  Name="Capítulo 13"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap15,  Name="Capítulo 14"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap16,  Name="Capítulo 15"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap17,  Name="Capítulo 16"},
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

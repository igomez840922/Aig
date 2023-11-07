using AuditoriaApp.Events.Overlay;
using AuditoriaApp.Services;
using DataModel;
using DataModel.Helper;
using DataModel.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditoriaApp.Components.Inspections._01_AperturaUbicacionFarmacia
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
                 new MenuOptionModel() { Chapter = enumSelectedChapter.Cap04,  Name="Estructura Organizativa de la Farmacia"},
                 new MenuOptionModel() { Chapter = enumSelectedChapter.Cap05,  Name="Infraestructura de Farmacia"},
                 new MenuOptionModel() { Chapter = enumSelectedChapter.Cap06,  Name="Recetario"},
                 new MenuOptionModel() { Chapter = enumSelectedChapter.Cap07,  Name="Preguntas"},
                 new MenuOptionModel() { Chapter = enumSelectedChapter.Cap08,  Name="Área de Productos Controlados"},
                 new MenuOptionModel() { Chapter = enumSelectedChapter.Cap09,  Name="Área de Almacen de Medicamentos y otros Productos para la Salud Humana"},
                 new MenuOptionModel() { Chapter = enumSelectedChapter.Cap10,  Name="Área de Almacen de Alcohol u otros productos inflamables"},
                 new MenuOptionModel() { Chapter = enumSelectedChapter.Cap11,  Name="Conclusiones"},
                 new MenuOptionModel() { Chapter = enumSelectedChapter.Cap12,  Name="Firmas"},
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

﻿using AuditoriaApp.Events.Overlay;
using AuditoriaApp.Services;
using DataModel;
using DataModel.Helper;
using DataModel.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AuditoriaApp.Components.Inspections._12_BpmAcondMedicamentos
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
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap06,  Name="Organización y Personal"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap07,  Name="Edificio e Instalaciones. Generalidades"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap08,  Name="Edificio e Instalaciones. Almacenes"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap09,  Name="Edificio e Instalaciones. Otras Áreas"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap10,  Name="Equipo"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap11,  Name="Materiales y Productos"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap12,  Name="Documentación"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap13,  Name="Acondicionamiento"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap14,  Name="Garantía de Calidad"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap15,  Name="Control de Calidad"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap16,  Name="Producción y Análisis por Contrato"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap17,  Name="Validación"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap18,  Name="Quejas, Reclamos y Retiros de Productos"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap19,  Name="Autoinspección y Auditoría de Calidad"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap20,  Name="Conclusiones"},
                  new MenuOptionModel() { Chapter = enumSelectedChapter.Cap21,  Name="Firmas"},
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

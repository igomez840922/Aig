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

namespace AuditoriaApp.Components.Inspections._1_AperturaUbicacionFarmacia
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

        List<MenuOptionModel> MenuOptions { get; set; } = new List<MenuOptionModel>();
        enumSelectedChapter selectedChapter { get; set; } = enumSelectedChapter.None;

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

        protected async Task Save()
        {
            try
            {

            }
            catch { }
            finally
            {
                await this.InvokeAsync(StateHasChanged);
            }
        }

        protected async Task SaveExit()
        {
            try
            {
                await Save();
                await Cancel();
            }
            catch { }
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
    }

}

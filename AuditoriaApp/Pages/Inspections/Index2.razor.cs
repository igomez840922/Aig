using AuditoriaApp.Services;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditoriaApp.Events.Overlay;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AuditoriaApp.Pages.Inspections
{
    public partial class Index2
    {
        [Inject]
        IInspectionService inspectionService { get; set; }

        [Inject]
        IDialogService DialogService { get; set; }

        GenericModel<APP_Inspeccion> model { get; set; } = new GenericModel<APP_Inspeccion>();

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
            model.ErrorMsg = null;
            model.Data = new APP_Inspeccion();

            var data = await inspectionService.FindAll(model);
            if (data != null)
            {
                model = data;
            }
            await this.InvokeAsync(StateHasChanged);
        }


        protected async Task OnPagingChange(int pIndex)
        {
            if (model.PagesCount < pIndex || model.PagIdx == pIndex - 1)
                return;

            model.PagIdx = pIndex - 1;

            await FetchData();
        }

        protected async Task OnFilter()
        {
            model.PagIdx = 0;

            await FetchData();
        }

        // <summary>
        /// /////////////
        /// </summary>

        //Call Add/Edit payment Order
        private async Task SyncData(APP_Inspeccion data = null)
        {
            await bus.Publish(new OverlayShowEvent { Show = true });
            try
            {
                await inspectionService.InspectionsSync();
                await FetchData();
                snackbar.Add("Sincronización Finalizada", Severity.Info);
            }
            catch
            {
                snackbar.Add("Error durante la Sincronización", Severity.Error);
            }
            finally { await bus.Publish(new OverlayShowEvent { Show = false }); }

            //if (data == null)
            //{
            //    data = new APP_Inspeccion() { PredictionType = DBModel.Enums.PredictionType.Prediction_1181936 };
            //    //Open Modal
            //    var parameters = new DialogParameters();
            //    parameters.Add("data", data);
            //    var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Large, Position = DialogPosition.Center, FullWidth = true, DisableBackdropClick = true };
            //    var dialog = await DialogService.ShowAsync<RuletRules.Client.Components.PredictionOptions.AddNew>(string.Format("New"), parameters, options);
            //    var result = await dialog.Result;
            //    if (!result.Cancelled)
            //    {
            //        FetchData();
            //    }
            //}
            //else
            //{
            //    //Open Modal
            //    var parameters = new DialogParameters();
            //    parameters.Add("data", data);
            //    var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Large, Position = DialogPosition.Center, FullWidth = true, DisableBackdropClick = true };
            //    var dialog = await DialogService.ShowAsync<RuletRules.Client.Components.PredictionOptions.AddNew>(string.Format("Edit"), parameters, options);
            //    var result = await dialog.Result;
            //    if (!result.Cancelled)
            //    {
            //        FetchData();
            //    }
            //}  
        }

        private async Task OnDelete(APP_Inspeccion data)
        {
            //model.Data = data;

            ////Open Modal
            //var parameters = new DialogParameters();
            //parameters.Add("ContentText", "Do you really want to delete these records? This process cannot be undone.");
            //parameters.Add("ButtonText", "Delete");
            //parameters.Add("Color", Color.Error);
            //var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };
            //var dialog = await DialogService.ShowAsync<RuletRules.Client.Components.Dialog.DialogComponent>("Delete", parameters, options);
            //var result = await dialog.Result;
            //if (!result.Cancelled)
            //{
            //    DeleteData();
            //}
        }

        private async Task DeleteData()
        {
            //var result = await PredictionOptionService.Delete(model.Data.Id);
            //if (result != null)
            //{
            //    snackbar.Add(languageContainerService.Keys["DataDeleteSuccessfully"], Severity.Success);
            //    FetchData();
            //}
            //else
            //    snackbar.Add(languageContainerService.Keys["DataDeleteError"], Severity.Error);
        }

    }
}

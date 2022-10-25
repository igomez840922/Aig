using Aig.Auditoria.Events.DeleteConfirmationDlg;
using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.Auditoria.Pages.RetiredProduct
{   
    public partial class RetiredProduct
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IRetiredProductService retiredProductService { get; set; }
        [Inject]
        IInspectionsService inspectionsService { get; set; }

        GenericModel<AUD_ProdRetiroRetencionTB> dataModel { get; set; } = new GenericModel<AUD_ProdRetiroRetencionTB>()
        { Data = new AUD_ProdRetiroRetencionTB() };
        AUD_InspeccionTB inspeccion { get; set; }
        bool OpenAddEdit { get; set; } = false;


        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);

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
                await getUserLanguaje();
                await FetchData();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        protected async Task FetchData()
        {
            dataModel.ErrorMsg = null;
            dataModel.Data = new AUD_ProdRetiroRetencionTB();
            var data = await retiredProductService.FindAll(dataModel);
            if (data != null)
            {
                dataModel = data;
            }
            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task OnPagingChange(int pIndex)
        {
            if (dataModel.PagesCount < pIndex)
                return;

            dataModel.PagIdx = pIndex - 1;

            await FetchData();
        }

        protected async Task OnFilter()
        {
            dataModel.PagIdx = 0;

            await FetchData();
        }

        //SET LANGUAGE
        protected async Task getUserLanguaje(string? language = null)
        {
            language = string.IsNullOrEmpty(language) ? await profileService.GetLanguage() : language;
            languageContainerService.SetLanguage(System.Globalization.CultureInfo.GetCultureInfo(language));
            await this.InvokeAsync(StateHasChanged);
        }

        private void LanguageChangeEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<LanguageChangeEvent>();

            getUserLanguaje(message.Language);
        }
        /// <summary>
        /// /////////////
        /// </summary>

        //Call Add/Edit 
        private async Task OnEdit(long id)
        {
            var result = await inspectionsService.Get(id);
            if (result == null)
            {
                result = new AUD_InspeccionTB() { TipoActa = DataModel.Helper.enumAUD_TipoActa.RetencionRetiroProductos, InspRetiroRetencion = new AUD_InspRetiroRetencionTB() { LProductos = new List<AUD_ProdRetiroRetencionTB>() } };
            }
            OpenAddEditScreen(result);
        }
        private async Task OpenAddEditScreen(AUD_InspeccionTB data)
        {
            bus.Subscribe<Aig.Auditoria.Events.Inspections.AddEditCloseEvent>(InspectionAddEdit_CloseEventHandler);
            inspeccion = data;
            OpenAddEdit = true;
            await this.InvokeAsync(StateHasChanged);
        }
        private void InspectionAddEdit_CloseEventHandler(MessageArgs args)
        {
            bus.Subscribe<Aig.Auditoria.Events.Inspections.AddEditCloseEvent>(InspectionAddEdit_CloseEventHandler);

            var message = args.GetMessage<Aig.Auditoria.Events.Inspections.AddEditCloseEvent>();

            if (message.Inspeccion != null)
            {
                OpenAddEditScreen(message.Inspeccion);
                return;
            }
            FetchData();
        }

        private void InspectionBase_CloseEventHandler(MessageArgs args)
        {
            //var message = args.GetMessage<Aig.Auditoria.Events.Inspections.InspectionBase_CloseEvent>();
            FetchData();
        }

        private async Task OnDelete(AUD_ProdRetiroRetencionTB data)
        {
            dataModel.Data = data;
            await bus.Publish(new DeleteConfirmationOpenEvent());
        }
        protected void DeleteConfirmationCloseEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<DeleteConfirmationCloseEvent>();
            if (message.YesNo)
            {
                DeleteData();
            }
        }
        private async Task DeleteData()
        {
            var result = await retiredProductService.Delete(dataModel.Data.Id);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataDeleteSuccessfully"]);

                await jsRuntime.InvokeVoidAsync("OpenCloseModal", "#btnCloseDeleteModal");

                await FetchData();
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataDeleteError"]);
        }



    }

}

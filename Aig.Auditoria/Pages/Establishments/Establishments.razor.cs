using Aig.Auditoria.Events.DeleteConfirmationDlg;
using Aig.Auditoria.Events.Inspections;
using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Services;
using BlazorComponentBus;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.Auditoria.Pages.Establishments
{
    public partial class Establishments
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IEstablishmentsService establishmentsService { get; set; }

        GenericModel<AUD_EstablecimientoTB> dataModel { get; set; } = new GenericModel<AUD_EstablecimientoTB>()
        { Data = new AUD_EstablecimientoTB() };
                
        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<Aig.Auditoria.Events.Establishments.EstablishmentsAddEdit_CloseEvent>(EstablishmentsAddEdit_CloseEventHandler);
            bus.Subscribe<DeleteConfirmationCloseEvent>(DeleteConfirmationCloseEventHandler);
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
            dataModel.Data = new AUD_EstablecimientoTB();
            var data = await establishmentsService.FindAll(dataModel);
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
            var result = await establishmentsService.Get(id);
            if (result == null)
            {
                result = new AUD_EstablecimientoTB();
            }
            await bus.Publish(new Aig.Auditoria.Events.Establishments.EstablishmentsAddEdit_OpenEvent { Data = result });
            await this.InvokeAsync(StateHasChanged);
        }
        private void EstablishmentsAddEdit_CloseEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<Aig.Auditoria.Events.Establishments.EstablishmentsAddEdit_CloseEvent>();
            FetchData();
        }

        private async Task OnDelete(AUD_EstablecimientoTB data)
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
            var result = await establishmentsService.Delete(dataModel.Data.Id);
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

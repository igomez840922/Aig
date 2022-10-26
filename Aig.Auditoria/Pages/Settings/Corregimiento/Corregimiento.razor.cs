using Aig.Auditoria.Events.DeleteConfirmationDlg;
using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Aig.Auditoria.Events.Corregimiento;
using Aig.Auditoria.Data;

namespace Aig.Auditoria.Pages.Settings.Corregimiento
{    
    public partial class Corregimiento
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        ICountriesService countriesService { get; set; }
        [Inject]
        IProvicesService provicesService { get; set; }
        [Inject]
        IDistrictService districtService { get; set; }
        [Inject]
        ICorregimientoService corregimientoService { get; set; }

        List<PaisTB> LPaises { get; set; }
        List<ProvinciaTB> LProvincias { get; set; }
        List<DistritoTB> LDistritos { get; set; }

        long IdPais { get; set; }
        long IdProvincia { get; set; }
        long IdDistrito { get; set; }

        GenericModel<CorregimientoTB> dataModel { get; set; } = new GenericModel<CorregimientoTB>()
        { Data = new CorregimientoTB() };

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<Aig.Auditoria.Events.Corregimiento.CorregimientoAddEdit_CloseEvent>(CorregimientoAddEdit_CloseEvent);
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
            if (LPaises == null || LPaises.Count <= 0)
            {
                LPaises = await countriesService.GetAll();
            }

            dataModel.ErrorMsg = null;
            dataModel.Data = new CorregimientoTB() { Distrito = new DistritoTB() { Provincia = new ProvinciaTB() { Pais = new PaisTB() } } };
            var data = await corregimientoService.FindAll(dataModel);
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
            var result = await corregimientoService.Get(id);
            if (result == null)
            {
                result = new CorregimientoTB() { Distrito = new DistritoTB() { Provincia = new ProvinciaTB() { Pais = new PaisTB() } } };
            }
            await bus.Publish(new Aig.Auditoria.Events.Corregimiento.CorregimientoAddEdit_OpenEvent { Data = result });
            await this.InvokeAsync(StateHasChanged);
        }
        private void CorregimientoAddEdit_CloseEvent(MessageArgs args)
        {
            var message = args.GetMessage<Aig.Auditoria.Events.Corregimiento.CorregimientoAddEdit_CloseEvent>();
            FetchData();
        }

        private async Task OnDelete(CorregimientoTB data)
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
            var result = await corregimientoService.Delete(dataModel.Data.Id);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataDeleteSuccessfully"]);

                await jsRuntime.InvokeVoidAsync("OpenCloseModal", "#btnCloseDeleteModal");

                await FetchData();
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataDeleteError"]);
        }
        
        protected async Task OnCountryChange(long Id)
        {
            IdPais = Id;
            LProvincias = LPaises.Where(x => x.Id == IdPais).FirstOrDefault()?.LProvincia;
            IdProvincia = 0;
            IdDistrito = 0;
            dataModel.ParentId = IdDistrito > 0 ? IdDistrito : 0;
            dataModel.Parent2Id = IdProvincia > 0 ? IdProvincia : 0;
            dataModel.Parent3Id = IdPais > 0 ? IdPais : 0;
            await FetchData();
        }
        protected async Task OnProvincesChange(long Id)
        {
            IdProvincia = Id;
            LDistritos = LProvincias.Where(x => x.Id == IdProvincia).FirstOrDefault()?.LDistritos;
            dataModel.ParentId = IdDistrito > 0 ? IdDistrito : 0;
            dataModel.Parent2Id = IdProvincia > 0 ? IdProvincia : 0;
            dataModel.Parent3Id = IdPais > 0 ? IdPais : 0;
            await FetchData();
        }
        protected async Task OnDistrictChange(long Id)
        {
            IdDistrito = Id;
            dataModel.ParentId = IdDistrito > 0 ? IdDistrito : 0;
            dataModel.Parent2Id = IdProvincia > 0 ? IdProvincia : 0;
            dataModel.Parent3Id = IdPais > 0 ? IdPais : 0;
            await FetchData();
        }
    }

}

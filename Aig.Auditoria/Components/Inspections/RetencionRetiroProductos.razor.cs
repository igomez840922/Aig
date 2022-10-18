using Aig.Auditoria.Events.Inspections;
using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Pages.Inspections;
using Aig.Auditoria.Services;
using BlazorComponentBus;
using DataModel;
using DataModel.Helper;
using Duende.IdentityServer.AspNetIdentity;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;

namespace Aig.Auditoria.Components.Inspections
{
    public partial class RetencionRetiroProductos
    {
        [Inject]
        IInspectionsService inspeccionService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IEstablishmentsService establecimientoService { get; set; }
        bool OpenDialog { get; set; }
        [Parameter]
        public DataModel.AUD_InspeccionTB Inspeccion { get; set; }
        List<AUD_EstablecimientoTB> lEstablecimientos { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<Aig.Auditoria.Events.RetiredProduct.AddEditCloseEvent>(RetiredProduct_AddEditCloseEventHandler);

            base.OnInitialized();
        }
                
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await getUserLanguaje();
                await FetchData();
            }
        }

        //CHANGE LANGUAJE
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

        

        //Fill Data
        protected async Task FetchData()
        {
            if (lEstablecimientos == null || lEstablecimientos.Count < 1)
            {
                lEstablecimientos = await establecimientoService.GetAll();
            }

            if (Inspeccion != null)
            {
                OpenDialog = true;
            }

            await this.InvokeAsync(StateHasChanged);
        }
            
        //Save Data and Close
        protected async Task SaveData()
        {     
            var result = await inspeccionService.Save(Inspeccion);
            if (result != null)
            {
                OpenDialog = false;

                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Inspeccion = result;

                await bus.Publish(new Aig.Auditoria.Events.Inspections.InspectionBase_CloseEvent { });

                await this.InvokeAsync(StateHasChanged);
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            OpenDialog = false;
            await bus.Publish(new Aig.Auditoria.Events.Inspections.InspectionBase_CloseEvent { });
            await this.InvokeAsync(StateHasChanged);
        }
        
        //Add New Product
        protected async Task OpenProduct(AUD_ProdRetiroRetencionTB product=null)
        {
            product = product != null ? product : new AUD_ProdRetiroRetencionTB();

            await bus.Publish(new Aig.Auditoria.Events.RetiredProduct.AddEditOpenEvent { Product = product }); 
            await this.InvokeAsync(StateHasChanged);
        }
        
        //Remove Product
        protected async Task RemoveProduct(AUD_ProdRetiroRetencionTB product)
        {
            if (product != null)
            {
                Inspeccion.InspRetiroRetencion.LProductos.Remove(product);
                this.InvokeAsync(StateHasChanged);
            }
        }
       
        //ON CLOSE PRODUCT MODAL 
        private void RetiredProduct_AddEditCloseEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<Aig.Auditoria.Events.RetiredProduct.AddEditCloseEvent>();

            if(message.Product != null)
            {
                Inspeccion.InspRetiroRetencion.LProductos = Inspeccion.InspRetiroRetencion.LProductos != null ? Inspeccion.InspRetiroRetencion.LProductos : new List<AUD_ProdRetiroRetencionTB>();

                Inspeccion.InspRetiroRetencion.LProductos.Add(message.Product);
                this.InvokeAsync(StateHasChanged);
            }

        }
                

    }
}

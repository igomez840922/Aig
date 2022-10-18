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
    public partial class AddEditComponent
    {
        [Inject]
        IInspeccionService inspeccionService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IEstablecimientoService establecimientoService { get; set; }
        bool OpenDialog { get; set; }
        DataModel.AUD_InspeccionTB Inspeccion { get; set; } = null;
        List<AUD_EstablecimientoTB> lEstablecimientos { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<AddEditOpenEvent>(AddEditOpenEventHandler);
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

        //OPEN MODAL TO ADD/EDIT INSPECTIONS 
        private void AddEditOpenEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<AddEditOpenEvent>();

            Inspeccion = message.Inspeccion!=null? message.Inspeccion : new DataModel.AUD_InspeccionTB();

            OpenDialog = true;
            
            this.InvokeAsync(StateHasChanged);
        }

        protected async Task FetchData()
        {
            if (lEstablecimientos == null || lEstablecimientos.Count < 1)
            {
                lEstablecimientos = await establecimientoService.GetAll();
            }
            await this.InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Saving Data
        /// </summary>

        protected async Task SaveData()
        {     
            var result = await inspeccionService.Save(Inspeccion);
            if (result != null)
            {
                OpenDialog = false;

                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Inspeccion = result;

               await bus.Publish(new AddEditCloseEvent { Inspeccion = Inspeccion });

               await this.InvokeAsync(StateHasChanged);
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        protected async Task Cancel()
        {
            OpenDialog = false;
            await bus.Publish(new AddEditCloseEvent { Inspeccion = null });
            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task SelectInspectionType(enumAUD_TipoActa tipoActa)
        {
            Inspeccion.TipoActa = tipoActa;
            switch(Inspeccion.TipoActa)
            {
                case enumAUD_TipoActa.RetencionRetiroProductos:
                    {
                        Inspeccion.InspRetiroRetencion = Inspeccion.InspRetiroRetencion != null ? Inspeccion.InspRetiroRetencion : new AUD_InspRetiroRetencionTB();
                        break;
                    }                
            }
            await this.InvokeAsync(StateHasChanged);
        }

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

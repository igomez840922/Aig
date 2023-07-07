using Aig.Auditoria.Events.RetiredProduct;
using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Pages.Inspections;
using Aig.Auditoria.Services;
using BlazorComponentBus;
using DataModel;
using DataModel.Helper;
using Duende.IdentityServer.AspNetIdentity;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;

namespace Aig.Auditoria.Components.RetiredProduct
{
    //AGREGAR O EDITAR PRODUCTOS AL FORMULARIO
    public partial class AddEditProductComponent
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        ICountriesService countriesService { get; set; }
        bool OpenDialog { get; set; }

        [Parameter]
        public DataModel.AUD_ProdRetiroRetencionTB Product { get; set; } = null;
        List<PaisTB> lPaises { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            
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
            if (lPaises == null || lPaises.Count < 1)
            {
                lPaises = (await countriesService.GetAll()).OrderBy(x=>x.Nombre).ToList();
            }

            Product = Product!=null? Product:new AUD_ProdRetiroRetencionTB();
            OpenDialog = true;

            await this.InvokeAsync(StateHasChanged);
        }

               
        /// <summary>
        /// Saving Data
        /// </summary>

        protected async Task SaveData()
        {
            OpenDialog = false;
            await bus.Publish(new AddEditCloseEvent { Product = Product });
            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task Cancel()
        {
            OpenDialog = false;
            await bus.Publish(new AddEditCloseEvent { Product = null });
            await this.InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            //timer?.Dispose();

            bus.UnSubscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
        }
    }
}

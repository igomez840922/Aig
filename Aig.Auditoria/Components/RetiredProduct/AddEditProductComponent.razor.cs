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
        bool OpenDialog { get; set; }
        DataModel.AUD_ProdRetiroRetencionTB Product { get; set; } = null;
        
        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<AddEditOpenEvent>(AddEditOpenEventHandler);

            base.OnInitialized();
        }
                
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await getUserLanguaje();
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

        //OPEN MODAL TO ADD/Edit 
        private void AddEditOpenEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<AddEditOpenEvent>();

            Product = message.Product != null? message.Product : new DataModel.AUD_ProdRetiroRetencionTB();

            OpenDialog = true;
            
            this.InvokeAsync(StateHasChanged);
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
        
    }
}

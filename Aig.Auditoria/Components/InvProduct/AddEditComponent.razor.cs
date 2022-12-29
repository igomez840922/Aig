using Aig.Auditoria.Events.InvProduct;
using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Services;
using BlazorComponentBus;
using Microsoft.AspNetCore.Components;

namespace Aig.Auditoria.Components.InvProduct
{
    public partial class AddEditComponent
    {
        [Inject]
        IProfileService profileService { get; set; }

        [Parameter]
        public DataModel.AUD_InvProducto Product { get; set; } = null;

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

            await this.InvokeAsync(StateHasChanged);
        }



        /// <summary>
        /// Saving Data
        /// </summary>

        protected async Task SaveData()
        {
            await bus.Publish(new Aig.Auditoria.Events.InvProduct.CloseEvent { Data = Product });
            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task Cancel()
        {
            await bus.Publish(new Aig.Auditoria.Events.InvProduct.CloseEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }
    }
}

using Aig.Auditoria.Events.Establishments;
using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.Auditoria.Components.Establishments
{
    //AGREGAR O EDITAR PRODUCTOS AL FORMULARIO
    public partial class AddEditEstablishment
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IEstablishmentsService establishmentsService { get; set; }
        bool OpenDialog { get; set; }
        DataModel.AUD_EstablecimientoTB Establecimiento { get; set; } = null;

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<EstablishmentsAddEdit_OpenEvent>(EstablishmentsAddEdit_OpenEventHandler);

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
        private void EstablishmentsAddEdit_OpenEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<EstablishmentsAddEdit_OpenEvent>();

            Establecimiento = message.Data != null ? message.Data : new DataModel.AUD_EstablecimientoTB();

            OpenDialog = true;

            this.InvokeAsync(StateHasChanged);
        }


        /// <summary>
        /// Saving Data
        /// </summary>

        //Save Data and Close
        protected async Task SaveData()
        {
            var result = await establishmentsService.Save(Establecimiento);
            if (result != null)
            {
                OpenDialog = false;

                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Establecimiento = result;
                await bus.Publish(new EstablishmentsAddEdit_CloseEvent { });

                await this.InvokeAsync(StateHasChanged);
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            OpenDialog = false;
            await bus.Publish(new EstablishmentsAddEdit_CloseEvent { });
            await this.InvokeAsync(StateHasChanged);
        }


    }
}

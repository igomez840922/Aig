using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.FarmacoVigilancia.Pages.RegNotificaciones
{
    public partial class Index
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IContactService contactService { get; set; }

        bool OpenDialog { get; set; }
        [Parameter]
        public DataModel.FMV_ContactosTB datoContacto { get; set; } = null;

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
            OpenDialog = true;
            datoContacto = datoContacto != null ? datoContacto : new DataModel.FMV_ContactosTB();

            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task SaveData()
        {
            var result = (await contactService.FindAll(x => x.Correo == datoContacto.Correo)).FirstOrDefault();
            if(result!=null)
            {
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["Su correo ya fue registrado anteriormente en nuestro sistema"]);
                return;
            }

            result = await contactService.Save(datoContacto);
            if (result != null)
            {
                OpenDialog = false;

                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["Sus datos fueron registrados satisfactoriamente"]);
                datoContacto = null;
                OpenDialog = false;

                FetchData();
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        protected async Task Cancel()
        {
            //bus.UnSubscribe<Aig.Auditoria.Events.OpenHours.OpenHoursAddEdit_OpenEvent>(AddEditOpenEventHandler);
            OpenDialog = false;
            navigationManager.NavigateTo("/registro", true);
        }
    }
}

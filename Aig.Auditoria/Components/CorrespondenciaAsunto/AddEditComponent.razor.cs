using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.Auditoria.Components.CorrespondenciaAsunto
{
    public partial class AddEditComponent
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        ICorrespondenciaAsuntoService mainService { get; set; }
        bool OpenDialog { get; set; }
        [Parameter]
        public DataModel.AUD_CorrespondenciaAsuntoTB Data { get; set; } = null;

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
            Data = Data != null ? Data : new DataModel.AUD_CorrespondenciaAsuntoTB();

            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task SaveData()
        {
            var result = await mainService.Save(Data);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                OpenDialog = false;
                Data = result;
                await bus.Publish(new Aig.Auditoria.Events.CorrespondenciaAsunto.AddEditEvent { Data = Data });
                await this.InvokeAsync(StateHasChanged);
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        protected async Task Cancel()
        {
            //bus.UnSubscribe<Aig.Auditoria.Events.OpenHours.OpenHoursAddEdit_OpenEvent>(AddEditOpenEventHandler);
            OpenDialog = false;
            await bus.Publish(new Aig.Auditoria.Events.CorrespondenciaAsunto.AddEditEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            bus.UnSubscribe <LanguageChangeEvent>(LanguageChangeEventHandler);
        }

    }

}

using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;

namespace Aig.Auditoria.Components.Establishments
{   
    public partial class SearchComponent
    {
        [Inject]
        IProfileService profileService { get; set; }
        bool OpenDialog { get; set; }
        [Inject]
        IEstablishmentsService establishmentsService { get; set; }

        GenericModel<AUD_EstablecimientoTB> dataModel { get; set; } = new GenericModel<AUD_EstablecimientoTB>()
        { Data = new AUD_EstablecimientoTB() };

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
            
            dataModel.ErrorMsg = null;
            dataModel.Data = new AUD_EstablecimientoTB();
            var data = await establishmentsService.FindAll(dataModel);
            if (data != null)
            {
                dataModel = data;
            }

            OpenDialog = true;

            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task OnFilter()
        {
            dataModel.PagIdx = 0;

            await FetchData();
        }

        protected async Task SelectData(AUD_EstablecimientoTB data)
        {
            //bus.UnSubscribe<Aig.Auditoria.Events.OpenHours.OpenHoursAddEdit_OpenEvent>(AddEditOpenEventHandler);
            OpenDialog = false;
            await bus.Publish(new Aig.Auditoria.Events.Establishments.SearchEvent { Data = data });
            bus.UnSubscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task Cancel()
        {
            //bus.UnSubscribe<Aig.Auditoria.Events.OpenHours.OpenHoursAddEdit_OpenEvent>(AddEditOpenEventHandler);
            OpenDialog = false;
            await bus.Publish(new Aig.Auditoria.Events.Establishments.SearchEvent { Data = null });
            bus.UnSubscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            await this.InvokeAsync(StateHasChanged);
        }

    }

}

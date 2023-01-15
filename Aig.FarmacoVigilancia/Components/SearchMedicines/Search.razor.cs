using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using Aig.FarmacoVigilancia.Services;
using Aig.FarmacoVigilancia.Events.Language;

namespace Aig.FarmacoVigilancia.Components.SearchMedicines
{    
    public partial class Search
    {
        [Inject]
        IProfileService profileService { get; set; }
        bool OpenDialog { get; set; }
        [Inject]
        IMedicamentosService medicamentosService { get; set; }

        ProdServiceDataResponse dataModel { get; set; }
        ProdServiceDataRequest dataRequest { get; set; } = new ProdServiceDataRequest() { pageSize=100, pageIndex= 1 };

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
            dataModel = null;
            if (!string.IsNullOrEmpty(dataRequest.term))
            {
                dataModel = await medicamentosService.FindAll(dataRequest);                
            }

            OpenDialog = true;
            await this.InvokeAsync(StateHasChanged);
        }
               

        protected async Task SelectData(ProdServiceData data)
        {
            OpenDialog = false;
            await bus.Publish(new Aig.FarmacoVigilancia.Events.SearchMedicines.SearchMedicinesEvent { Data = data });
            bus.UnSubscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task Cancel()
        {
            OpenDialog = false;
            await bus.Publish(new Aig.FarmacoVigilancia.Events.SearchMedicines.SearchMedicinesEvent { Data = null });
            bus.UnSubscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            await this.InvokeAsync(StateHasChanged);
        }

    }

}

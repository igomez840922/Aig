using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using Aig.FarmacoVigilancia.Services;
using Aig.FarmacoVigilancia.Events.Language;
using BlazorDownloadFile;

namespace Aig.FarmacoVigilancia.Components.FarmacoComun {    
    public partial class Search
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IFarmacoService mainService { get; set; }
        [Inject]
        IBlazorDownloadFileService blazorDownloadFileService { get; set; }
        GenericModel<FarmacoTB> dataModel { get; set; } = new GenericModel<FarmacoTB>() { Data = new FarmacoTB() };

        bool OpenDialog { get; set; } = false;

        protected async override Task OnInitializedAsync() {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            base.OnInitialized();
        }

        protected override async Task OnParametersSetAsync() {
            await base.OnParametersSetAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender) {
            if (firstRender) {
                await getUserLanguaje();
                await FetchData();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        protected async Task FetchData() {

            
                dataModel.ErrorMsg = null;
            dataModel.Data = null;

            OpenDialog = true;
            var data = await mainService.FindAll(dataModel);
            if (data != null) {
                dataModel = data;
            }
            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task OnPagingChange(int pIndex) {
            if (dataModel.PagesCount < pIndex)
                return;

            dataModel.PagIdx = pIndex - 1;

            await FetchData();
        }

        protected async Task OnFilter() {
            dataModel.PagIdx = 0;

            await FetchData();
        }

        //SET LANGUAGE
        protected async Task getUserLanguaje(string? language = null) {
            language = string.IsNullOrEmpty(language) ? await profileService.GetLanguage() : language;
            languageContainerService.SetLanguage(System.Globalization.CultureInfo.GetCultureInfo(language));
            await this.InvokeAsync(StateHasChanged);
        }

        private void LanguageChangeEventHandler(MessageArgs args) {
            var message = args.GetMessage<LanguageChangeEvent>();

            getUserLanguaje(message.Language);
        }
        /// <summary>
        /// /////////////
        /// </summary>

        protected async Task SelectData(FarmacoTB data)
        {
            OpenDialog = false;
            await bus.Publish(new Aig.FarmacoVigilancia.Events.Farmaco.AddEditEvent { Data = data });
            bus.UnSubscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task Cancel()
        {
            OpenDialog = false;
            await bus.Publish(new Aig.FarmacoVigilancia.Events.Farmaco.AddEditEvent { Data = null });
            bus.UnSubscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            await this.InvokeAsync(StateHasChanged);
        }

    }

}

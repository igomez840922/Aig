using Aig.FarmacoVigilancia.Events.Laboratory;
using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.FarmacoVigilancia.Components.TerMedra
{    
    public partial class AddEdit
    {
        [Inject]
        ITerMedraService terMedraService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        ISocService socService { get; set; }

        [Parameter]
        public DataModel.FMV_TerMedraTB Data { get; set; }
        List<FMV_SocTB> LSoc { get; set; }


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
            LSoc = LSoc?.Count>0 ? LSoc: await socService.GetAll();

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {

            var result = await terMedraService.Save(Data);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Data = result;

                await bus.Publish(new Aig.FarmacoVigilancia.Events.TerMedra.AddEditEvent { Data = Data });
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.TerMedra.AddEditEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }

    }

}

﻿using Aig.FarmacoVigilancia.Events.IPS;
using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Events.PMR;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.FarmacoVigilancia.Components.RFV
{   
    public partial class AddEditRfv
    {
        [Inject]
        IRfvService rfvService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        ILabsService labsService { get; set; }
        [Parameter]
        public DataModel.FMV_RfvTB Rfv { get; set; }
        List<LaboratorioTB> Labs { get; set; } = new List<LaboratorioTB>();

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
            if (Labs == null || Labs.Count < 1)
            {
                Labs = await labsService.GetAll();
            }

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            if (Rfv.LaboratorioId != null && Rfv.LaboratorioId > 0)
            {
                Rfv.Laboratorio = Labs?.Where(x => x.Id == Rfv.LaboratorioId.Value).FirstOrDefault();
            }
            
            var result = await rfvService.Save(Rfv);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Rfv = result;

                await bus.Publish(new RfvAddEdit_CloseEvent { Data = null });
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new RfvAddEdit_CloseEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }

    }

}

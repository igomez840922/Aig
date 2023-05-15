﻿using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Events.PMR;
using Aig.FarmacoVigilancia.Events.SystemUsers;
using Aig.FarmacoVigilancia.Events.WorkerPerson;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.FarmacoVigilancia.Components.SystemUsers
{  
    
    public partial class AddNew
    {
        [Inject]
        ISystemUserService systemUserService { get; set; }

        [Parameter]
        public DataModel.Models.RegisterModel User { get; set; } = new DataModel.Models.RegisterModel();

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            //bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);

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
            //language = string.IsNullOrEmpty(language) ? await profileService.GetLanguage() : language;
            //languageContainerService.SetLanguage(System.Globalization.CultureInfo.GetCultureInfo(language));
            await this.InvokeAsync(StateHasChanged);
        }
        private void LanguageChangeEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<LanguageChangeEvent>();

            //getUserLanguaje(message.Language);
        }

        //Fill Data
        protected async Task FetchData()
        {            

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            User.UserRoleType = enumUserRoleType.Admin;
            var result = await systemUserService.Save(User);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                //User = result;

                await bus.Publish(new RegisterEvent { Data = null });
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new RegisterEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }

    }

}

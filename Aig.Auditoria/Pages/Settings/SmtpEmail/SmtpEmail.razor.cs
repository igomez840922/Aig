using Aig.Auditoria.Events.DeleteConfirmationDlg;
using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Aig.Auditoria.Events.Country;
using Castle.Core;

namespace Aig.Auditoria.Pages.Settings.SmtpEmail
{
    public partial class SmtpEmail
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        ISmtpCorreoService smtpCorreoService { get; set; }

        GenericModel<SmtpCorreoTB> dataModel { get; set; } = new GenericModel<SmtpCorreoTB>()
        { Data = new SmtpCorreoTB() };

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            //bus.Subscribe<Aig.Auditoria.Events.EmailServer.EmailServerAddEdit_CloseEvent>(EmailServerAddEdit_CloseEventHandler);
            //bus.Subscribe<DeleteConfirmationCloseEvent>(DeleteConfirmationCloseEventHandler);
            base.OnInitialized();
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await getUserLanguaje();
                await FetchData();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        protected async Task FetchData()
        {
            dataModel.ErrorMsg = null;            
            dataModel.Data = await smtpCorreoService.GetDefault();
            if (dataModel.Data == null)
            {
                dataModel.Data = new SmtpCorreoTB();
            }
            await this.InvokeAsync(StateHasChanged);
        }                
       
        //SET LANGUAGE
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
        /// <summary>
        /// /////////////
        /// </summary>

        //Save Data and Close
        protected async Task SaveData()
        {
            var result = await smtpCorreoService.Save(dataModel.Data);
            if (result != null)
            {                
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                dataModel.Data = result;
                //await bus.Publish(new CountryAddEdit_CloseEvent { });

                await this.InvokeAsync(StateHasChanged);
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);

            await FetchData();
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            //OpenDialog = false;
            //await bus.Publish(new CountryAddEdit_CloseEvent { });
            //await this.InvokeAsync(StateHasChanged);

            await FetchData();
        }


    }

}

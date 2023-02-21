using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using BlazorDownloadFile;
using DataAccess;
using DataModel;
using DataModel.Helper;
using DataModel.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Mobsites.Blazor;
using Radzen.Blazor.Rendering;
using System.Text.RegularExpressions;

namespace Aig.FarmacoVigilancia.Pages
{
    public partial class Dashboard
    {
        [Inject]
        IProfileService profileService { get; set; }

        [Inject]
        IDashboardService mainService { get; set; }
               
        ReportModel<ReportModelResponse> dataModelEsavi { get; set; } = new ReportModel<ReportModelResponse>() { FromDate = DateTime.Now.AddYears(-1) };
        ReportModel<ReportModelResponse> dataModelRam { get; set; } = new ReportModel<ReportModelResponse>() { FromDate = DateTime.Now.AddYears(-1) };
        ReportModel<ReportModelResponse> dataModelAlerta { get; set; } = new ReportModel<ReportModelResponse>() { FromDate = DateTime.Now.AddYears(-1) };
        ReportModel<ReportModelResponse> dataModelNota { get; set; } = new ReportModel<ReportModelResponse>() { FromDate = DateTime.Now.AddYears(-1) };
        ReportModel<ReportModelResponse> dataModelPmr { get; set; } = new ReportModel<ReportModelResponse>() { FromDate = DateTime.Now.AddYears(-1) };
        ReportModel<ReportModelResponse> dataModelIps { get; set; } = new ReportModel<ReportModelResponse>() { FromDate = DateTime.Now.AddYears(-1) };
        ReportModel<ReportModelResponse> dataModelRfv { get; set; } = new ReportModel<ReportModelResponse>() { FromDate = DateTime.Now.AddYears(-1) };
        ReportModel<ReportModelResponse> dataModelFF { get; set; } = new ReportModel<ReportModelResponse>() { FromDate = DateTime.Now.AddYears(-1) };
        ReportModel<ReportModelResponse> dataModelFT { get; set; } = new ReportModel<ReportModelResponse>() { FromDate = DateTime.Now.AddYears(-1) };


        protected async override Task OnInitializedAsync()
        {            
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);

            base.OnInitialized();
        }
        public void Dispose()
        {
            //timer?.Dispose();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await getUserLanguaje();
                FetchData();
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

            var data = await mainService.ReportEsavy(dataModelEsavi);
            if (data != null)
            {
                dataModelEsavi = data;
            }

            data = await mainService.ReportRam(dataModelRam);
            if (data != null)
            {
                dataModelRam = data;
            }

            data = await mainService.ReportAlerta(dataModelAlerta);
            if (data != null)
            {
                dataModelAlerta = data;
            }

            data = await mainService.ReportNotas(dataModelNota);
            if (data != null)
            {
                dataModelNota = data;
            }

            data = await mainService.ReportPmr(dataModelPmr);
            if (data != null)
            {
                dataModelPmr = data;
            }

            data = await mainService.ReportIps(dataModelIps);
            if (data != null)
            {
                dataModelIps = data;
            }

            data = await mainService.ReportRfv(dataModelRfv);
            if (data != null)
            {
                dataModelRfv = data;
            }

            data = await mainService.ReportFF(dataModelFF);
            if (data != null)
            {
                dataModelFF = data;
            }

            data = await mainService.ReportFT(dataModelFT);
            if (data != null)
            {
                dataModelFT = data;
            }

            await this.InvokeAsync(StateHasChanged);
        }



        /////////////////////////////////////////////////
        /////////////////////////////////////////////
        ///

        
        

    }
}

using Aig.FarmacoVigilancia.Events.IPS;
using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Events.PMR;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.FarmacoVigilancia.Components.IPS
{    
    public partial class AddEditIps
    {
        [Inject]
        IIpsService ipsService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IWorkerPersonService workerPersonService { get; set; }
        [Inject]
        ILabsService labsService { get; set; }
        [Parameter]
        public DataModel.FMV_IpsTB Ips { get; set; }
        List<PersonalTrabajadorTB> lPersons { get; set; }
        List<LaboratorioTB> Labs { get; set; }

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
            if (lPersons == null || lPersons.Count < 1)
            {
                lPersons = await workerPersonService.GetAll();
            }
            if (Labs == null || Labs.Count < 1)
            {
                Labs = await labsService.GetAll();
            }

            //if (Pmr != null)
            //{
            //    if (Pmr.EvaluadorId == null)
            //    {
            //        Pmr.EvaluadorId = lEvaluators?.FirstOrDefault()?.Id ?? null;
            //        if (Pmr.EvaluadorId != null)
            //        {
            //            Pmr.Evaluador = lEvaluators.Where(x => x.Id == Pmr.EvaluadorId.Value).FirstOrDefault();
            //        }
            //    }
            //}

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            if (Ips.EvaluadorId != null && Ips.EvaluadorId > 0)
            {
                Ips.Evaluador = lPersons?.Where(x=>x.Id == Ips.EvaluadorId.Value).FirstOrDefault();
            }
            if (Ips.TramitadorId != null && Ips.TramitadorId > 0)
            {
                Ips.Tramitador = lPersons?.Where(x => x.Id == Ips.TramitadorId.Value).FirstOrDefault();
            }
            if (Ips.RegistradorId != null && Ips.RegistradorId > 0)
            {
                Ips.Registrador = lPersons?.Where(x => x.Id == Ips.RegistradorId.Value).FirstOrDefault();
            }

            var result = await ipsService.Save(Ips);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Ips = result;

                await bus.Publish(new IpsAddEdit_CloseEvent { Data = null });
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new IpsAddEdit_CloseEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }

    }

}

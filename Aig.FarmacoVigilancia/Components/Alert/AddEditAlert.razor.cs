using Aig.FarmacoVigilancia.Events.Alerta;
using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.FarmacoVigilancia.Components.Alert
{    
    public partial class AddEditAlert
    {
        [Inject]
        IAlertaService alertaService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IWorkerPersonService personService { get; set; }
        [Inject]
        IOrigenAlertaService origenAlertaService { get; set; }
        [Parameter]
        public DataModel.FMV_AlertaTB Alerta { get; set; }
        List<PersonalTrabajadorTB> LPerson { get; set; }
        List<FMV_OrigenAlertaTB> LOriginAlert { get; set; }

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
            if (LPerson == null || LPerson.Count < 1)
            {
                LPerson = await personService.GetAll();
            }
            if (LOriginAlert == null || LOriginAlert.Count < 1)
            {
                LOriginAlert = await origenAlertaService.GetAll();
            }

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            if (Alerta.OrigenAlertaId != null && Alerta.OrigenAlertaId > 0)
            {
                Alerta.OrigenAlerta = LOriginAlert?.Where(x => x.Id == Alerta.OrigenAlertaId.Value).FirstOrDefault();
            }
            if (Alerta.EvaluadorId != null && Alerta.EvaluadorId > 0)
            {
                Alerta.Evaluador = LPerson?.Where(x => x.Id == Alerta.EvaluadorId.Value).FirstOrDefault();
            }

            var result = await alertaService.Save(Alerta);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Alerta = result;

                await bus.Publish(new AlertAddEdit_CloseEvent { Data = null });
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new AlertAddEdit_CloseEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }

    }

}

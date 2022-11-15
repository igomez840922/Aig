using Aig.FarmacoVigilancia.Events.Alerta;
using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Events.Nota;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.FarmacoVigilancia.Components.Note
{    
    public partial class AddEditNote
    {
        [Inject]
        INoteService noteService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IWorkerPersonService personService { get; set; }
        [Inject]
        IDestinyInstituteService destinyInstituteService { get; set; }
        [Parameter]
        public DataModel.FMV_NotaTB Nota { get; set; }
        List<PersonalTrabajadorTB> LPerson { get; set; }
        List<InstitucionDestinoTB> LInstitucionDestino { get; set; }

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
            if (LInstitucionDestino == null || LInstitucionDestino.Count < 1)
            {
                LInstitucionDestino = await destinyInstituteService.GetAll();
            }

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            if (Nota.EvaluadorId != null && Nota.EvaluadorId > 0)
            {
                Nota.Evaluador = LPerson?.Where(x => x.Id == Nota.EvaluadorId.Value).FirstOrDefault();
            }
            if (Nota.InstitucionDestinoId != null && Nota.InstitucionDestinoId > 0)
            {
                Nota.InstitucionDestino = LInstitucionDestino?.Where(x => x.Id == Nota.InstitucionDestinoId.Value).FirstOrDefault();
            }

            var result = await noteService.Save(Nota);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Nota = result;

                await bus.Publish(new NotaAddEdit_CloseEvent { Data = null });
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new NotaAddEdit_CloseEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }

    }

}

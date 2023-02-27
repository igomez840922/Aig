using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Pages.Inspections;
using Aig.Auditoria.Services;
using BlazorComponentBus;
using DataModel;
using DataModel.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Mobsites.Blazor;

namespace Aig.Auditoria.Components.Inspections._15_BpmBPA
{
    public partial class Cap05
    {
        [Inject]
        IInspectionsService inspeccionService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }

        [Parameter]
        public long Id { get; set; }
        DataModel.AUD_InspeccionTB Inspeccion { get; set; } = null;


        private EditContext? editContext;
        private System.Timers.Timer timer = new(60 * 1000);
        bool exit { get; set; } = false;

        bool showPersona { get; set; } = false;
        DataModel.DatosPersona datosPersona { get; set; } = null;

        List<PropositoInspeccion> LPropositos { get; set; } = new List<PropositoInspeccion>();


        protected async override Task OnInitializedAsync()
        {
            timer.Elapsed += (sender, eventArgs) => {
                _ = InvokeAsync(() =>
                {
                    SaveData();
                });
            };
            timer.Start();

            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);

            base.OnInitialized();
        }

        public void Dispose()
        {
            timer?.Dispose();

            bus.UnSubscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
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
            if (LPropositos.Count <= 0)
            {
                foreach (enum_PropositoInspec dt in Enum.GetValues(typeof(enum_PropositoInspec)))
                {
                    LPropositos.Add(new PropositoInspeccion() { PropositoType = dt });
                }
            }

            Inspeccion = await inspeccionService.Get(Id);
            if (Inspeccion != null)
            {
                editContext = editContext != null ? editContext : new(Inspeccion);

                Inspeccion.InspGuiaBPM_Bpa.PropositoInsp = Inspeccion.InspGuiaBPM_Bpa.PropositoInsp != null ? Inspeccion.InspGuiaBPM_Bpa.PropositoInsp : new AUD_PropositosInspeccion();
            }
            else { Cancel(); }

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            try
            {
                var result = await inspeccionService.Save_BpmBPA_Cap5(Inspeccion);
                if (result != null)
                {
                    await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                    Inspeccion = result;

                    if (exit)
                        await bus.Publish(new Aig.Auditoria.Events.Inspections.ChapterChangeEvent { Inspeccion = Inspeccion });
                }
                else
                    await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
            }
            catch (Exception ex)
            {
                await jsRuntime.InvokeVoidAsync("ShowError", ex.Message);
            }
            finally
            {
                await this.InvokeAsync(StateHasChanged);
            }
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.Auditoria.Events.Inspections.ChapterChangeEvent { Inspeccion = null });
            await this.InvokeAsync(StateHasChanged);
        }


        //ADD PERSONA
        protected async Task OpenPersona(DataModel.DatosPersona _datosPersona = null)
        {
            bus.Subscribe<Aig.Auditoria.Events.DatosPersona.AddEdit_CloseEvent>(PersonaAddEdit_CloseEventHandler);

            datosPersona = _datosPersona != null ? _datosPersona : new DataModel.DatosPersona();
            showPersona = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //RemoveAttachment
        protected async Task RemovePersona(DataModel.DatosPersona _datosPersona)
        {
            if (_datosPersona != null)
            {
                try
                {
                    Inspeccion.InspGuiaBPM_Bpa.OtrosFuncionarios.LPersona.Remove(_datosPersona);
                }
                catch { }

                this.InvokeAsync(StateHasChanged);
            }
        }
        //ON CLOSE ATTACHMENT
        private void PersonaAddEdit_CloseEventHandler(MessageArgs args)
        {
            showPersona = false;

            bus.UnSubscribe<Aig.Auditoria.Events.DatosPersona.AddEdit_CloseEvent>(PersonaAddEdit_CloseEventHandler);

            var message = args.GetMessage<Aig.Auditoria.Events.DatosPersona.AddEdit_CloseEvent>();

            if (message.Data != null)
            {
                if (!Inspeccion.InspGuiaBPM_Bpa.OtrosFuncionarios.LPersona.Contains(message.Data))
                    Inspeccion.InspGuiaBPM_Bpa.OtrosFuncionarios.LPersona.Add(message.Data);
            }

            this.InvokeAsync(StateHasChanged);
        }


    }

}

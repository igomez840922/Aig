﻿using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Pages.Inspections;
using Aig.Auditoria.Services;
using BlazorComponentBus;
using DataModel;
using DataModel.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Mobsites.Blazor;

namespace Aig.Auditoria.Components.Inspections._12_BpmAcondMedicamentos
{
    public partial class Cap04
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
            Inspeccion = await inspeccionService.Get(Id);
            if (Inspeccion != null)
            {
                editContext = editContext != null ? editContext : new(Inspeccion);

                Inspeccion.InspGuiaBPMLabAcondicionador.OtrosFuncionarios = Inspeccion.InspGuiaBPMLabAcondicionador.OtrosFuncionarios != null ? Inspeccion.InspGuiaBPMLabAcondicionador.OtrosFuncionarios : new AUD_OtrosFuncionarios();
            }
            else { Cancel(); }

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            try
            {
                var result = await inspeccionService.Save_BpmAcondMedicamentos_Cap4(Inspeccion);
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
                    Inspeccion.InspGuiaBPMLabAcondicionador.OtrosFuncionarios.LPersona.Remove(_datosPersona);
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
                if (!Inspeccion.InspGuiaBPMLabAcondicionador.OtrosFuncionarios.LPersona.Contains(message.Data))
                    Inspeccion.InspGuiaBPMLabAcondicionador.OtrosFuncionarios.LPersona.Add(message.Data);
            }

            this.InvokeAsync(StateHasChanged);
        }


    }

}
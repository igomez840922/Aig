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

namespace Aig.Auditoria.Components.Inspections._2_AperturaUbicacionAgencia
{
    public partial class Cap02
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

        [Inject]
        ICountriesService countriesService { get; set; }
        List<PaisTB> LPaises { get; set; }


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
            LPaises = LPaises?.Count > 0 ? LPaises : await countriesService.GetAll();

            Inspeccion = await inspeccionService.Get(Id);
            if (Inspeccion != null)
            {
                editContext = editContext != null ? editContext : new(Inspeccion);

                Inspeccion.InspAperCambUbicAgen.DatosSolicitante = Inspeccion.InspAperCambUbicAgen.DatosSolicitante != null ? Inspeccion.InspAperCambUbicAgen.DatosSolicitante : new AUD_DatosSolicitante();
            }
            else { Cancel(); }

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            try
            {
                var result = await inspeccionService.Save_AperCamUbicAgencia_Cap2(Inspeccion);
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

        
    }

}
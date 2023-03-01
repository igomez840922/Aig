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

namespace Aig.Auditoria.Components.Inspections._16_AperturaFabCosmeticoArtesanal 
    {
    public partial class CapFirmas
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

        bool showSignasure { get; set; } = false;
        List<SignaturePad> lSignaturePads { get; set; } = new List<SignaturePad>();
        SignaturePad signaturePad
        {
            get { return null; }
            set { lSignaturePads.Add(value); }
        }
        SignaturePad signaturePad5;
        //SignaturePad signaturePad6;
        SignaturePad.SupportedSaveAsTypes signatureType { get; set; } = SignaturePad.SupportedSaveAsTypes.png;


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

                DelayToShowSignasure();                      
            }
            else { Cancel(); }

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            try
            {
                var result = await inspeccionService.Save_AperturaFabCosmeticoArtesanal_Firma(Inspeccion);
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

        async Task DelayToShowSignasure()
        {
            await Task.Delay(2000);

            if(signaturePad5!=null)
                signaturePad5.Image = Inspeccion.InspAperturaCosmetArtesanal?.DatosRepresentLegal?.Firma??null;
            //if (signaturePad6 != null)
            //    signaturePad6.Image = Inspeccion.InspAperturaCosmetArtesanal?.DatosRegente?.Firma ?? null;

            if (Inspeccion?.ParticipantesDNFD?.LParticipantes?.Count > 0)
            {
                foreach (var partic in Inspeccion.ParticipantesDNFD.LParticipantes)
                {
                    try
                    {
                        lSignaturePads[Inspeccion.ParticipantesDNFD.LParticipantes.IndexOf(partic)].Image = partic.Firma;
                    }
                    catch (Exception ex) { }
                }
            }

            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task OnSignatureChange5(ChangeEventArgs eventArgs)
        {
            RemoveSignatureImg5();
            if (eventArgs?.Value != null)
            {
                var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
            }
            Inspeccion.InspAperturaCosmetArtesanal.DatosRepresentLegal.Firma = await signaturePad5.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg5()
        {
            Inspeccion.InspAperturaCosmetArtesanal.DatosRepresentLegal.Firma = null;
            signaturePad5.Image = null;
        }
        //protected async Task OnSignatureChange6(ChangeEventArgs eventArgs)
        //{
        //    RemoveSignatureImg6();
        //    if (eventArgs?.Value != null)
        //    {
        //        var signatureType = (SignaturePad.SupportedSaveAsTypes)Enum.Parse(typeof(SignaturePad.SupportedSaveAsTypes), eventArgs.Value as string);
        //    }
        //    Inspeccion.InspAperturaCosmetArtesanal.DatosRegente.Firma = await signaturePad6.ToDataURL(signatureType);
        //}
        //protected async Task RemoveSignatureImg6()
        //{
        //    Inspeccion.InspAperturaCosmetArtesanal.DatosRegente.Firma = null;
        //    signaturePad6.Image = null;
        //}

        ////////
        ///
        protected async Task OnSignatureChange(Participante _participante)
        {
            await RemoveSignatureImg(_participante);
            var _signaturePad = lSignaturePads[Inspeccion.ParticipantesDNFD.LParticipantes.IndexOf(_participante)];
            _participante.Firma = await _signaturePad.ToDataURL(signatureType);
        }
        protected async Task RemoveSignatureImg(Participante _participante)
        {
            _participante.Firma = null;
            var _signaturePad = lSignaturePads[Inspeccion.ParticipantesDNFD.LParticipantes.IndexOf(_participante)];
            _signaturePad.Image = null;
        }

    }

}

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

namespace Aig.Auditoria.Components.Inspections._8_DisposicionFinal
{
    public partial class Index
    {
        [Inject]
        IInspectionsService inspeccionService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IEstablishmentsService establecimientoService { get; set; }
        
        [Parameter]
        public DataModel.AUD_InspeccionTB Inspeccion { get; set; }

        bool showSelectEstablecimiento { get; set; } = false;

        enumSelectedChapter selectedChapter { get; set; } = enumSelectedChapter.None;

        protected async override Task OnInitializedAsync()
        {            
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);

            base.OnInitialized();
        }

        public void Dispose()
        {
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
            if (Inspeccion.EstablecimientoId == null)
            {                
                //llamr el componente de llenar Establecimiento
                OpenSelectEstablecimientos();
            }
            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            try
            {   
                var result = await inspeccionService.Save(Inspeccion);
                if (result != null)
                {
                    await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                    Inspeccion = result;                    
                }
                else
                    await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
            }
            catch { }
            finally
            {
                await this.InvokeAsync(StateHasChanged);
            }
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.Auditoria.Events.Inspections.AddEditCloseEvent { Inspeccion = null });
            await this.InvokeAsync(StateHasChanged);
        }

        ////////////////////
        ///
        protected async Task OpenSelectEstablecimientos()
        {
            bus.Subscribe<Aig.Auditoria.Events.SeleccionarEstablecimiento.AddEditEvent>(SelectEstablecimiento_EventHandler);
            showSelectEstablecimiento = true;
            await this.InvokeAsync(StateHasChanged);
        }
        private void SelectEstablecimiento_EventHandler(MessageArgs args)
        {
            showSelectEstablecimiento = false;
            bus.UnSubscribe<Aig.Auditoria.Events.Establishments.SearchEvent>(SelectEstablecimiento_EventHandler);
            var message = args.GetMessage<Aig.Auditoria.Events.SeleccionarEstablecimiento.AddEditEvent>();
            if (message.Data != null && message.Data.EstablecimientoId !=null)
            {
                //Inspeccion.Establecimiento = message.Data.Establecimiento;
                Inspeccion.EstablecimientoId = message.Data.EstablecimientoId;
                Inspeccion.DatosEstablecimiento = message.Data;
                SaveData();
            }
            else
            {
                Cancel();
            }

        }

        ////////////////////
        ///

        //Abrimos un capitulo Determinado
        protected async Task SelectChapter(enumSelectedChapter selectedChapter)
        {
            try
            {
                this.selectedChapter = selectedChapter;

                if(this.selectedChapter!= enumSelectedChapter.None)
                {
                    bus.Subscribe<Aig.Auditoria.Events.Inspections.ChapterChangeEvent>(ChapterChange_EventHandler);
                }
            }
            catch { }
            finally
            {
                await this.InvokeAsync(StateHasChanged);
            }
        }

        //Cerramos todos los capitulos
        private void ChapterChange_EventHandler(MessageArgs args)
        {
            bus.UnSubscribe<Aig.Auditoria.Events.Inspections.ChapterChangeEvent>(ChapterChange_EventHandler);

            this.selectedChapter = enumSelectedChapter.None;

            updateInspection();

            //this.InvokeAsync(StateHasChanged);
        }

        private async Task updateInspection() {
            if (Inspeccion.Id > 0) {

                this.Inspeccion = await inspeccionService.Get(Inspeccion.Id);
            }

            this.InvokeAsync(StateHasChanged);
        }

    }

}

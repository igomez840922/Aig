using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Services;
using BlazorComponentBus;
using DataModel.Helper;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.Auditoria.Components.Inspections
{   
    public partial class InspectionBase
    {
        [Inject]
        IInspeccionService inspeccionService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        bool OpenDialog { get; set; }
        DataModel.AUD_InspeccionTB Inspeccion { get; set; } = null;
        
        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<Aig.Auditoria.Events.Inspections.InspectionBase_OpenEvent>(InspectionBase_OpenEventHandler);
            bus.Subscribe<Aig.Auditoria.Events.Inspections.InspectionBase_CloseEvent>(InspectionBase_CloseEventHandler);
            bus.Subscribe<Aig.Auditoria.Events.Inspections.InspectionType_SelectedEvent>(InspectionType_SelectedEventHandler);

            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await getUserLanguaje();
                //await FetchData();
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

        //OPEN MODAL TO ADD/EDIT INSPECTIONS 
        private void InspectionBase_OpenEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<Aig.Auditoria.Events.Inspections.InspectionBase_OpenEvent>();

            Inspeccion = message.Inspeccion != null ? message.Inspeccion : new DataModel.AUD_InspeccionTB();

            OpenDialog = true;
            
            this.InvokeAsync(StateHasChanged);
        }
        //CLOSE MODAL TO ADD/EDIT INSPECTIONS 
        private void InspectionBase_CloseEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<Aig.Auditoria.Events.Inspections.InspectionBase_CloseEvent>();
                        
            OpenDialog = false;

            this.InvokeAsync(StateHasChanged);
        }
        private void InspectionType_SelectedEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<Aig.Auditoria.Events.Inspections.InspectionType_SelectedEvent>();

            Inspeccion.TipoActa = message.tipoActa;
            switch (Inspeccion.TipoActa)
            {
                case enumAUD_TipoActa.RetencionRetiroProductos:
                    {
                        Inspeccion.InspRetiroRetencion = Inspeccion.InspRetiroRetencion != null ? Inspeccion.InspRetiroRetencion : new AUD_InspRetiroRetencionTB() { LProductos=new List<AUD_ProdRetiroRetencionTB>()};
                        break;
                    }
                    default:
                    {
                        OpenDialog = false; 
                        bus.Publish(new Aig.Auditoria.Events.Inspections.InspectionBase_CloseEvent { });

                        return;
                    }
            }
            
            this.InvokeAsync(StateHasChanged);
        }

        protected async Task FetchData()
        {           
            await this.InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Saving Data
        /// </summary>

    }

}

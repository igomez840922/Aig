using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.FarmacoVigilancia.Components.ESAVI
{
    public partial class AddEdit
    {
        [Inject]
        IESAVIService esaviService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IWorkerPersonService evaluatorService { get; set; }
        [Inject]
        IPdfGenerationService pdfGenerationService { get; set; }
        [Inject]
        ITipoInstitucionService tipoInstitucionService { get; set; }
        [Inject]
        IProvicesService provicesService { get; set; }
        [Inject]
        IDestinyInstituteService destinyInstituteService { get; set; }

        [Parameter]
        public DataModel.FMV_EsaviTB Data { get; set; }
        List<PersonalTrabajadorTB> lEvaluators { get; set; }
        List<TipoInstitucionTB> lTipoInstitucion { get; set; }
        List<ProvinciaTB> lProvincias { get; set; }
        List<InstitucionDestinoTB> lInstitucionDestino { get; set; }

        bool OpenAddEditNotification { get; set; } = false;
        FMV_EsaviNotificacionTB Notificacion { get; set; } = null;

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
            lEvaluators = lEvaluators != null && lEvaluators.Count > 0 ? lEvaluators : await evaluatorService.GetAll();
            lTipoInstitucion = lTipoInstitucion!=null && lTipoInstitucion.Count > 0? lTipoInstitucion:await tipoInstitucionService.GetAll();
            lProvincias = lProvincias!=null && lProvincias.Count > 0? lProvincias: await provicesService.GetAll();

            lInstitucionDestino = await destinyInstituteService.FindAll(x => (Data.TipoInstitucionId != null ? x.TipoInstitucionId == Data.TipoInstitucionId : true) && (Data.ProvinciaId != null ? x.ProvinciaId == Data.ProvinciaId : true));
            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            var result = await esaviService.Save(Data);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Data = result;

                await bus.Publish(new Aig.FarmacoVigilancia.Events.ESAVI.AddEdit_CloseEvent { Data = Data });
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.ESAVI.AddEdit_CloseEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }

        //Add New Product
        protected async Task OpenProduct(FMV_EsaviNotificacionTB notificacion = null)
        {
            bus.Subscribe<Aig.FarmacoVigilancia.Events.ESAVINotification.AddEdit_CloseEvent>(Notification_AddEditCloseEventHandlerHandler);

            Notificacion = notificacion != null ? notificacion : new FMV_EsaviNotificacionTB();
            OpenAddEditNotification = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //Remove Product
        protected async Task RemoveProduct(FMV_EsaviNotificacionTB notificacion)
        {
            if (notificacion != null)
            {
                Data.LNotificaciones.Remove(notificacion);
                this.InvokeAsync(StateHasChanged);
            }
        }
        //ON CLOSE PRODUCT MODAL 
        private void Notification_AddEditCloseEventHandlerHandler(MessageArgs args)
        {
            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.ESAVINotification.AddEdit_CloseEvent>(Notification_AddEditCloseEventHandlerHandler);

            var message = args.GetMessage<Aig.FarmacoVigilancia.Events.ESAVINotification.AddEdit_CloseEvent>();

            Notificacion = null;
            OpenAddEditNotification = false;
            if (message.Data != null)
            {
                Data.LNotificaciones = Data.LNotificaciones != null ? Data.LNotificaciones : new List<FMV_EsaviNotificacionTB>();

                if (!Data.LNotificaciones.Contains(message.Data))
                    Data.LNotificaciones.Add(message.Data);
            }

            this.InvokeAsync(StateHasChanged);
        }

        protected async Task OnEvaluatorChange(long? Id)
        {
            Data.EvaluadorId = Id;
            Data.Evaluador = lEvaluators.Where(x => x.Id == Id).FirstOrDefault();
        }

        protected async Task OnChangeTipoInstitucion(long? Id)
        {
            Data.TipoInstitucionId = Id;
            Data.TipoInstitucion = lTipoInstitucion.Where(x => x.Id == Id).FirstOrDefault();
            await FetchData();
        }

        protected async Task OnChangeProvincia(long? Id)
        {
            Data.ProvinciaId = Id;
            Data.Provincia = lProvincias.Where(x => x.Id == Id).FirstOrDefault();
            await FetchData();
        }

        
    }

}

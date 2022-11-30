using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Aig.FarmacoVigilancia.Components.FT
{
    public partial class AddEdit
    {
        [Inject]
        IFTService ftService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IWorkerPersonService evaluatorService { get; set; }
        [Inject]
        IPdfGenerationService pdfGenerationService { get; set; }
        [Parameter]
        public DataModel.FMV_FtTB Data { get; set; }
        List<PersonalTrabajadorTB> lEvaluators { get; set; }

        bool OpenAddEditNotification { get; set; } = false;
        FMV_FtNotificacionTB Notificacion { get; set; } = null;

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

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            var result = await ftService.Save(Data);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Data = result;

                await bus.Publish(new Aig.FarmacoVigilancia.Events.FT.AddEdit_CloseEvent { Data = Data });
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.FT.AddEdit_CloseEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }

        //Add New Product
        protected async Task OpenProduct(FMV_FtNotificacionTB notificacion = null)
        {
            bus.Subscribe<Aig.FarmacoVigilancia.Events.FTNotification.AddEdit_CloseEvent>(Notification_AddEditCloseEventHandlerHandler);

            Notificacion = notificacion != null ? notificacion : new FMV_FtNotificacionTB();
            OpenAddEditNotification = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //Remove Product
        protected async Task RemoveProduct(FMV_FtNotificacionTB notificacion)
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
            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.FTNotification.AddEdit_CloseEvent>(Notification_AddEditCloseEventHandlerHandler);

            var message = args.GetMessage<Aig.FarmacoVigilancia.Events.FTNotification.AddEdit_CloseEvent>();

            Notificacion = null;
            OpenAddEditNotification = false;
            if (message.Data != null)
            {
                Data.LNotificaciones = Data.LNotificaciones != null ? Data.LNotificaciones : new List<FMV_FtNotificacionTB>();

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

    }

}

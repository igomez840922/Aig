using Aig.Auditoria.Events.Language;
using Aig.Auditoria.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Components;

namespace Aig.Auditoria.Components.OpenHours
{
    public partial class AddEditOpenHoursComponent
    {
        [Inject]
        IProfileService profileService { get; set; }
        bool OpenDialog { get; set; }
        [Parameter]
        public DataModel.AUD_DatosHorario HorarioApertura { get; set; } = null;
       
        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            //bus.Subscribe<Aig.Auditoria.Events.OpenHours.OpenHoursAddEdit_OpenEvent>(AddEditOpenEventHandler);

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
            OpenDialog = true;
            HorarioApertura = HorarioApertura != null ? HorarioApertura : new DataModel.AUD_DatosHorario();

            await this.InvokeAsync(StateHasChanged);
        }

        //OPEN MODAL TO ADD/Edit 
        //private void AddEditOpenEventHandler(MessageArgs args)
        //{
        //    var message = args.GetMessage<Aig.Auditoria.Events.OpenHours.OpenHoursAddEdit_OpenEvent>();

        //    HorarioApertura = message.Data != null ? message.Data : new DataModel.AUD_DatosHorario();            

        //    this.InvokeAsync(StateHasChanged);
        //}


        /// <summary>
        /// Saving Data
        /// </summary>

        protected async Task SaveData()
        {
            //bus.UnSubscribe<Aig.Auditoria.Events.OpenHours.OpenHoursAddEdit_OpenEvent>(AddEditOpenEventHandler);
            OpenDialog = false;
            await bus.Publish(new Aig.Auditoria.Events.OpenHours.OpenHoursAddEdit_CloseEvent { Data = HorarioApertura });
            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task Cancel()
        {
            //bus.UnSubscribe<Aig.Auditoria.Events.OpenHours.OpenHoursAddEdit_OpenEvent>(AddEditOpenEventHandler);
            OpenDialog = false;
            await bus.Publish(new Aig.Auditoria.Events.OpenHours.OpenHoursAddEdit_CloseEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }

    }

}

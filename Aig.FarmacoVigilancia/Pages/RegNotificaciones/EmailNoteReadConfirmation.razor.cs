using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using Microsoft.AspNetCore.Components;

namespace Aig.FarmacoVigilancia.Pages.RegNotificaciones
{
    public partial class EmailNoteReadConfirmation
    {
        [Parameter] public long notaId { get; set; }

        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        INoteService noteService { get; set; }

       
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
            //OpenDialog = true;
            //datoContacto = datoContacto != null ? datoContacto : new DataModel.Models.UnSubscribeModel();

            await noteService.NotifyNoteReaded(notaId);

            await this.InvokeAsync(StateHasChanged);
        }
    }
}

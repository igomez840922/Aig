using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using DataModel;
using DataModel.Helper;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace Aig.FarmacoVigilancia.Components.NotaDestino
{
    public partial class AddEdit
    {
        [Inject]
        INotaDestinoService notaDestinoService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IPdfGenerationService pdfGenerationService { get; set; }
        
        [Parameter]
        public DataModel.FMV_NotaDestinoTB Data { get; set; }
        
        bool OpenNuevoContacto { get; set; } = false;
        bool OpenSearchContacto { get; set; } = false;
        DataModel.FMV_ContactosTB datoContacto { get; set; } = null;

        List<NotaClasificacion> LClasificaciones { get; set; } = new List<NotaClasificacion>();

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
            if(LClasificaciones.Count <= 0)
            {
                foreach (enumFMV_NoteType dt in Enum.GetValues(typeof(enumFMV_NoteType)))
                {
                    LClasificaciones.Add(new NotaClasificacion() { NoteType=dt });
                }
            }

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            var result = await notaDestinoService.Save(Data);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Data = result;

                await bus.Publish(new Aig.FarmacoVigilancia.Events.NotaDestino.CloseEvent { Data = Data });
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new Aig.FarmacoVigilancia.Events.NotaDestino.CloseEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }


        //Add New Contact
        protected async Task OpenNewContact(DataModel.FMV_ContactosTB contacto = null)
        {
            bus.Subscribe<Aig.FarmacoVigilancia.Events.Contacts.ContactsEvent>(Contacto_AddEditCloseEventHandlerHandler);

            datoContacto = contacto != null ? contacto : new DataModel.FMV_ContactosTB();
            OpenNuevoContacto = true;

            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task OpenContact()
        {
            bus.Subscribe<Aig.FarmacoVigilancia.Events.Contacts.ContactsEvent>(Contacto_AddEditCloseEventHandlerHandler);

            OpenSearchContacto = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //Remove Product
        protected async Task RemoveContact(DataModel.FMV_ContactosTB contacto)
        {
            if (contacto != null)
            {
                Data.NotaContactos.LContactos.Remove(contacto);
                this.InvokeAsync(StateHasChanged);
            }
        }
        //ON CLOSE PRODUCT MODAL 
        private void Contacto_AddEditCloseEventHandlerHandler(MessageArgs args)
        {
            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.Contacts.ContactsEvent>(Contacto_AddEditCloseEventHandlerHandler);

            var message = args.GetMessage<Aig.FarmacoVigilancia.Events.Contacts.ContactsEvent>();

            datoContacto = null;
            OpenSearchContacto = false;
            OpenNuevoContacto = false;
            if (message.Data != null)
            {
                Data.NotaContactos.LContactos = Data.NotaContactos.LContactos != null ? Data.NotaContactos.LContactos  : new List<DataModel.FMV_ContactosTB>();

                if (!Data.NotaContactos.LContactos.Contains(message.Data))
                    Data.NotaContactos.LContactos.Add(message.Data);
            }

            this.InvokeAsync(StateHasChanged);
        }


    }

}

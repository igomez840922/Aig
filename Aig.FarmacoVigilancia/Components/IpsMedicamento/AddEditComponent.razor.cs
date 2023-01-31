using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Pages.IPS;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using static SkiaSharp.HarfBuzz.SKShaper;

namespace Aig.FarmacoVigilancia.Components.IpsMedicamento
{    
    public partial class AddEditComponent
    {
        [Inject]
        IProfileService profileService { get; set; }
        
        bool OpenDialog { get; set; }
        [Parameter]
        public DataModel.FMV_IpsMedicamentoTB Data { get; set; } = null;

        [Inject]
        ILabsService labsService { get; set; }
        List<LaboratorioTB> Labs { get; set; } = new List<LaboratorioTB>();

        bool showSearchMedicine { get; set; } = false;


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
            Labs = Labs?.Count > 0?Labs: await labsService.GetAll();

            OpenDialog = true;
            Data = Data != null ? Data : new DataModel.FMV_IpsMedicamentoTB();

            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task SaveData()
        {
            OpenDialog = false;

            if(Data!=null)
            {
                Data.Laboratorio = Labs?.Where(x=>x.Id == Data.LaboratorioId)?.FirstOrDefault();
            }

            //await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
            await bus.Publish(new Aig.FarmacoVigilancia.Events.IPSMedicamento.AddEditEvent { Data = Data });
            bus.UnSubscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task Cancel()
        {
            //bus.UnSubscribe<Aig.Auditoria.Events.OpenHours.OpenHoursAddEdit_OpenEvent>(AddEditOpenEventHandler);
            OpenDialog = false;
            await bus.Publish(new Aig.FarmacoVigilancia.Events.IPSMedicamento.AddEditEvent { Data = null });
            bus.UnSubscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            await this.InvokeAsync(StateHasChanged);
        }


        protected async Task OpenSearchMedicine()
        {
            bus.Subscribe<Aig.FarmacoVigilancia.Events.SearchMedicines.SearchMedicinesEvent>(MedicineSearchEventHandler);

            showSearchMedicine = true;

            await this.InvokeAsync(StateHasChanged);
        }
        private void MedicineSearchEventHandler(MessageArgs args)
        {
            showSearchMedicine = false;

            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.SearchMedicines.SearchMedicinesEvent>(MedicineSearchEventHandler);

            var message = args.GetMessage<Aig.FarmacoVigilancia.Events.SearchMedicines.SearchMedicinesEvent>();

            if (message.Data != null)
            {
                Data.RegSanitario = message.Data.numReg;
                Data.NomComercial = message.Data.nombre;
                Data.RegSanitario = string.IsNullOrEmpty(message.Data.numReg) ? Data.RegSanitario : message.Data.numReg;
            }

            this.InvokeAsync(StateHasChanged);
        }

    }

}

using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Events.PmrProduct;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;

namespace Aig.FarmacoVigilancia.Components.PmrProduct
{    
    public partial class AddEditProductComponent
    {
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        ILabsService labsService { get; set; }
        List<LaboratorioTB> lLaboratorio { get; set; } = new List<LaboratorioTB>(); 

        [Parameter]
        public DataModel.FMV_PmrProductoTB Product { get; set; } = null;

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            bus.Subscribe<AddEdit_OpenEvent>(AddEditOpenEventHandler);

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
            if (lLaboratorio == null || lLaboratorio.Count < 1)
            {
                lLaboratorio = await labsService.GetAll();
            }

            if (Product != null && Product.LaboratorioId == null)
            {
                Product.Laboratorio = lLaboratorio?.FirstOrDefault()??null;
                Product.LaboratorioId = Product.Laboratorio?.Id ?? null;
            }

            await this.InvokeAsync(StateHasChanged);
        }

        //OPEN MODAL TO ADD/Edit 
        private void AddEditOpenEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<AddEdit_OpenEvent>();

            Product = message.Data != null ? message.Data : new DataModel.FMV_PmrProductoTB();

            FetchData();
        }


        /// <summary>
        /// Saving Data
        /// </summary>

        protected async Task SaveData()
        {
            if(Product.LaboratorioId!= null && Product.LaboratorioId> 0)
            {
                Product.Laboratorio = lLaboratorio.Where(x=>x.Id == Product.LaboratorioId).FirstOrDefault();
            }

            await bus.Publish(new AddEdit_CloseEvent { Data = Product });
            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task Cancel()
        {
            await bus.Publish(new AddEdit_CloseEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }

    }
}
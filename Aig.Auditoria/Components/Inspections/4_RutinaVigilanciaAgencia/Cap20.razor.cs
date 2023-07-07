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

namespace Aig.Auditoria.Components.Inspections._4_RutinaVigilanciaAgencia
{
    public partial class Cap20
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

        bool showInvProduct { get; set; } = false;
        DataModel.AUD_InvProducto producto { get; set; } = null;

        bool disabledBtns { get; set; }
        protected async override Task OnInitializedAsync()
        {
            timer.Elapsed += (sender, eventArgs) => {
                _ = InvokeAsync(() =>
                {
                    if (disabledBtns)
                        return;

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
                switch (Inspeccion.StatusInspecciones)
                {
                    case enum_StatusInspecciones.Completed:
                        {
                            disabledBtns = true;
                            break;
                        }
                }
                editContext = editContext != null ? editContext : new(Inspeccion);

                if (Inspeccion.InspRutinaVigAgencia.InventarioMedicamento == null)
                {
                    Inspeccion.InspRutinaVigAgencia.InventarioMedicamento = new AUD_InventarioMedicamento();
                }
            }
            else { Cancel(); }

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            try
            {
                var result = await inspeccionService.Save_RutinaVigilanciaAgencia_Cap20(Inspeccion);
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

        ////////////////
        ///
        //Add New Product
        protected async Task OpenProduct(AUD_InvProducto product = null)
        {
            bus.Subscribe<Aig.Auditoria.Events.InvProduct.CloseEvent>(AddEditCloseEventHandler);

            product = product != null ? product : new AUD_InvProducto();

            this.producto = product;
            showInvProduct = true;

            await this.InvokeAsync(StateHasChanged);
        }
        //Remove Product
        protected async Task RemoveProduct(AUD_InvProducto product)
        {
            if (product != null)
            {
                Inspeccion.InspRutinaVigAgencia.InventarioMedicamento.LProductos.Remove(product);
            }
            await this.InvokeAsync(StateHasChanged);
        }
        //ON CLOSE PRODUCT MODAL 
        private void AddEditCloseEventHandler(MessageArgs args)
        {
            this.producto = null;
            showInvProduct = false;

            bus.UnSubscribe<Aig.Auditoria.Events.InvProduct.CloseEvent>(AddEditCloseEventHandler);

            var message = args.GetMessage<Aig.Auditoria.Events.InvProduct.CloseEvent>();

            if (message.Data != null)
            {
                if (!Inspeccion.InspRutinaVigAgencia.InventarioMedicamento.LProductos.Contains(message.Data))
                    Inspeccion.InspRutinaVigAgencia.InventarioMedicamento.LProductos.Add(message.Data);

            }
            this.InvokeAsync(StateHasChanged);
        }

    }

}

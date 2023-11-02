using AuditoriaApp.Services;
using DataModel;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditoriaApp.Components.Dialog.ProductosRetirados
{
    public partial class AddEdit
    {
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        bool loading { get; set; } = false;

        [Parameter]
        public AUD_ProdRetiroRetencionTB Data { get; set; } = new AUD_ProdRetiroRetencionTB();

        [Inject]
        IPaisService paisService { get; set; }

        //private FluentValidationValidator formValidator;
        List<PaisTB> LPaises { get; set; }

        protected async override Task OnInitializedAsync()
        {
            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await FetchData();
            }
        }

        public void Dispose()
        {
            //bus.UnSubscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
        }

        /// <summary>
        /// Saving Data
        /// </summary>

        protected async Task FetchData()
        {
            loading = false;

            await LoadData();

            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task LoadData()
        {
            LPaises = await paisService.GetAll();

            await this.InvokeAsync(StateHasChanged);
        }

        protected async Task Cancel()
        {
            MudDialog.Cancel();
        }

        protected async Task SaveData()
        {
            loading = true;
            try
            {
                MudDialog.Close(DialogResult.Ok(Data));
                return;
            }
            catch (Exception ex)
            {
                snackbar.Add(ex.Message, Severity.Error);
            }
            finally { loading = false; await this.InvokeAsync(StateHasChanged); }
        }

    }

}

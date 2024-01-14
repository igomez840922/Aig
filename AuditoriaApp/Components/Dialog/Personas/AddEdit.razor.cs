using DataModel;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AuditoriaApp.Components.Dialog.Personas
{
    public partial class AddEdit
    {
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        bool loading { get; set; } = false;

        [Parameter]
        public DatosPersona Data { get; set; } = new DatosPersona();

        //private FluentValidationValidator formValidator;

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

            Data = Data!=null ? Data : new DatosPersona();

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

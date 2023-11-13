using AuditoriaApp.Services;
using DataModel;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditoriaApp.Components.Inspections._15_BpmBPA
{
    public partial class Cap12
    {
        [Inject]
        IInspectionService inspectionService { get; set; }
        [Inject]
        IUploadService uploadManager { get; set; }

        [Inject]
        IDialogService dialogService { get; set; }

        [Parameter]
        public DataModel.APP_Inspeccion Inspeccion { get; set; }

        [Parameter]
        public EventCallback BackToMain { get; set; }


        /////////////////////////
        ///
        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            //bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            base.OnInitialized();
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await FetchData();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        protected async Task FetchData()
        {
            try
            {
                Inspeccion.Inspeccion.DatosConclusiones = Inspeccion.Inspeccion.DatosConclusiones != null ? Inspeccion.Inspeccion.DatosConclusiones : new AUD_DatosConclusiones();
                Inspeccion.Inspeccion.ParticipantesDNFD = Inspeccion.Inspeccion.ParticipantesDNFD != null ? Inspeccion.Inspeccion.ParticipantesDNFD : new AUD_ParticipantesDNFD();
                Inspeccion.Inspeccion.InspGuiaBPM_Bpa.DatosRepresentLegal = Inspeccion.Inspeccion.InspGuiaBPM_Bpa.DatosRepresentLegal != null ? Inspeccion.Inspeccion.InspGuiaBPM_Bpa.DatosRepresentLegal : new DatosPersona();
                Inspeccion.Inspeccion.InspGuiaBPM_Bpa.DatosRegente = Inspeccion.Inspeccion.InspGuiaBPM_Bpa.DatosRegente != null ? Inspeccion.Inspeccion.InspGuiaBPM_Bpa.DatosRegente : new DatosPersona();

                await LoadData();
            }
            catch { }
            finally
            {
                await this.InvokeAsync(StateHasChanged);
            }
        }

        protected async Task LoadData()
        {

            await this.InvokeAsync(StateHasChanged);
        }

        ////////////////////
        ///

        protected async Task Cancel(bool warning = true)
        {
            try
            {
                if (warning)
                {
                    var parameters = new DialogParameters{
             { nameof(Components.Dialog.DialogComponent.ContentText), string.Format("Los cambios no guardados se perderán. Está seguro desea salir?") }};
                    var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
                    var dialog = dialogService.Show<Components.Dialog.DialogComponent>("Confirmar Salir", parameters, options);
                    var result = await dialog.Result;
                    if (result.Cancelled)
                    {
                        return;
                    }
                }
                this.BackToMain.InvokeAsync();
            }
            catch (Exception ex)
            {
                snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                await this.InvokeAsync(StateHasChanged);
            }
        }

        protected async Task<bool> Save()
        {
            try
            {
                Inspeccion.PendingUpdate = true;
                Inspeccion.Inspeccion.PendingUpdate = true;
                Inspeccion.Inspeccion.InspGuiaBPM_Bpa.DatosRepresentLegal.PendingUpdate = true;
                Inspeccion.Inspeccion.InspGuiaBPM_Bpa.DatosRegente.PendingUpdate = true;
                Inspeccion.Inspeccion.ParticipantesDNFD.PendingUpdate = true;

                var data = inspectionService.Save(Inspeccion);
                if (data != null)
                {
                    snackbar.Add("Datos guardados satisfactoriamente", Severity.Info);
                    return true;
                }
            }
            catch (Exception ex)
            {
                snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                await this.InvokeAsync(StateHasChanged);
            }
            snackbar.Add("Error al guardar los datos", Severity.Error);
            return false;
        }

        protected async Task SaveExit()
        {
            try
            {
                if (await Save())
                {
                    await Cancel(false);
                }
            }
            catch (Exception ex)
            {
                snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                await this.InvokeAsync(StateHasChanged);
            }
        }

        //////////////////////////////
        ///

        private async Task UploadFile()
        {
            try
            {
                var parameters = new DialogParameters { };
                var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true, DisableBackdropClick = true };
                var dialog = dialogService.Show<AuditoriaApp.Components.Attachments.AddEdit>("Adjuntar Archivo", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    if (result.Data != null)
                    {
                        var attachment = (AttachmentTB)result.Data;
                        Inspeccion.Inspeccion.DatosConclusiones.LAttachments = Inspeccion.Inspeccion.DatosConclusiones.LAttachments?.Count > 0 ? Inspeccion.Inspeccion.DatosConclusiones.LAttachments : new List<AttachmentTB>();
                        Inspeccion.Inspeccion.DatosConclusiones.LAttachments.Add(attachment);
                        await this.InvokeAsync(StateHasChanged);
                    }
                }
            }
            catch { }
        }
        private async Task DeleteFile(AttachmentTB file)
        {
            try
            {
                //Open Modal
                var parameters = new DialogParameters{
             { nameof(Components.Dialog.DialogComponent.ContentText), string.Format("Está seguro desea eliminar el dato seleccionado?") }};
                var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
                var dialog = dialogService.Show<Components.Dialog.DialogComponent>("Confirmar Eliminar", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var succeeded = await uploadManager.DeleteFile(file);
                    if (succeeded)
                    {
                        Inspeccion.Inspeccion.DatosConclusiones.LAttachments.Remove(file);
                        await this.InvokeAsync(StateHasChanged);
                    }
                    else
                    {
                        snackbar.Add("Error al remover el adjunto", Severity.Error);
                    }
                }
            }
            catch { }
        }
        private async Task OpenFile(AttachmentTB file)
        {
            try
            {
                await uploadManager.ExecuteFile(file.AbsolutePath);
            }
            catch { }
        }

    }
}

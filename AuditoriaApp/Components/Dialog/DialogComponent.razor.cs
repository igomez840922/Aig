using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AuditoriaApp.Components.Dialog
{
    public partial class DialogComponent
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter] public string ContentText { get; set; }

        [Parameter] public string ButtonText { get; set; } = "Confirm";

        [Parameter] public MudBlazor.Color Color { get; set; } = MudBlazor.Color.Error;

        void Submit() => MudDialog.Close(DialogResult.Ok(true));
        void Cancel() => MudDialog.Cancel();        

    }
}

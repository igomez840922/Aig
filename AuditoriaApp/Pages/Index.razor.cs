namespace AuditoriaApp.Pages
{
    public partial class Index
    {
        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                navigationManager.NavigateTo("/dashboard");
            }
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}

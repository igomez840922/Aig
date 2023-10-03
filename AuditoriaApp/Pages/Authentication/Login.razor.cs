using AuditoriaApp.Services;
using BlazorComponentBus;
using DataModel.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using AuditoriaApp.Events.Overlay;

namespace AuditoriaApp.Pages.Authentication
{
    public partial class Login
    {
        private LoginDTO loginRequest = new LoginDTO();
		
		[Inject]
        public IAuthenticationService AuthenticationService { get; set; }
        [Inject]
        public IAccountDataService AccountDataService { get; set; }

        

        [CascadingParameter]
		protected Task<AuthenticationState> authStat { get; set; }

		public bool ShowAuthError { get; set; }
        public string Error { get; set; }

        //string Password { get; set; } = "BMWvBPJXZu";

        bool PasswordVisibility;
        InputType PasswordInput = InputType.Password;
        string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

		protected async override Task OnInitializedAsync()
		{
			var user = (await authStat).User;
			if (user.Identity.IsAuthenticated)
			{
				navigationManager.NavigateTo("/dashboard");
				return;
			}
            			
			await base.OnInitializedAsync();
		}

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
				
			}
			await base.OnAfterRenderAsync(firstRender);
		}


		void TogglePasswordVisibility()
        {
            if(PasswordVisibility)
            {
                PasswordVisibility = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
            else
            {
                PasswordVisibility = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }

        public async Task OnLogin()
        {
            await bus.Publish(new OverlayShowEvent { Show = true }) ;
            try {
                ShowAuthError = false;

                var result = await AuthenticationService.Login(loginRequest);
                if (!result.IsAuthSuccessful)
                {
                    Error = result.ErrorMessage;
                    ShowAuthError = true;
                }
                else
                {
                    //save login user data in localdb
                    var data = await AccountDataService.First();
                    data = data != null ? data : new Data.AccountData();
                    data.UserId = result.UserId;
                    data.AccessToken = result.Token;
                    await AccountDataService.Save(data);

                    navigationManager.NavigateTo("/dashboard");
                }
            }
            catch { }
            finally { await bus.Publish(new OverlayShowEvent { Show = false }); }
            
        }


	}
}

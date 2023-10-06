using AuditoriaApp.Services;
using BlazorComponentBus;
using DataModel.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using AuditoriaApp.Events.Overlay;
using System.Net.Http.Headers;
using DataModel;
using DataModel.Models;

namespace AuditoriaApp.Pages.Authentication
{
    public partial class Login
    {
        private LoginModel model = new LoginModel();
		
		[Inject]
        public IAuthenticationService AuthenticationService { get; set; }
       
        

        [CascadingParameter]
		protected Task<AuthenticationState> authStat { get; set; }

		public bool ShowAuthError { get; set; }
        public string Error { get; set; }

        //string Password { get; set; } = "BMWvBPJXZu";

        bool PasswordVisibility;
        InputType PasswordInput = InputType.Password;
        string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

        private bool loading { get; set; } = false;

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

        private bool _passwordVisibility;
        private InputType _passwordInput = InputType.Password;
        private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;

        void TogglePasswordVisibility()
        {
            if (_passwordVisibility)
            {
                _passwordVisibility = false;
                _passwordInputIcon = Icons.Material.Filled.VisibilityOff;
                _passwordInput = InputType.Password;
            }
            else
            {
                _passwordVisibility = true;
                _passwordInputIcon = Icons.Material.Filled.Visibility;
                _passwordInput = InputType.Text;
            }
        }
        

        public async Task OnLogin()
        {
            await bus.Publish(new OverlayShowEvent { Show = true }) ;
            try {
                ShowAuthError = false;

                var result = await AuthenticationService.Login(model);
                if (!result.IsAuthSuccessful)
                {
                    Error = result.ErrorMessage;
                    ShowAuthError = true;
                }
                else
                {
                                       
                    navigationManager.NavigateTo("/dashboard");
                }
            }
            catch { }
            finally { await bus.Publish(new OverlayShowEvent { Show = false }); }
            
        }


	}
}

using Aig.Auditoria2.Events.Language;
using Aig.Auditoria2.Events.Province;
using Aig.Auditoria2.Services;
using BlazorComponentBus;
using DataModel.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace Aig.Auditoria2.Pages.Pages.Authentication
{
    public partial class Login
    {
        private LoginDTO loginRequest = new LoginDTO();
		
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

		protected async override Task OnInitializedAsync()
		{
			var user = (await authStat).User;
			if (user.Identity.IsAuthenticated)
			{
				navigationManager.NavigateTo("/dashboard", true);
				return;
			}

			//Subscribe Component to Language Change Event
			bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);

			await base.OnInitializedAsync();
		}

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
				await getUserLanguaje();
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
                    navigationManager.NavigateTo("/dashboard");
                }
            }
            catch { }
            finally { await bus.Publish(new OverlayShowEvent { Show = false }); }
            
        }


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

	}
}

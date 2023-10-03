using DataModel;
using DataModel.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using AuditoriaApp.Events.Overlay;
using AuditoriaApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditoriaApp.Pages.Authentication
{
	public partial class Register
	{
		public bool ShowAuthError { get; set; }
		public string Error { get; set; }

		string Password { get; set; }
		public bool AgreeToTerms { get; set; }

		bool PasswordVisibility;
		InputType PasswordInput = InputType.Password;
		string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

		void TogglePasswordVisibility()
		{
			if (PasswordVisibility)
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

		private RegisterModel RegisterRequest = new RegisterModel() { UserProfile  = new UserProfileTB()};

		[Inject]
		public IAuthenticationService AuthenticationService { get; set; }
		[CascadingParameter]
		protected Task<AuthenticationState> authStat { get; set; }
						
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
				

		public async Task OnRegister()
		{
			await bus.Publish(new OverlayShowEvent { Show = true });
			try
			{
				ShowAuthError = false;

				var result = await AuthenticationService.RegisterUser(RegisterRequest);
				if (!result.IsSuccessfulRegistration)
				{
					Error = result.ErrorMessage;
					ShowAuthError = true;
				}
				else
				{
					snackbar.Add(languageContainerService.Keys["RegistrationSuccessfully"], Severity.Success);
					navigationManager.NavigateTo("/login");
				}
			}
			catch { }
			finally { await bus.Publish(new OverlayShowEvent { Show = false }); }

		}


	}
}

using Aig.FarmacoVigilancia.Helper;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using DataModel.Models;
using Aig.FarmacoVigilancia.Services;
using BlazorComponentBus;
using Aig.FarmacoVigilancia.Events;
using Aig.FarmacoVigilancia.Events.Language;
using Microsoft.JSInterop;

namespace Aig.FarmacoVigilancia.Pages.Login
{
    public partial class ForgotPassword
    {
        [Inject]
        UserManager<ApplicationUser> userManager { get; set; }
        [Inject]
        SignInManager<ApplicationUser> signInManager { get; set; }
		[Inject]
		IProfileService profileService { get; set; }
		[Inject]
		ISystemUserService systemUserService { get; set; }
		[Inject]
		IAuthService authService { get; set; }
		


		[CascadingParameter]
        protected Task<AuthenticationState> authStat { get; set; }

		ReqPINModel reqPINModel { get; set; } = new ReqPINModel();
		ChangePswPinModel changePswModel { get; set; }

        string error { get; set; }

        protected async override Task OnInitializedAsync()
        {		
			//var user = (await authStat).User;
   //         if (user.Identity.IsAuthenticated)
   //         {
   //             navigationManager.NavigateTo("./dashboard", true);
   //             return;
   //         }

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


		async Task OnChangePassword()
		{
			error = null;
			try
			{
				var response = await systemUserService.ChangePswPIN(changePswModel);
				if (response != null)
				{
					if(response.Result) {
						await jsRuntime.InvokeVoidAsync("ShowMessage", response.Message);
						BackLogin();
						return;
					}
					await jsRuntime.InvokeVoidAsync("ShowError", response.Message);
					return;

				}
				error = "error al intentar actualizar su contraseña";
				await jsRuntime.InvokeVoidAsync("ShowError", error);
				return;

			}
			catch (Exception ex)
			{
				error = ex.Message;
			}
		}

		async Task OnReqPin()
		{
			error = null;
			try
			{
				var usr = await systemUserService.GetUser(reqPINModel.Email);
				if (usr == null)
				{
					error = "usuario no existente";
					await jsRuntime.InvokeVoidAsync("ShowError", error);
					return;
				}

				var response = await authService.RequestPin(reqPINModel);
				if (!response.Result)
				{
					error = response.Message;
					await jsRuntime.InvokeVoidAsync("ShowError", error);
					return;
				}

				error = "el PIN de seguridad se ha enviado a su correo";
				await jsRuntime.InvokeVoidAsync("ShowMessage", error);

				changePswModel = new ChangePswPinModel() { UserName = reqPINModel.Email };

			}
			catch (Exception ex)
			{
				error = ex.Message;
			}
		}


		async Task BackLogin()
		{
			navigationManager.NavigateTo("./login");
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

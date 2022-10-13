using Aig.Auditoria.Helper;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using DataModel.Models;
using Aig.Auditoria.Services;
using BlazorComponentBus;
using Aig.Auditoria.Events;

namespace Aig.Auditoria.Pages.Login
{
    public partial class Login
    {
        [Inject]
        UserManager<ApplicationUser> userManager { get; set; }
        [Inject]
        SignInManager<ApplicationUser> signInManager { get; set; }
		[Inject]
		IProfileService profileService { get; set; }

		[CascadingParameter]
        protected Task<AuthenticationState> authStat { get; set; }

        LoginModel loginRequest { get; set; } = new LoginModel();
        string error { get; set; }

        protected async override Task OnInitializedAsync()
        {			

			var user = (await authStat).User;
            if (user.Identity.IsAuthenticated)
            {
                navigationManager.NavigateTo("/",true);
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


		async Task OnLogin()
        {
            error = null;
            try
            {
                var usr = await userManager.FindByNameAsync(loginRequest.UserName);
                if (usr == null)
                {
                    error = "usuario o contraseña no válidos";
                    return;
                }

                if (await signInManager.CanSignInAsync(usr))
                {
                    var result = await signInManager.CheckPasswordSignInAsync(usr, loginRequest.Password, true);
                    if (result.Succeeded)
                    {
                        Guid key = BlazorCookieLoginMiddleware<ApplicationUser>.AnnounceLogin(loginRequest);
                        //navigationManager.NavigateTo($"login?key={key}",true);
                        navigationManager.NavigateTo(string.Format("./login?key={0}", key), true);
                        return;
                    }
                    else
                    {
                        error = "usuario o contraseña no válidos";
                    }
                }
                else
                {
                    error = "su cuenta ha sido bloqueada";

                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
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

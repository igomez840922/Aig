using Aig.Auditoria.Events;
using Aig.Auditoria.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;

namespace Aig.Auditoria.Shared
{
	public partial class AccountLayout
	{
		[Inject]
		IAuthService authService { get; set; }
		[Inject]
		ISystemUserService systemUserService { get; set; }
		[Inject]
		IProfileService profileService { get; set; }

		#region Variables

		[CascadingParameter]
		protected Task<AuthenticationState> authStat { get; set; }


		#endregion

		#region Events
		protected async override Task OnInitializedAsync()
		{
			//Subscribe Component to Language Change Event
			bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);

			await base.OnInitializedAsync();
		}

		protected override async Task OnParametersSetAsync()
		{
			//await FetchData();
		}

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
				//JS.InvokeAsync<IJSObjectReference>("import", "./assets/plugins/global/plugins.bundle.js");
				jsRuntime.InvokeAsync<IJSObjectReference>("import", "./assets/js/scripts.bundle.js");
				//JS.InvokeAsync<IJSObjectReference>("import", "./assets/js/pages/dashboard.js");

				await getUserLanguaje();
			}
			//return base.OnAfterRenderAsync(firstRender);
		}

		#endregion

		#region Functions

		protected async Task FetchData()
		{
			this.InvokeAsync(StateHasChanged);
		}

		protected async Task getUserLanguaje(string? language=null)
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


		#endregion


	}
}

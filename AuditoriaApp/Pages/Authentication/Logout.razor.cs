﻿using AuditoriaApp.Services;
using Microsoft.AspNetCore.Components;

namespace AuditoriaApp.Pages.Authentication
{
	public partial class Logout
	{

		[Inject]
		public IAuthenticationService AuthenticationService { get; set; }
		[Inject]
		public NavigationManager NavigationManager { get; set; }

		protected override async Task OnInitializedAsync()
		{
			await AuthenticationService.Logout();
			NavigationManager.NavigateTo("/");
		}
	}
}

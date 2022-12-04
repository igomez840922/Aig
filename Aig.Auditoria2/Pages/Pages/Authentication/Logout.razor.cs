using Aig.Auditoria2.Services;
using Microsoft.AspNetCore.Components;

namespace Aig.Auditoria2.Pages.Pages.Authentication
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

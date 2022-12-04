using Aig.Auditoria2;
using Aig.Auditoria2.Helper;
using Aig.Auditoria2.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IApiConnectionService, ApiConnectionService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IProfileService, ProfileService>();

//For Components Comunucations Pul-Sub
builder.Services.AddScoped<ComponentBus>();
//languaje
builder.Services.AddLanguageContainer(Assembly.GetExecutingAssembly());
//local storage
builder.Services.AddBlazoredLocalStorage();
//authorization
builder.Services.AddAuthorizationCore();

//mudblazor
builder.Services.AddMudServices();



await builder.Build().RunAsync();

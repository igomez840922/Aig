using Aig.Farmacoterapia.Wasm.Client;
using Aig.Farmacoterapia.Wasm.Client.Infrastructure;
using Aig.Farmacoterapia.Wasm.Client.Infrastructure.Authentication;
using BlazorComponentBus;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace Aig.Farmacoterapia.Wasm.Client.Extensions
{
    public static class WebAssemblyHostBuilderExtensions
    {
        private const string ClientName = "Aig.Farmacoterapia.API";

        public static WebAssemblyHostBuilder AddRootComponents(this WebAssemblyHostBuilder builder)
        {
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            return builder;
        }

        public static WebAssemblyHostBuilder AddClientServices(this WebAssemblyHostBuilder builder, IConfiguration configuration)
        {

            builder.Services.AddSingleton(
                 configuration!.GetSection("AppConfiguration")
                .Get<AppConfiguration>());
            builder.Services
                .AddAuthorizationCore()
                .AddBlazoredLocalStorage()
               .AddMudServices(configuration =>{
                   configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
                   configuration.SnackbarConfiguration.HideTransitionDuration = 100;
                   configuration.SnackbarConfiguration.ShowTransitionDuration = 100;
                   configuration.SnackbarConfiguration.VisibleStateDuration = 3000;
                   configuration.SnackbarConfiguration.ShowCloseIcon = false;
                 })
                .AddScoped<AppStateProvider>()
                .AddScoped<AuthenticationStateProvider, AppStateProvider>()
                .AddManagers()
                .AddTransient<AuthenticationHeaderHandler>()
                .AddScoped(sp => sp
                    .GetRequiredService<IHttpClientFactory>()
                    .CreateClient(ClientName).EnableIntercept(sp))
                .AddHttpClient(ClientName, client => {
                    var apiUrl = configuration.GetSection("AppConfiguration")["ApiUrl"];
                    client.DefaultRequestHeaders.AcceptLanguage.Clear();
                    client.DefaultRequestHeaders.AcceptLanguage.ParseAdd(CultureInfo.DefaultThreadCurrentCulture?.TwoLetterISOLanguageName);
                    client.BaseAddress = new Uri(apiUrl);
                })
                .AddHttpMessageHandler<AuthenticationHeaderHandler>();
            builder.Services.AddHttpClientInterceptor();
            //For Components Comunucations Pul-Sub
            //builder.Services.AddScoped<ComponentBus>();
            return builder;
        }

        public static IServiceCollection AddManagers(this IServiceCollection services)
        {
            var managers = typeof(IManager);

            var types = managers
                .Assembly
                .GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Service = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .Where(t => t.Service != null);

            foreach (var type in types)
            {
                if (managers.IsAssignableFrom(type.Service))
                {
                    services.AddTransient(type.Service, type.Implementation);
                }
            }

            return services;
        }

       
    }
}
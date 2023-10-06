using AuditoriaApp.Helper;
using AuditoriaApp.Services;
using BlazorComponentBus;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using System.Reflection;

namespace AuditoriaApp
{
    public static class MauiProgram
    {
        public static IServiceProvider serviceProvider { get; set; }
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            //Para agregar archivo de configuracion appsettings.json
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AuditoriaApp.Resources.appsettings.json");
            var config = new ConfigurationBuilder().AddJsonStream(stream).Build();
            builder.Configuration.AddConfiguration(config);


            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

           
            //MUDBLAZOR
            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = MudBlazor.Defaults.Classes.Position.TopRight;
                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = false;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 10000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = MudBlazor.Variant.Filled;
            });

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(config.GetConnectionString("DefaultConnection")));
            //builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            //COMMON SERVICES
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IApiConnectionService, ApiConnectionService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
            builder.Services.AddScoped<ISystemUserService, SystemUserService>();
            builder.Services.AddScoped<IUploadService, UploadService>();
            builder.Services.AddSingleton<IDalService, DalService>();
            builder.Services.AddSingleton<IFeatureService, FeatureService>();
            builder.Services.AddScoped<IAccountDataService, AccountDataService>();
            builder.Services.AddScoped<IInspectionService, InspectionService>();

            //QUARTZ            
            // Register the QuartzSchedulerService as a singleton
            builder.Services.AddSingleton<IQuartzSchedulerService, QuartzSchedulerService>();

            //For Components Comunucations Pul-Sub
            builder.Services.AddSingleton<ComponentBus>();
            //languaje
            //builder.Services.AddLanguageContainer(Assembly.GetExecutingAssembly());
            //local storage
            //builder.Services.AddBlazoredLocalStorage();
            
            //authorization
            builder.Services.AddAuthorizationCore();

            //mudblazor
            builder.Services.AddMudServices();

            var app = builder.Build();

            serviceProvider = app.Services;
            Helper.SeedData.SeedAll(app.Services);

            return app;
        }
    }
}

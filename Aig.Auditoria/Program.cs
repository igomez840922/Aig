using Aig.Auditoria.Data;
using Aig.Auditoria.Helper;
using Aig.Auditoria.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using BlazorDownloadFile;
using Blazored.LocalStorage;
using DataAccess;
using DataModel;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Radzen.Blazor;
using System.Collections.Concurrent;
using System.Configuration;
using System.Globalization;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
///
// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();

////For Localstorage
//builder.Services.AddScoped<IProfileService, ProfileService>();
//builder.Services.AddBlazoredLocalStorage();

//For API CONTROLLERS
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//For Components Comunucations Pul-Sub
builder.Services.AddScoped<ComponentBus>();

//Download File
builder.Services.AddBlazorDownloadFile(ServiceLifetime.Scoped);

////Quartz Hosted
//builder.Services.AddQuartz(q =>
//{
//	q.UseMicrosoftDependencyInjectionJobFactory();

//	var schedulerJobKey = new JobKey("SchedulerJob_FiveMin");
//	q.AddJob<SchedulerJob_FiveMin>(opts => opts.WithIdentity(schedulerJobKey));
//	q.AddTrigger(opts => opts
//		.ForJob(schedulerJobKey)
//		.WithIdentity("SchedulerJob_FiveMin-trigger")
//		.WithCronSchedule(builder.Configuration.GetSection("Cron5Min").Value));

//	schedulerJobKey = new JobKey("SchedulerJob_Daily");
//	q.AddJob<SchedulerJob_Daily>(opts => opts.WithIdentity(schedulerJobKey));
//	q.AddTrigger(opts => opts
//		.ForJob(schedulerJobKey)
//		.WithIdentity("SchedulerJob_Daily-trigger")
//		.WithCronSchedule(builder.Configuration.GetSection("CronDialy").Value));
//});
//builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

//Dependency Injection
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IDalService, DalService>(); 
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ISystemUserService, SystemUserService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IInspectionsService, InspectionsService>();
builder.Services.AddScoped<IEstablishmentsService, EstablishmentsService>();
builder.Services.AddScoped<IRetiredProductService, RetiredProductService>();
builder.Services.AddScoped<ICorregimientoService, CorregimientoService>();
builder.Services.AddScoped<IDistrictService, DistrictService>();
builder.Services.AddScoped<IProvicesService, ProvicesService>();
builder.Services.AddScoped<ICountriesService, CountriesService>();
builder.Services.AddScoped<ISmtpCorreoService, SmtpCorreoService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IAttachmentsService, AttachmentsService>();
builder.Services.AddScoped<IPdfGenerationService, PdfGenerationService>();
builder.Services.AddScoped<IProductoEstablecimientoService, ProductoEstablecimientoService>();
builder.Services.AddScoped<IActividadEstablecimientoService, ActividadEstablecimientoService>();
builder.Services.AddScoped<ICorrespondenciaService, CorrespondenciaService>();
builder.Services.AddLanguageContainer(Assembly.GetExecutingAssembly());

////Connection Configurations
//builder.Services.AddServerSideBlazor(options =>
//{
//    options.DetailedErrors = true;
//    options.DisconnectedCircuitMaxRetained = 100;
//    options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(3);
//    options.JSInteropDefaultCallTimeout = TimeSpan.FromMinutes(1);
//    options.MaxBufferedUnacknowledgedRenderBatches = 10;
//})
//    .AddHubOptions(options =>
//    {
//        options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
//        options.EnableDetailedErrors = true;
//        options.HandshakeTimeout = TimeSpan.FromSeconds(10);
//        options.KeepAliveInterval = TimeSpan.FromSeconds(10);
//        options.MaximumParallelInvocationsPerClient = 1;
//        options.MaximumReceiveMessageSize = 32 * 1024;
//        options.StreamBufferCapacity = 10;
//    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<BlazorCookieLoginMiddleware<ApplicationUser>>();
app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseWebSockets();

//Check and Save initial data...
Aig.Auditoria.Helper.SeedData.SeedAll(app.Services);

//cultura en español
CultureInfo.CurrentCulture = new CultureInfo("es");
CultureInfo.CurrentUICulture = new CultureInfo("es");
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es");

app.Run();
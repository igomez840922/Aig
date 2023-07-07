using Aig.FarmacoVigilancia.Helper;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using BlazorDownloadFile;
using Blazored.LocalStorage;
using DataAccess;
using DataModel;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Radzen.Blazor;
using System.Globalization;
using System.Reflection;

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

//File size upload
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.Limits.MaxRequestBodySize = long.MaxValue; // if don't set default value is: 30 MB
});
builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = long.MaxValue;
});
builder.Services.Configure<FormOptions>(options =>
{
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartBodyLengthLimit = long.MaxValue; // if don't set default value is: 128 MB
    options.MultipartHeadersLengthLimit = int.MaxValue;
    options.MultipartBoundaryLengthLimit = int.MaxValue;
    options.MultipartHeadersCountLimit = int.MaxValue;
});
builder.Services.AddSignalR(hubOptions =>
{
    hubOptions.MaximumReceiveMessageSize = 102400000; // 100MB
    hubOptions.StreamBufferCapacity = 20; // 100MB
    //hubOptions.ClientTimeoutInterval = new TimeSpan(0,2,0);
    //hubOptions.HandshakeTimeout = new TimeSpan(0, 1, 0);
    //hubOptions.KeepAliveInterval = new TimeSpan(0, 1, 0);
    hubOptions.EnableDetailedErrors = true;
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; }); ;
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();

//For API CONTROLLERS
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

////For Localstorage
//builder.Services.AddScoped<IProfileService, ProfileService>();
//builder.Services.AddBlazoredLocalStorage();

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
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ISystemUserService, SystemUserService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<ICorregimientoService, CorregimientoService>();
builder.Services.AddScoped<IDistrictService, DistrictService>();
builder.Services.AddScoped<IProvicesService, ProvicesService>();
builder.Services.AddScoped<ICountriesService, CountriesService>();
builder.Services.AddScoped<ISmtpCorreoService, SmtpCorreoService>();
builder.Services.AddScoped<IAttachmentsService, AttachmentsService>();
builder.Services.AddScoped<IPdfGenerationService, PdfGenerationService>();
builder.Services.AddScoped<IWorkerPersonService, WorkerPersonService>();
builder.Services.AddScoped<ILabsService, LabsService>();
builder.Services.AddScoped<IPmrService, PmrService>();
builder.Services.AddScoped<IIpsService, IpsService>();
builder.Services.AddScoped<IRfvService, RfvService>();
builder.Services.AddScoped<IOrigenAlertaService, OrigenAlertaService>();
builder.Services.AddScoped<IAlertaService, AlertaService>();
builder.Services.AddScoped<IDestinyInstituteService, DestinyInstituteService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<IRamService, RamService>();
builder.Services.AddScoped<IRamService2, RamService2>();
builder.Services.AddScoped<IFFService, FFService>();
builder.Services.AddScoped<IFTService, FTService>();
builder.Services.AddScoped<IESAVIService, ESAVIService>();
builder.Services.AddScoped<ITipoInstitucionService, TipoInstitucionService>();
builder.Services.AddScoped<ISocService, SocService>();
builder.Services.AddScoped<IIntensidadEsaviService, IntensidadEsaviService>();
builder.Services.AddScoped<ITipoVacunaService, TipoVacunaService>();
builder.Services.AddScoped<INotaDestinoService, NotaDestinoService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<ITerMedraService, TerMedraService>();
builder.Services.AddScoped<IESAVI2Service, ESAVI2Service>();
builder.Services.AddScoped<IApiConnectionService, ApiConnectionService>();
builder.Services.AddScoped<ITokenMedService, TokenMedService>();
builder.Services.AddScoped<IMedicamentosService, MedicamentosService>();
builder.Services.AddScoped<IApiConnectionFileUploadService, ApiConnectionFileUploadService>();
builder.Services.AddScoped<IFarmacoService, FarmacoService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IImportFileService, ImportFileService>();
builder.Services.AddLanguageContainer(Assembly.GetExecutingAssembly());


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


//Check and Save initial data...
Aig.FarmacoVigilancia.Helper.SeedData.SeedAll(app.Services);

//cultura en español
CultureInfo.CurrentCulture = new CultureInfo("es");
CultureInfo.CurrentUICulture = new CultureInfo("es");
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es");

app.Run();
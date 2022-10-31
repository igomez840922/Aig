using Aig.FarmacoVigilancia.Helper;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using BlazorDownloadFile;
using Blazored.LocalStorage;
using DataAccess.FarmacoVigilancia;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
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
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ISystemUserService, SystemUserService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<ICorregimientoService, CorregimientoService>();
builder.Services.AddScoped<IDistrictService, DistrictService>();
builder.Services.AddScoped<IProvicesService, ProvicesService>();
builder.Services.AddScoped<ICountriesService, CountriesService>();
builder.Services.AddScoped<ISmtpCorreoService, SmtpCorreoService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IAttachmentsService, AttachmentsService>();
builder.Services.AddScoped<IPdfGenerationService, PdfGenerationService>();
builder.Services.AddScoped<IWorkerPersonService, WorkerPersonService>();
builder.Services.AddScoped<ILabsService, LabsService>();
builder.Services.AddScoped<IPmrService, PmrService>();
builder.Services.AddScoped<IIpsService, IpsService>();
builder.Services.AddScoped<IRfvService, RfvService>();
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

//Save initial data...
Aig.FarmacoVigilancia.Helper.SeedData.UpdateMigrations(app.Services).Wait();
Aig.FarmacoVigilancia.Helper.SeedData.SeedRoles(app.Services).Wait();
Aig.FarmacoVigilancia.Helper.SeedData.SeedUsers(app.Services).Wait();
Aig.FarmacoVigilancia.Helper.SeedData.SeedFirstData(app.Services).Wait();

app.Run();
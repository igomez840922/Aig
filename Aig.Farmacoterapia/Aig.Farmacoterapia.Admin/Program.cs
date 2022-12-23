using Aig.Farmacoterapia.Admin.Areas.Identity;
using Aig.Farmacoterapia.Admin.Data;
using Aig.Farmacoterapia.Application.Common.Middleware;
using Aig.Farmacoterapia.Infrastructure;
using Aig.Farmacoterapia.Infrastructure.Identity;
using Aig.Farmacoterapia.Infrastructure.SeedData;
using BlazorComponentBus;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.FileProviders;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

//Injecting services.
builder.Services.RegisterInfrastructureServices(builder.Configuration);
builder.Services.AddMudServices();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
builder.Services.AddSingleton<WeatherForecastService>();

//For api controllers
builder.Services.AddControllers();

//For Components Comunucations Pul-Sub
builder.Services.AddScoped<ComponentBus>();

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
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Files")),
    RequestPath = new PathString("/Files")
});
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<BlazorCookieLoginMiddleware<ApplicationUser>>();
app.MapControllers();
app.ConfigureSwagger();
app.MapBlazorHub();
//app.UseEndpoints(endpoints =>
//    // other settings go here
//    endpoints.MapBlazorHub(options => {
//        options.WebSockets.CloseTimeout = new TimeSpan(1, 1, 1);
//        options.LongPolling.PollTimeout = new TimeSpan(1, 0, 0);
//    })
//);
app.MapFallbackToPage("/_Host");

//Save initial data...
//SeedData.UpdateMigrations(app.Services).Wait();
//SeedData.SeedRoles(app.Services).Wait();
//SeedData.SeedUsers(app.Services).Wait();

app.Run();
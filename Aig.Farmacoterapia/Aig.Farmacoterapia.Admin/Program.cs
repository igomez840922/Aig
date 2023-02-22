using Aig.Farmacoterapia.Admin.Areas.Identity;
using Aig.Farmacoterapia.Admin.Data;
using Aig.Farmacoterapia.Application.Common.Middleware;
using Aig.Farmacoterapia.Application.Features.Extensions;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Infrastructure;
using Aig.Farmacoterapia.Infrastructure.Identity;
using Aig.Farmacoterapia.Infrastructure.SeedData;
using BlazorComponentBus;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.FileProviders;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

//Injecting services.
builder.Services.RegisterInfrastructureServices(builder.Configuration);
builder.Services.AddMudServices();
builder.Services.AddApplicationLayer();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor().AddCircuitOptions(option => { option.DetailedErrors = true; });
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
builder.Services.AddSingleton<WeatherForecastService>();
//For api controllers
builder.Services.AddControllers();

//For Components Comunucations Pul-Sub
builder.Services.AddScoped<ComponentBus>();
//File Size
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
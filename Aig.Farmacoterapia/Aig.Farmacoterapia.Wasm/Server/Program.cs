using Aig.Farmacoterapia.Application.Features.Extensions;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Infrastructure;
using Aig.Farmacoterapia.Wasm.Server.Helpers;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

var context = new CustomAssemblyLoadContext();
context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "DinkToPdf.v0.12.4", "64bit", "libwkhtmltox.dll"));

// Add services to the container.
builder.Services.AddSharedInfrastructure(builder.Configuration);
builder.Services.AddInfrastructureMappings();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddIdentity();
builder.Services.AddUserService();
builder.Services.AddInfrastructure();
builder.Services.AddRepositories();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.RegisterSwagger();
builder.Services.AddApplicationLayer();
builder.Services.AddQuartz();
// Add services to the container.

//builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddRazorPages();

builder.Services.AddSwaggerGen();


//For API CONTROLLERS
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsPolicy", opt => opt
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithExposedHeaders("X-Pagination"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseSwagger();
//app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Files")),
    RequestPath = new PathString("/Files")
});

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.ConfigureSwagger();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

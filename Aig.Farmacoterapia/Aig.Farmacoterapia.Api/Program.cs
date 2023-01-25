
using Aig.Farmacoterapia.Application.Features.Extensions;
using Aig.Farmacoterapia.Infrastructure;
using Microsoft.Extensions.FileProviders;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSharedInfrastructure(builder.Configuration);
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddIdentity();
builder.Services.AddUserService();
builder.Services.AddInfrastructure();
builder.Services.AddRepositories();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.RegisterSwagger();
builder.Services.AddApplicationLayer();

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsPolicy", opt => opt
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithExposedHeaders("X-Pagination"));
});

//builder.Services.AddControllers();
builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//For api Controllers
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
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(options =>
//    {
//        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Aig Farmacoterapia API V1");
//        options.RoutePrefix = "swagger";
//        options.DisplayRequestDuration();
//    });
//}
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors("CorsPolicy");

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Files")),
    RequestPath = new PathString("/Files")
});

app.Run();

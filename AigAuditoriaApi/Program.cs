using AigAuditoriaApi.Helper;
using AigAuditoriaApi.Services;
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
////if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();



//////////////////////
///////////////////////
////////////////////
// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


//builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
//{
//    options.SignIn.RequireConfirmedAccount = false;
//    options.SignIn.RequireConfirmedEmail = false;
//    options.SignIn.RequireConfirmedPhoneNumber = false;
//})
//    .AddRoles<IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>();

//builder.Services.Configure<IdentityOptions>(options =>
//{
//    // Password settings
//    options.Password.RequireDigit = false;
//    options.Password.RequiredLength = 3;
//    options.Password.RequireNonAlphanumeric = false;
//    options.Password.RequireUppercase = false;
//    options.Password.RequireLowercase = false;
//});


builder.Services.AddControllers();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    //options es para dejar pasar los forms sin validar
    options.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//#if DEBUG
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "AUDITORIA SERVICES API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
    option.SchemaFilter<MySwaggerSchemaFilter>();
});
//#endif
//For API CONTROLLERS
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsPolicy", opt => opt
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithExposedHeaders("X-Pagination"));
});
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false, //you might want to validate the audience and issuer depending on your use case
        ValidateAudience = false,
        ValidateLifetime = true, //here we are saying that we don't care about the token's expiration date
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
        //ValidAudience = jwtSettings.GetSection("validAudience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("securityKey").Value))
    };
});

//Automapper Configurations
//var mapperConfig = new MapperConfiguration(mc =>
//{
//    mc.AddProfile(new MappingProfile());
//});
//IMapper mapper = mapperConfig.CreateMapper();
//builder.Services.AddSingleton(mapper);

//Dependency Injection
//builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IDalService, DalService>();
//builder.Services.AddScoped<IAuthService, AuthService>();
//builder.Services.AddScoped<ISystemUserService, SystemUserService>();
builder.Services.AddScoped<IPdfGenerationService, PdfGenerationService>();
builder.Services.AddScoped<IInspectionsService, InspectionsService>();


//builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages();

// Register the custom authorization attribute
//builder.Services.AddScoped<CustomAuthorizationAttribute>();

//SignalR for Chat
//builder.Services.AddSignalR();

var app = builder.Build();

app.UsePathBase("/auditoriaservices");

//#if DEBUG
app.UseSwagger();
app.UseSwaggerUI();
//#endif

app.UseHttpsRedirection();
//app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

//app.MapRazorPages();
app.MapControllers();
//app.MapFallbackToFile("index.html");
//for signalR Chat
//app.MapHub<SignalRHub>("/signalRHub");

//Generate initial data...
//APAServices.Helper.SeedData.SeedAll(app.Services);

app.Run();
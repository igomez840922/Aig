using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Infrastructure.Files;
using Aig.Farmacoterapia.Infrastructure.Identity;
using Aig.Farmacoterapia.Infrastructure.Logging;
using Aig.Farmacoterapia.Infrastructure.Persistence;
using Aig.Farmacoterapia.Infrastructure.Persistence.Repositories;
using Aig.Farmacoterapia.Infrastructure.Services;
using log4net.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Aig.Farmacoterapia.Infrastructure
{
    public static class ConfigureServices
    {
        private static IServiceCollection AddCurrentUserService(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddTransient<ITokenService, IdentityService>();
            return services;
        }
        private static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            });
            return services;
        }
        internal static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication().AddJwtBearer("JwtClient", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters(){
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("S0M3RAN0MS3CR3T!1!MAG1C!1!")),
                    ValidAudience = "AudienceClientJwt",
                    ValidIssuer = "IssuerClientJwt",
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
            return services;
        }
        internal static void RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "Aig Farmacoterapia  API", Version = "v1" });
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new()
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new()
                {
                    { securityScheme, Array.Empty<string>() }
                });

            });
        }
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Aig Farmacoterapia API V1");
                options.RoutePrefix = "swagger";
                options.DisplayRequestDuration();
            });
        }
        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var conn = configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<ApplicationDbContext>(options =>
            //{
            //    options.UseSqlServer(conn, sqlServerOptionsAction:
            //        sqlOptions =>
            //        {
            //            sqlOptions.EnableRetryOnFailure();
            //            sqlOptions.CommandTimeout(120);
            //            //sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
            //        });
            //});

            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseMySql(conn, ServerVersion.AutoDetect(conn), mySqlOptionsAction:
                    sqlOptions => {
                        options.EnableDetailedErrors();
                        sqlOptions.EnableRetryOnFailure();
                        sqlOptions.CommandTimeout(120);
                    });
            });

            return services;
        }
        private static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
            services.AddSingleton<ISystemLogger, SystemLogger>();

            return services;
        }
        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>))
                .AddTransient<IMedicamentRepository, MedicamentRepository>()
                .AddTransient<IContryRepository, ContryRepository>()
                .AddTransient<IPharmaceuticalRepository, PharmaceuticalRepository>()
                .AddTransient<IMedicationRouteRepository, MedicationRouteRepository>()
                .AddTransient<IUnitOfWork, UnitOfWork>();
        }
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Log4net
            XmlConfigurator.Configure(new FileInfo("log4net.config"));

            AddDatabase(services, configuration);
            AddIdentity(services);
            AddCurrentUserService(services);
            AddInfrastructure(services);
            AddRepositories(services);
            AddJwtAuthentication(services);
            RegisterSwagger(services);

            return services;
        }
    }
}

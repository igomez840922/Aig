using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Infrastructure.Configurations;
using Aig.Farmacoterapia.Infrastructure.Files;
using Aig.Farmacoterapia.Infrastructure.Identity;
using Aig.Farmacoterapia.Infrastructure.Logging;
using Aig.Farmacoterapia.Infrastructure.Persistence;
using Aig.Farmacoterapia.Infrastructure.Persistence.BlazorHero.CleanArchitecture.Infrastructure.Repositories;
using Aig.Farmacoterapia.Infrastructure.Persistence.Repositories;
using Aig.Farmacoterapia.Infrastructure.Services;
using log4net.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Aig.Farmacoterapia.Infrastructure
{
    public static class ConfigureServices
    {
        internal static AppConfiguration GetApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettingsConfiguration = configuration.GetSection(nameof(AppConfiguration));
            services.Configure<AppConfiguration>(applicationSettingsConfiguration);
            return applicationSettingsConfiguration.Get<AppConfiguration>();
        }
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
        internal static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            AppConfiguration config = services.GetApplicationSettings(configuration);
            var key = Encoding.UTF8.GetBytes(config.Secret);
            services
                .AddAuthentication(authentication =>
                {
                    authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(async bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RoleClaimType = ClaimTypes.Role,
                        ClockSkew = TimeSpan.Zero
                    };
                    bearer.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];

                            // If the request is for our hub...
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken))
                            {
                                // Read the token out of the query string
                                context.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = c =>
                        {
                            if (c.Exception is SecurityTokenExpiredException)
                            {
                                c.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                                c.Response.ContentType = "application/json";
                                var result = JsonConvert.SerializeObject(Result.Fail("The Token is expired."));
                                return c.Response.WriteAsync(result);
                            }
                            else
                            {
#if DEBUG
                                c.NoResult();
                                c.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                c.Response.ContentType = "text/plain";
                                return c.Response.WriteAsync(c.Exception.ToString());
#else
                                c.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                c.Response.ContentType = "application/json";
                                var result = JsonConvert.SerializeObject(Result.Fail(localizer["An unhandled error has occurred."]));
                                return c.Response.WriteAsync(result);
#endif
                            }
                        },
                        OnChallenge = context =>
                        {
                            context.HandleResponse();
                            if (!context.Response.HasStarted)
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                                context.Response.ContentType = "application/json";
                                var result = JsonConvert.SerializeObject(Result.Fail("You are not Authorized."));
                                return context.Response.WriteAsync(result);
                            }

                            return Task.CompletedTask;
                        },
                        OnForbidden = context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                            context.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject(Result.Fail("You are not authorized to access this resource."));
                            return context.Response.WriteAsync(result);
                        },
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
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(conn, ServerVersion.AutoDetect(conn), mySqlOptionsAction:
                    sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure();
                        sqlOptions.CommandTimeout(120);
                    });
            });
            //services.AddDbContext<ApplicationDbContext>(options =>
            //{
            //    options.UseMySql(conn, ServerVersion.AutoDetect(conn));
            //});
            //services.AddDbContext<ApplicationDbContext>(options =>
            //{
            //    options.UseMySql("server=localhost;database=new_schema;user=root;password=Adm123+-*", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            //});
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
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Configure Log4net.
            XmlConfigurator.Configure(new FileInfo("log4net.config"));

            AddDatabase(services, configuration);
            AddIdentity(services);
            AddCurrentUserService(services);
            AddInfrastructure(services);
            AddRepositories(services);
            AddJwtAuthentication(services);
            RegisterSwagger(services);

            //services.AddScoped<ApplicationDbContextInitialiser>();
            return services;
        }
    }
}

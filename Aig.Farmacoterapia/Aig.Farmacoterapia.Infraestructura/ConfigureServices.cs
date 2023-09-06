﻿using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Interfaces.Studies;
using Aig.Farmacoterapia.Infrastructure.Application;
using Aig.Farmacoterapia.Infrastructure.Configuration;
using Aig.Farmacoterapia.Infrastructure.Files;
using Aig.Farmacoterapia.Infrastructure.Identity;
using Aig.Farmacoterapia.Infrastructure.Interfaces;
using Aig.Farmacoterapia.Infrastructure.Logging;
using Aig.Farmacoterapia.Infrastructure.Persistence;
using Aig.Farmacoterapia.Infrastructure.Persistence.Repositories;
using Aig.Farmacoterapia.Infrastructure.Persistence.Repositories.Studies;
using Aig.Farmacoterapia.Infrastructure.Services;
using Aig.Farmacoterapia.Infrastructure.Helpers;
using log4net.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using DinkToPdf.Contracts;
using DinkToPdf;
using Quartz;
using Aig.Farmacoterapia.Infrastructure.Jobs;
using Aig.Farmacoterapia.Domain.Interfaces.Integration;
using Aig.Farmacoterapia.Infrastructure.Services.Integration;
using Aig.Farmacoterapia.Infrastructure.Resiliency;
using Aig.Farmacoterapia.Infrastructure.Helpers.ApiClient;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Infrastructure.Services.Integration.SysFarm;
using Aig.Farmacoterapia.Infrastructure.Services.Integration.SirFad;

namespace Aig.Farmacoterapia.Infrastructure
{
    public static class ConfigureServices
    {
        public static AppConfiguration GetApplicationSettings(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var applicationSettingsConfiguration = configuration.GetSection(nameof(AppConfiguration));
            services.Configure<AppConfiguration>(applicationSettingsConfiguration);
            return applicationSettingsConfiguration.Get<AppConfiguration>();
        }
        public static IServiceCollection AddUserService(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<ITokenService, IdentityService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory>();

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
        //public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var appConfig = services.GetApplicationSettings(configuration);
        //    services.AddAuthentication().AddJwtBearer("JwtClient", options =>
        //    {
        //        options.TokenValidationParameters = new TokenValidationParameters(){
        //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appConfig.Secret)),
        //            ValidAudience = appConfig.Audience,
        //            ValidIssuer = appConfig.Issuer,
        //            ValidateIssuerSigningKey = true,
        //            ValidateLifetime = true,
        //            ValidateIssuer = true,
        //            ValidateAudience = true,
        //            ClockSkew = TimeSpan.Zero
        //        };
        //    });
        //    return services;
        //}
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var key = Encoding.UTF8.GetBytes(services.GetApplicationSettings(configuration).Secret);
            services.AddAuthentication(authentication =>
                {
                    //authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    //authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
               .AddJwtBearer("JwtClient", options =>
               {
                   options.RequireHttpsMetadata = false;
                   options.SaveToken = true;
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(key),
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       RoleClaimType = ClaimTypes.Role,
                       ClockSkew = TimeSpan.Zero
                   };
                   options.Events = new JwtBearerEvents
                   {
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
                                    var result = JsonConvert.SerializeObject(Result.Fail("An unhandled error has occurred."));
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

        public static void RegisterSwagger(this IServiceCollection services)
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
                c.DocumentFilter<SwaggerOrderingFilter>();
                c.SchemaFilter<SwaggerIgnoreFilter>();
                c.CustomSchemaIds(type => type.ToString());
            });
        }
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Aig Farmacoterapia API V1");
                options.RoutePrefix = "api";
                options.DisplayRequestDuration();
            });
        }
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var conn = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(conn, sqlServerOptionsAction:
                    sqlOptions =>
                    {
                        //options.EnableDetailedErrors();
                        sqlOptions.CommandTimeout(120);
                        sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromMilliseconds(500), null);
                    });
            });

            //services.AddDbContext<ApplicationDbContext>(options =>
            //{
            //    options.UseMySql(conn, ServerVersion.AutoDetect(conn), mySqlOptionsAction:
            //        sqlOptions =>
            //        {
            //            options.EnableDetailedErrors();
            //            sqlOptions.EnableRetryOnFailure();
            //            sqlOptions.CommandTimeout(180);
            //        });
            //});

            return services;
        }
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
            services.AddSingleton<ISystemLogger, SystemLogger>();

            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>))
                .AddScoped<IMedicamentRepository, MedicamentRepository>()
                .AddScoped<IContryRepository, ContryRepository>()
                .AddScoped<IPharmaceuticalRepository, PharmaceuticalRepository>()
                .AddScoped<IMedicationRouteRepository, MedicationRouteRepository>()
                .AddScoped<IMakerRepository, MakerRepository>()
                .AddScoped<IAigEstudioDNFDRepository,AigEstudioDNFDRepository>()
                .AddScoped<IAigEstudioRepository, AigEstudioRepository>()
                .AddScoped<IAigCodigoEstudioRepository, AigCodigoEstudioRepository>()
                .AddScoped<IAigRecordRepository, AigRecordRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IUploadService, UploadService>()
                .AddScoped<IReportService, ReportService>();
        }
        public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Log4net
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
            services.AddScoped<AppState>();
            services.Configure<AppConfiguration>(configuration.GetSection("AppConfiguration"));
            services.Configure<MailConfiguration>(configuration.GetSection("MailConfiguration"));
            services.Configure<TramitesConfiguration>(configuration.GetSection("TramitesConfiguration"));
            services.AddTransient<IMailService, SMTPMailService>();
            services.AddTransient<ISqlRetryPolicy, SqlRetryPolicy>();
            services.AddTransient<IRestApiClient, RestApiClient>();
            services.AddTransient<ISysFarmService, SysFarmService>();
            services.AddTransient<ISirFadServices, SirFadServices>();
            services.AddTransient<ITramitesServices, TramitesServices>();
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            return services;
        }
        public static void AddInfrastructureMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
        public static IServiceCollection AddHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            var apiUrl = services.GetApplicationSettings(configuration).BaseUrl;
            services.AddScoped<HttpClient>(s => {
                var client = new HttpClient { BaseAddress = new Uri(apiUrl)};
                client.DefaultRequestHeaders.AcceptLanguage.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.ParseAdd(CultureInfo.DefaultThreadCurrentCulture?.TwoLetterISOLanguageName);
                return client;
            });
            return services;
        }
        public static void AddJob<T>(this IServiceCollectionQuartzConfigurator configurator, string key, int interval, string cron="") where T : IJob
        {
            var jobKey = new JobKey($"{Guid.NewGuid().GetHashCode():x}-{key}");
            configurator.AddJob<T>(opts => opts.WithIdentity(jobKey));
            configurator.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity($"{jobKey}-trigger")
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(interval)
                    .RepeatForever())
                //.WithCronSchedule(cron)
            );
        }

        public static IServiceCollection AddQuartz(this IServiceCollection services, IConfiguration configuration)
        {
            var interval = services.GetApplicationSettings(configuration).UpdateTime;
            var scopeFactory = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>();
            //using (var scope = scopeFactory.CreateScope())
            //{
            //    var unitOfWork = scope.ServiceProvider.GetService<IUnitOfWork>();
            //    try{
            //        AigService? item;
            //        if ((item = unitOfWork?.Repository<AigService>().Entities.AsNoTracking().FirstOrDefault(p => p.Code == "SYSFARM")) != null) {
            //            item.UpdateTime = interval;
            //            unitOfWork.Repository<AigService>().UpdateDeep(item);
            //        }
            //        if ((item = unitOfWork?.Repository<AigService>().Entities.AsNoTracking().FirstOrDefault(p => p.Code == "SIRFAD")) != null)
            //        {
            //            item.UpdateTime = interval;
            //            unitOfWork.Repository<AigService>().UpdateDeep(item);
            //        }
            //        var commit = unitOfWork.Commit();
            //    }
            //    catch {;}
            //}
            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();
                q.AddJob<RecordUpdateJob>("RecordUpdateJob", interval);
                //q.AddJob<SysFarmUpdateJob>("SysFarmUpdateJob", interval);
                //q.AddJob<SirFadUpdateJob>("SirFadUpdateJob", interval);
                //q.AddJob<RecordUpdateJob>("RecordUpdateJob", "0/5 * * * * ?"); // run every 5 seconds
            });
            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
            return services;
        }
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            AddSharedInfrastructure(services, configuration);
            AddDatabase(services, configuration);
            AddIdentity(services);
            AddUserService(services);
            AddInfrastructure(services);
            AddRepositories(services);
            AddJwtAuthentication(services, configuration);
            RegisterSwagger(services);
            AddInfrastructureMappings(services);
            AddHttpClient(services, configuration);
            AddQuartz(services, configuration);
            return services;
        }
    }
}

using LZ.BusinessLayer.efdemo;
using LZ.BusinessLayer.efdemo.Authorization;
using LZ.Common.Extensions;
using LZ.Common.Infrastructure;
using LZ.Common.Logging;
using LZ.Common.Logging.Serilog;
//using LZ.Common.ApiClient;
//using LZ.Common.Infrastructure;
using LZ.DataLayer.efdemo.Context;
using LZ.DataLayer.efdemo.Repository;
using LZ.Mappers.efdemo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace efdemoService
{
    /// <summary>
    ///     Startup
    /// </summary>
    public class Startup
    {
        const string ConnectionstringKey = "Data:DefaultConnection:ConnectionString";
        const string LogQueryKey = "EntityFramework:Logging:logQueryEnabled";

        public IConfiguration Configuration { get; }
        private ILoggingService LoggingService { get; set; }
        private IServiceCollection Services { get; set; }

        public Startup(IHostingEnvironment env)
        {
            ThrowIfEnvNameOutOfApprovedList(env);
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", false)//TODO: Allow to be optional after debug
                .AddEnvironmentVariables();//local environment can override anything set in deployed configuration files
            Configuration = builder.Build();
        }

        // If application argument --environment is not passed or is the default value, service cannot start since it depends on appsettings.ENV.json
        private void ThrowIfEnvNameOutOfApprovedList(IHostingEnvironment env)
        {
            if (env.EnvironmentName == EnvironmentName.Production
                | env.EnvironmentName == EnvironmentName.Development
                | env.EnvironmentName == EnvironmentName.Staging
                )
            {
                var errorMessage = string.Format("The env value of {0} is not in the LZ standardized env set [predev, dev, qa, stg, prod]. Please" +
                    " change the value that is passed as one of those specified in set i.e. 'prod' or 'predev' ", env.EnvironmentName);
                throw new Exception(errorMessage);
            }
        }

        /// <summary>
        ///     This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            Services = services;
            //services.DisableAutoModelStateValidation();

            //services.AddApiClient();

            services.AddMvcCore().AddVersionedApiExplorer(
               options =>
               {
                   options.GroupNameFormat = "'v'VVV";
               });

            services.AddMvc(options =>
                {
                    options.OutputFormatters.Clear();
                    options.OutputFormatters.Add(new JsonOutputFormatter(
                        new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver(),
                            DateFormatHandling = DateFormatHandling.IsoDateFormat,
                            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                            Converters = new List<JsonConverter> { new StringEnumConverter() }
                        },
                        ArrayPool<char>.Shared));
                }) // Add Controllers
                .AddApplicationPart(Assembly.Load(new AssemblyName("LZ.Controllers.efdemo")));

            services.AddApiVersioning(o =>
            {
                o.ApiVersionReader = new HeaderApiVersionReader("x-lz-api-version");
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
            });

            // Initializes Swagger for the Documentation
            services.AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                }
                options.OperationFilter<SwaggerDefaultValues>();
                options.IncludeXmlComments(XmlCommentsFilePath);
                options.DescribeAllEnumsAsStrings();
                options.DescribeStringEnumsInCamelCase();

            });

            services.AddEntityFrameworkSqlServer();
            //services.AddDbContextPool<efdemoContext>((options) =>
            //{
            //    bool.TryParse(Configuration[ConnectionstringKey],
            //    out bool isEnabled);
            //    if (isEnabled)
            //    {

            //        options.UseLoggerFactory(DbLoggerFactory);

            //    }

            //    options.UseSqlServer(Configuration[LogQueryKey]);
            //});
            services.AddDistributedMemoryCache();

            // Add Application Insights
            //services.AddApplicationInsightsTelemetry(Configuration);

            // add automapper 
            services.AddSingleton(new efdemoMapper().Mapper);

            // Add Monitoring
            //services.AddSingleton<RequestTracker>();

            // add instances - lifetime of the service
            services.AddSingleton(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(factory => LoggingService = new SerilogLoggingService(Configuration));

            services.AddScoped<IAuthorizationHandler, CustomerAuthorizationHandler>();
            //services.AddScoped<IApiClient, ApiClient>();

            //TODO:  add instances.
            services.AddScoped<IefdemoContext, efdemoContextSql>();
            services.AddScoped<IefdemoRepository, efdemoRepository>();
            services.AddScoped<IefdemoManager, efdemoManager>();
        }

        /// <summary>
        ///     This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApiVersionDescriptionProvider provider)
        {
            // Add Monitoring
            //app.UseHealthCheckHandler();

            // Add the Swagger UI
            app.UseSwagger();

            //Changing swagger endpoint for Confluence Documentation backwards compatibility
            app.UseSwaggerUI(options =>
            {
                // build a swagger endpoint for each discovered API version
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    options.RoutePrefix = "swagger/ui";
                }
            });

            app.UseLoggingHandler();
            app.UseAuthorizationHandler();

            if (env.IsDevelopment())
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
            }
            //Add Exception Handling
            app.UseExceptionHandlingMiddlewareHandler();
            app.UseMvc();
        }

        static string XmlCommentsFilePath
        {
            get
            {
                var app = PlatformServices.Default.Application;
                return Path.Combine(app.ApplicationBasePath, "LZ.Controllers.efdemo.xml");
            }
        }

        static Info CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new Info()
            {
                Title = $"efdemo Service API {description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
                Description = "This API provides endpoints for the efdemo Domain.",
                Contact = new Contact() { Name = "Shailendra", Email = "test@test.com" },
                TermsOfService = "None"
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }

        private void ConfigureMappers()
        {
            // TODO: Dto <=> Domain
            // TODO: Entity <=> Domain
        }
    }
}

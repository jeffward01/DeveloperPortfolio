using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;
using Port.Data.Providers;
using Port.Models.Settings;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySQL.Data.Entity.Extensions;
using Port.Business.Managers;
using Port.Data.Infrastructure;

namespace Port.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            //Add Application settings
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<DatabaseSettings>(Configuration.GetSection("DatabaseSettings"));

            services.AddSingleton(Configuration);

            //services.AddDbContext<PortfolioContext>(opt => opt.());

            //Configure DB
            SetUpDb(services);
            // Add service and create Policy with options
            ConfigureCors(services);

            // Add framework services. for Entity
            //services.AddEntityFramework()
            //    .AddSqlServer()
            //    .AddDbContext<ApplicationDbContext>(options =>
            //        options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();


            services.AddMvc();
           // services.Add(new ServiceDescriptor(typeof(PortfolioContext), new PortfolioContext(new DbContextOptions<PortfolioContext>(),Configuration.GetConnectionString("PortfolioContext"))));

            //needed for NLog.Web
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();





            //Autofac
            // Add application services.
            //services.AddTransient<IEmailSender, AuthMessageSender>();
            //services.AddTransient<ISmsSender, AuthMessageSender>();
            var builder = new ContainerBuilder();
            //builder.RegisterModule<DataModule>();
            //builder.RegisterType<SeedDataService>().As<ISeedDataService>();
            // builder.RegisterType<TestManager>().As<ITestManager>();
            builder.RegisterType<GithubProvider>().As<IGithubProvider>();
            builder.RegisterType<HttpProvider>().As<IHttpProvider>();
            builder.RegisterType<GithubManager>().As<IGithubManager>();
            builder.Populate(services);

            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //add NLog to .NET Core
            loggerFactory.AddNLog();

            //add NLog.Web for .NET Core
            app.AddNLogWeb();

            // global policy - assign here or on each controller
            app.UseCors("CorsPolicy");

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            // loggerFactory.AddProvider();

            //needed for non-NETSTANDARD platforms: configure nlog.config in your project root. NB: you need NLog.Web.AspNetCore package for this.
            env.ConfigureNLog("NLog.config");
            
            //Use MVC
            app.UseMvc();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();
        }


        private void SetUpDb(IServiceCollection services)
        {
            var sqlConnectionString = Configuration.GetConnectionString("PortfolioContext");

            services.AddDbContext<PortfolioContext>(options =>
                options.UseMySQL(
                    sqlConnectionString,
                    b => b.MigrationsAssembly("AspNet5MultipleProject")
                )
            );
        }

        private void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    corsBuilder => corsBuilder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
        }


    }
}
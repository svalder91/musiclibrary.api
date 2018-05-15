using System;
using Demo.MusicLibrary.Api.Core.Infrastructure.Middlewares;
using Demo.MusicLibrary.Api.DataAccess.Extensions;
using Demo.MusicLibrary.Api.Hosting.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;

namespace Demo.MusicLibrary.Api.Hosting
{
    public class Startup
    {
        // ReSharper disable once UnusedMember.Global
        public Startup(IHostingEnvironment environment) { Configuration = CreateConfiguration(environment); }

        public IConfigurationRoot Configuration { get; set; }

        private static IConfigurationRoot CreateConfiguration(IHostingEnvironment environment)
        {
            environment.ConfigureNLog("nlog.config");
            return new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        // ReSharper disable once UnusedMember.Global
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDatabase(Configuration.GetConnectionString("Default"));
            services.AddAutofac(Configuration, out var provider);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return provider;
        }

        // ReSharper disable once UnusedMember.Global
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            loggerFactory.AddNLog();
            app.UseMiddleware<CorrelationIdMiddleware>();
            app.UseMvc();
        }
    }
}

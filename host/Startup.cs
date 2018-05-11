using System;
using Demo.MusicLibrary.Api.Host.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.MusicLibrary.Api.Host
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment) { Configuration = CreateConfiguration(environment); }

        public IConfigurationRoot Configuration { get; set; }

        private static IConfigurationRoot CreateConfiguration(IHostingEnvironment environment)
        {
            return new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.RegisterAutofac(out var provider);
            return provider;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app.UseMvc();
        }
    }
}

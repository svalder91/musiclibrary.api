using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Demo.MusicLibrary.Api.Host.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.MusicLibrary.Api.Host
{
    public class Startup
    {

        public Startup(IHostingEnvironment environment)
        {
            Configuration = CreateConfiguration(environment);
        }

        public IContainer Container { get; set; }
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
            Container = services.RegisterAutofac();
            return new AutofacServiceProvider(Container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app.UseMvc();
        }
    }
}

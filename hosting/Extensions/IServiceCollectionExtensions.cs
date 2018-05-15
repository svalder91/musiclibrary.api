using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.MusicLibrary.Api.Hosting.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddAutofac(this IServiceCollection services,
            IConfigurationRoot configuration, out AutofacServiceProvider provider)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new DataAccess.Autofac.MainModule());
            builder.RegisterModule(new BusinessLogic.Autofac.MainModule());
            builder.RegisterModule(new Core.Autofac.MainModule());
            builder.Register(context => configuration).As<IConfigurationRoot>();
            builder.Populate(services);
            provider = new AutofacServiceProvider(builder.Build());
        }
    }
}

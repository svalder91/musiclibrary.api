using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.MusicLibrary.Api.Host.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddAutofac(this IServiceCollection services, out AutofacServiceProvider provider)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new DataAccess.Autofac.MainModule());
            builder.RegisterModule(new BusinessLogic.Autofac.MainModule());
            builder.RegisterModule(new Core.Autofac.MainModule());
            builder.Populate(services);
            provider = new AutofacServiceProvider(builder.Build());
        }
    }
}

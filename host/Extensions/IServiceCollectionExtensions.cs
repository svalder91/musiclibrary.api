using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.MusicLibrary.Api.Host.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IContainer RegisterAutofac(this IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new DataAccess.Autofac.MainModule());
            builder.RegisterModule(new BusinessLogic.Autofac.MainModule());
            builder.RegisterModule(new Core.Autofac.MainModule());
            builder.Populate(services);
            return builder.Build();
        }
    }
}

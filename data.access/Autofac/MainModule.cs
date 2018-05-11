using Autofac;
using Demo.MusicLibrary.Api.Contracts.Services;

namespace Demo.MusicLibrary.Api.DataAccess.Autofac
{
    public class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ArtistHandler>().As<IArtistHandler>();
            base.Load(builder);
        }
    }
}

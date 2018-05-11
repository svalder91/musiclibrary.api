using Autofac;
using Demo.MusicLibrary.Api.Contracts.Services;

namespace Demo.MusicLibrary.Api.Core.Autofac
{
    public class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UrlTemplateReader>().As<IUrlTemplateReader>();
            base.Load(builder);
        }
    }
}

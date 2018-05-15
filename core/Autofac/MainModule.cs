using Autofac;
using Demo.MusicLibrary.Api.Contracts.Services;
using Microsoft.AspNetCore.Http;

namespace Demo.MusicLibrary.Api.Core.Autofac
{
    public class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UrlTemplateReader>().As<IUrlTemplateReader>();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            base.Load(builder);
        }
    }
}

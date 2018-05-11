using Autofac;
using AutoMapper;
using Demo.MusicLibrary.Api.Contracts.Models;
using Demo.MusicLibrary.Api.Contracts.Services;
using Demo.MusicLibrary.Api.DataAccess.Database.Handler;
using Demo.MusicLibrary.Api.DataAccess.Database.Models;
using Demo.MusicLibrary.Api.DataAccess.Database.Services;

namespace Demo.MusicLibrary.Api.DataAccess.Autofac
{
    public class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ArtistHandler>().As<IArtistHandler>();
            builder.RegisterType<DbArtistHandler>().As<IDbArtistHandler>();
            RegisterAutoMapper(builder);
            base.Load(builder);
        }

        private static void RegisterAutoMapper(ContainerBuilder builder)
        {
            var cfg = new MapperConfiguration(_ => _.CreateMap<Artist, DbArtist>().ReverseMap()).CreateMapper();
            builder.Register(context => cfg).As<IMapper>();
        }
    }
}

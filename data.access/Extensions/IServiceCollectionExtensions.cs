using System.Data.Common;
using Demo.MusicLibrary.Api.DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.MusicLibrary.Api.DataAccess.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddEntityFramework(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MusicLibraryContext>(options => options.UseSqlServer(connectionString));
        }
    }
}

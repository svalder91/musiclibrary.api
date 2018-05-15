using Demo.MusicLibrary.Api.DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.MusicLibrary.Api.DataAccess.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddDatabase(this IServiceCollection services, string connectionString)
        {
            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<MusicLibraryContext>(_ => _
                    .UseSqlServer(connectionString));
        }
    }
}

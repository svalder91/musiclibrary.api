using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Demo.MusicLibrary.Api.DataAccess.Database.Models;
using Demo.MusicLibrary.Api.DataAccess.Database.Services;
using Microsoft.EntityFrameworkCore;

namespace Demo.MusicLibrary.Api.DataAccess.Database.Handler
{
    internal class DbEntityHandler<T> : IDbEntityHandler<T> where T : DbBaseEntity
    {
        public async Task<T> CreateAsync(T entity, MusicLibraryContext context = null)
        {
            using (var provider = new DataProvider(context))
            {
                await provider.Context.Set<T>().AddAsync(entity, CancellationToken.None).ConfigureAwait(false);
                await provider.Context.SaveChangesAsync().ConfigureAwait(false);
                return entity;
            }
        }

        public async Task<IEnumerable<T>> ReadAsync(MusicLibraryContext context = null)
        {
            using (var provider = new DataProvider(context))
            {
                return await provider.Context.Set<T>().ToListAsync().ConfigureAwait(false);
            }
        }

        public async Task<T> ReadAsync(string id, MusicLibraryContext context = null)
        {
            using (var provider = new DataProvider(context))
            {
                return await provider.Context.Set<T>().FirstOrDefaultAsync(_ => _.Id == id).ConfigureAwait(false);
            }
        }

        public async Task<T> UpdateAsync(T entity, MusicLibraryContext context = null)
        {
            using (var provider = new DataProvider(context))
            {
                provider.Context.Set<T>().Update(entity);
                await provider.Context.SaveChangesAsync().ConfigureAwait(false);
                return entity;
            }
        }

        public async Task<T> DeleteAsync(T entity, MusicLibraryContext context = null)
        {
            using (var provider = new DataProvider(context))
            {
                provider.Context.Set<T>().Remove(entity);
                await provider.Context.SaveChangesAsync().ConfigureAwait(false);
                return entity;
            }
        }
    }
}

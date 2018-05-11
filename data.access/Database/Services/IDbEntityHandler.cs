using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.MusicLibrary.Api.DataAccess.Database.Models;

namespace Demo.MusicLibrary.Api.DataAccess.Database.Services
{
    internal interface IDbEntityHandler<T> where T : DbBaseEntity
    {
        Task<T> CreateAsync(T entity,MusicLibraryContext context = null);
        Task<IEnumerable<T>> ReadAsync( MusicLibraryContext context = null);
        Task<T> ReadAsync(string id, MusicLibraryContext context = null);
        Task<T> UpdateAsync(T entity, MusicLibraryContext context = null);
        Task<T> DeleteAsync(T entity, MusicLibraryContext context = null);
    }
}

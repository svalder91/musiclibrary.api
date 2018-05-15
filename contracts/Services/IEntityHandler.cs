using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.MusicLibrary.Api.Contracts.Models;

namespace Demo.MusicLibrary.Api.Contracts.Services
{
    public interface IEntityHandler<T> where T : EntityBase
    {
        Task<T> CreateAsync(T entity);
        Task<IEnumerable<T>> ReadAsync();
        Task<T> ReadAsync(string id);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
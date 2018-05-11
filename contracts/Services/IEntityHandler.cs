using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.MusicLibrary.Api.Contracts.Services
{
    public interface IEntityHandler<T> where T: IEntity

    {
    Task<T> CreateAsync(T entity);
    Task<IEnumerable<T>> ReadAsync();
    Task<T> ReadAsync(string id);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    }
}
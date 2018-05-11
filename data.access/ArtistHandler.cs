using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.MusicLibrary.Api.Contracts.Models;
using Demo.MusicLibrary.Api.Contracts.Services;

namespace Demo.MusicLibrary.Api.DataAccess
{
    internal class ArtistHandler : IArtistHandler
    {
        private readonly IList<Artist> _repository = new List<Artist>
        {
            new Artist{ Id = Guid.NewGuid().ToString("N"),Name = "Metallica",Country = CountryType.Us},
            new Artist{ Id = Guid.NewGuid().ToString("N"),Name = "Guano Apes",Country = CountryType.De},
            new Artist{ Id = Guid.NewGuid().ToString("N"),Name = "Megadeath",Country = CountryType.Us}

        };

        public async Task<IEnumerable<Artist>> ReadAsync()
        {
            return await Task.FromResult(_repository).ConfigureAwait(false);
        }

        public async Task<Artist> ReadAsync(string id)
        {
            return await Task.FromResult(_repository.FirstOrDefault(_ => _.Id == id)).ConfigureAwait(false);
        }

        public async Task<Artist> CreateAsync(Artist entity)
        {
            _repository.Add(entity);
            return await Task.FromResult(entity).ConfigureAwait(false);

        }

        public async Task<Artist> UpdateAsync(Artist entity)
        {
            _repository.Remove(_repository.FirstOrDefault(_ => _.Id == entity.Id));
            _repository.Add(entity);
            return await Task.FromResult(entity).ConfigureAwait(false);
        }

        public async Task<Artist> DeleteAsync(Artist entity)
        {
            _repository.Remove(_repository.FirstOrDefault(_ => _.Id == entity.Id));
            return await Task.FromResult(entity).ConfigureAwait(false);
        }
    }
}

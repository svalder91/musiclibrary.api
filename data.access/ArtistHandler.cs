using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Demo.MusicLibrary.Api.Contracts.Models;
using Demo.MusicLibrary.Api.Contracts.Services;
using Demo.MusicLibrary.Api.DataAccess.Database.Models;
using Demo.MusicLibrary.Api.DataAccess.Database.Services;

namespace Demo.MusicLibrary.Api.DataAccess
{
    internal class ArtistHandler : IArtistHandler
    {
        private readonly IDbArtistHandler _dbArtists;
        private readonly IMapper _mapper;

        // ReSharper disable once UnusedMember.Global
        public ArtistHandler(IDbArtistHandler dbArtists, IMapper mapper)
        {
            _dbArtists = dbArtists;
            _mapper = mapper;
        }


        public async Task<IEnumerable<Artist>> ReadAsync()
        {
            var result = await _dbArtists.ReadAsync().ConfigureAwait(false);
            return result.Select(_ => _mapper.Map<Artist>(_));
        }

        public async Task<Artist> ReadAsync(string id)
        {
            var result = await _dbArtists.ReadAsync(id).ConfigureAwait(false);
            return _mapper.Map<Artist>(result);
        }

        public async Task<Artist> CreateAsync(Artist entity)
        {
            await _dbArtists.CreateAsync(_mapper.Map<DbArtist>(entity)).ConfigureAwait(false);
            return entity;
        }

        public async Task<Artist> UpdateAsync(Artist entity)
        {
            await _dbArtists.UpdateAsync(_mapper.Map<DbArtist>(entity)).ConfigureAwait(false);
            return entity;
        }

        public async Task<Artist> DeleteAsync(Artist entity)
        {
            await _dbArtists.DeleteAsync(_mapper.Map<DbArtist>(entity)).ConfigureAwait(false);
            return entity;
        }
    }
}

using System.Threading.Tasks;
using Demo.MusicLibrary.Api.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Artist = Demo.MusicLibrary.Api.Contracts.Models.Artist;

namespace Demo.MusicLibrary.Api.Core.Controller
{
    public class ArtistController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IArtistHandler _artistHandler;

        public ArtistController(IArtistHandler artistHandler)
        {
            _artistHandler = artistHandler;
        }

        [HttpGet, Route(Constants.Routes.Artist.GetArtists, Name = Constants.Relations.Artists.GetArtists)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _artistHandler.ReadAsync().ConfigureAwait(false));
        }

        [HttpGet, Route(Constants.Routes.Artist.GetArtistById, Name = Constants.Relations.Artists.GetArtistById)]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _artistHandler.ReadAsync(id).ConfigureAwait(false));
        }

        [HttpPost, Route(Constants.Routes.Artist.AddArtist, Name = Constants.Relations.Artists.AddArtist)]
        public async Task<IActionResult> Post([FromBody] Artist artist)
        {
            var result = await _artistHandler.CreateAsync(artist).ConfigureAwait(false);
            if (result != null) return Ok(result);
            return BadRequest();
        }

        [HttpPut, Route(Constants.Routes.Artist.UpdateArtist, Name = Constants.Relations.Artists.UpdateArtist)]
        public async Task<IActionResult> Put(string id, [FromBody] Artist artist)
        {
            if (id != artist.Id) return BadRequest("invalid id");
            var result = await _artistHandler.UpdateAsync(artist).ConfigureAwait(false);
            if (result != null) return Ok(result);
            return BadRequest();
        }

        [HttpDelete, Route(Constants.Routes.Artist.RemoveArtist, Name = Constants.Relations.Artists.RemoveArtist)]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _artistHandler.DeleteAsync(new Artist { Id = id }).ConfigureAwait(false);
            if (result != null) return Ok(result);
            return BadRequest();
        }
    }
}

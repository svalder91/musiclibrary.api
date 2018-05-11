using Demo.MusicLibrary.Api.DataAccess.Database.Models;
using Demo.MusicLibrary.Api.DataAccess.Database.Services;
// ReSharper disable UnusedMember.Global

namespace Demo.MusicLibrary.Api.DataAccess.Database.Handler
{
    internal class DbArtistHandler : DbEntityHandler<DbArtist>, IDbArtistHandler
    {
    }
}

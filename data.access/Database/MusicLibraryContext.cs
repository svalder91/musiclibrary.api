using Demo.MusicLibrary.Api.DataAccess.Database.Models;
using Microsoft.EntityFrameworkCore;
// ReSharper disable UnusedMember.Global

namespace Demo.MusicLibrary.Api.DataAccess.Database
{
    internal sealed class MusicLibraryContext : DbContext
    {
        public MusicLibraryContext(DbContextOptions<MusicLibraryContext> options) : base(options)
        {
        }
        public DbSet<DbArtist> Artists { get; set; }
    }
}

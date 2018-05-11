namespace Demo.MusicLibrary.Api.DataAccess.Database.Models
{
    internal class DbArtist : DbBaseEntity
    {
        public string Name { get; set; }
        public int Country { get; set; }

    }
}

namespace Demo.MusicLibrary.Api.Core.Constants.Routes
{
    internal static class Artist
    {
        public const string Prefix = Home.Prefix + "/artists";
        public const string GetArtists = Prefix;
        public const string GetArtistById = Prefix + "/{id}";
        public const string AddArtist = Prefix;
        public const string UpdateArtist = Prefix;
        public const string RemoveArtist = Prefix + "/{id}";
    }
}

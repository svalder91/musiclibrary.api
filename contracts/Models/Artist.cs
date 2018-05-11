using Demo.MusicLibrary.Api.Contracts.Services;

namespace Demo.MusicLibrary.Api.Contracts.Models
{
    public class Artist : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public CountryType Country { get; set; }
    }
}
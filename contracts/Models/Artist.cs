namespace Demo.MusicLibrary.Api.Contracts.Models
{
    public class Artist : EntityBase
    {
        public string Name { get; set; }
        public CountryType Country { get; set; }
    }
}
using Newtonsoft.Json;

namespace Demo.MusicLibrary.Api.Contracts.Models
{
    public class Link
    {
        [JsonProperty("rel")] public string Relation { get; set; }
        [JsonProperty("href")] public string Hyperreference { get; set; }
        [JsonProperty("method")] public string Method { get; set; }
    }
}

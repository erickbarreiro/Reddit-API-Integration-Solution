using Newtonsoft.Json;

namespace RedditAPI.Models
{
    public class RedditData
    {
        [JsonProperty("modhash")]
        public string Modhash { get; set; }

        [JsonProperty("dist")]
        public int Dist { get; set; }

        [JsonProperty("children")]
        public List<RedditPostContainer> Children { get; set; }

        [JsonProperty("after")]
        public string After { get; set; }

        [JsonProperty("before")]
        public string Before { get; set; }
    }
}

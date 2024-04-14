using Newtonsoft.Json;

namespace RedditAPI.Models
{
    public class RedditPostContainer
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("data")]
        public RedditPost Data { get; set; }
    }
}

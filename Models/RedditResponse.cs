using Newtonsoft.Json;

namespace RedditAPI.Models
{
    public class RedditResponse
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("data")]
        public RedditData Data { get; set; }
    }
}

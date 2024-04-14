using Newtonsoft.Json;

namespace RedditAPI.Models
{
    public class RedditPost
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("subreddit")]
        public string Subreddit { get; set; }

        [JsonProperty("ups")]
        public int Ups { get; set; }

        [JsonProperty("downs")]
        public int Downs { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }
    }
}

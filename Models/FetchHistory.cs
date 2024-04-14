namespace RedditAPI.Models
{
    public class FetchHistory
    {
        public int FetchId { get; set; }
        public int SubredditId { get; set; }
        public DateTime FetchDate { get; set; }
        public virtual Subreddit Subreddit { get; set; }
    }
}

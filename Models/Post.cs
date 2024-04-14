namespace RedditAPI.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int SubredditId { get; set; }
        public DateTime FetchDate { get; set; }
        public virtual Subreddit Subreddit { get; set; }
    }
}

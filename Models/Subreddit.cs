namespace RedditAPI.Models
{
    public class Subreddit
    {
        public int SubredditId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; } // Navigation property for related posts

        public Subreddit()
        {
            Posts = new HashSet<Post>();
        }
    }
}

using RedditAPI.Models;

namespace RedditAPI.Services
{
    public interface ISubredditService
    {
        Task<IEnumerable<Subreddit>> GetAllSubredditsAsync();
        Task AddSubredditAsync(Subreddit subreddit);
    }
}


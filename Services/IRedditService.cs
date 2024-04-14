namespace RedditAPI.Services
{
    using RedditAPI.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRedditService
    {
        Task<List<Post>> FetchPostsAsync(string subredditName);
    }
}

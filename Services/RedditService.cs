using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RedditAPI.Models;

namespace RedditAPI.Services
{
    public class RedditService : IRedditService
    {
        private readonly HttpClient _httpClient;
        private readonly AppDbContext _context;

        public RedditService(HttpClient httpClient, AppDbContext context)
        {
            _httpClient = httpClient;
            _context = context;
        }

        public async Task<List<Post>> FetchPostsAsync(string subredditName)
        {
            var response = await _httpClient.GetAsync($"https://www.reddit.com/r/{subredditName}.json");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var redditResponse = JsonConvert.DeserializeObject<RedditResponse>(content);

                // Ensure the subreddit exists in the database
                var subreddit = await _context.Subreddits.FirstOrDefaultAsync(s => s.Name.ToLower() == subredditName.ToLower());
                if (subreddit == null)
                {
                    // If not found, add it
                    subreddit = new Subreddit { Name = subredditName };
                    _context.Subreddits.Add(subreddit);
                    await _context.SaveChangesAsync();
                }

                var posts = redditResponse.Data.Children.Select(c => new Post
                {
                    Title = c.Data.Title,
                    Author = c.Data.Author,
                    SubredditId = subreddit.SubredditId, // Now we can use the ID
                    FetchDate = DateTime.UtcNow
                }).ToList();

                // Optionally: Save these posts to the database if that's part of your workflow
                _context.Posts.AddRange(posts);
                await _context.SaveChangesAsync();

                return posts;
            }
            return null;
        }
    }
}

using RedditAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RedditAPI.Services
{
    public class SubredditService : ISubredditService
    {
        private readonly AppDbContext _context;

        public SubredditService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subreddit>> GetAllSubredditsAsync()
        {
            return await _context.Subreddits.ToListAsync();
        }

        public async Task AddSubredditAsync(Subreddit subreddit)
        {
            _context.Subreddits.Add(subreddit);
            await _context.SaveChangesAsync();
        }
    }
}


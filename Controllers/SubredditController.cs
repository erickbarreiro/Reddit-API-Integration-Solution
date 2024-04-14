using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedditAPI.Models;
using RedditAPI.Models;
using RedditAPI.Services;

namespace RedditAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubredditController : ControllerBase
    {
        private readonly ISubredditService _subredditService;

        public SubredditController(ISubredditService subredditService)
        {
            _subredditService = subredditService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubreddits()
        {
            var subreddits = await _subredditService.GetAllSubredditsAsync();
            return Ok(subreddits);
        }

        [HttpPost]
        public async Task<IActionResult> AddSubreddit(Subreddit subreddit)
        {
            await _subredditService.AddSubredditAsync(subreddit);
            return CreatedAtAction(nameof(GetAllSubreddits), new { id = subreddit.SubredditId }, subreddit);
        }
    }
}
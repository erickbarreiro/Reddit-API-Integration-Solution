using Microsoft.AspNetCore.Mvc;
using RedditAPI.Services;

namespace RedditAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IRedditService _redditService;

        public PostsController(IRedditService redditService)
        {
            _redditService = redditService;
        }

        [HttpGet("{subredditName}")]
        public async Task<IActionResult> GetPosts(string subredditName)
        {
            var posts = await _redditService.FetchPostsAsync(subredditName);
            if (posts != null)
                return Ok(posts);
            else
                return NotFound($"Subreddit {subredditName} not found or no posts available.");
        }
    }
}

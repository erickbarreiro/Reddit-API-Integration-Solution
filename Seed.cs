using Microsoft.EntityFrameworkCore;
using RedditAPI.Models;

namespace RedditAPI
{
    public class SeedClass
    {
        public static void Seed(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<AppDbContext>();

                // Automatically apply any pending migrations
                context.Database.Migrate();

                // Check if the database is already seeded
                if (!context.Subreddits.Any())
                {
                    SeedSubreddits(context);
                }

                if (!context.Posts.Any())
                {
                    SeedPosts(context);
                }

                if (!context.FetchHistories.Any())
                {
                    SeedFetchHistories(context);
                }

                // Additional seeding logic can be placed here if needed
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while seeding the database.");
                throw;  // Optional: rethrow the exception if you want to stop the app from starting
            }
        }

        private static void SeedSubreddits(AppDbContext context)
        {
            var subreddits = new List<Subreddit>
    {
        new Subreddit { Name = "computerscience" },
        new Subreddit { Name = "technology" }
    };
            context.Subreddits.AddRange(subreddits);
            context.SaveChanges();
        }

        private static void SeedPosts(AppDbContext context)
        {
            var posts = new List<Post>
    {
        new Post { Title = "Welcome to Computer Science", Author = "Admin", SubredditId = 1, FetchDate = DateTime.UtcNow },
        new Post { Title = "Latest Tech News", Author = "Reporter", SubredditId = 2, FetchDate = DateTime.UtcNow }
    };
            context.Posts.AddRange(posts);
            context.SaveChanges();
        }

        private static void SeedFetchHistories(AppDbContext context)
        {
            var fetchHistories = new List<FetchHistory>
    {
        new FetchHistory { SubredditId = 1, FetchDate = DateTime.UtcNow },
        new FetchHistory { SubredditId = 2, FetchDate = DateTime.UtcNow }
    };
            context.FetchHistories.AddRange(fetchHistories);
            context.SaveChanges();
        }
    }
}

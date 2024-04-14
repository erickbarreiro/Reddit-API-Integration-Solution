using Microsoft.EntityFrameworkCore;
using RedditAPI.Models;

namespace RedditAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Subreddit> Subreddits { get; set; }
        public DbSet<FetchHistory> FetchHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Entity configurations
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(p => p.PostId);
                entity.Property(p => p.Title).IsRequired();
                entity.Property(p => p.Author).IsRequired();
                entity.Property(p => p.FetchDate).HasColumnType("datetime");
                entity.HasOne(p => p.Subreddit)
                      .WithMany(s => s.Posts)
                      .HasForeignKey(p => p.SubredditId);
            });

            modelBuilder.Entity<Subreddit>(entity =>
            {
                entity.HasKey(s => s.SubredditId);
                entity.Property(s => s.Name).IsRequired();
            });

            modelBuilder.Entity<FetchHistory>(entity =>
            {
                entity.HasKey(f => f.FetchId);
                entity.Property(f => f.FetchDate).HasColumnType("datetime");
                entity.HasOne(f => f.Subreddit)
                      .WithMany()
                      .HasForeignKey(f => f.SubredditId)
                      .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
            });
        }
    }
}


namespace RedditAPI.Services
{
    public class RedditBackgroundService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IRedditService _redditService;

        public RedditBackgroundService(IRedditService redditService)
        {
            _redditService = redditService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(15));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _redditService.FetchPostsAsync("some_subreddit");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }

}

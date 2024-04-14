using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RedditAPI;
using RedditAPI.Services;
using Polly;
using Polly.Extensions.Http;
using AspNetCoreRateLimit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Reddit API Integration", Version = "v1" });
});

// Inside your ConfigureServices method
builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
builder.Services.AddScoped<ISubredditService, SubredditService>();
builder.Services.AddScoped<IRedditService, RedditService>();
builder.Services.AddHttpClient<IRedditService, RedditService>();
builder.Services.AddHostedService<RedditBackgroundService>();
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddHttpClient("RedditClient", client =>
{
    client.BaseAddress = new Uri("https://www.reddit.com/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
})
.AddPolicyHandler(HttpPolicyExtensions
    .HandleTransientHttpError() // Handle HttpRequestException, 5XX and 408
    .WaitAndRetryAsync(new[]
    {
        TimeSpan.FromSeconds(1),
        TimeSpan.FromSeconds(5),
        TimeSpan.FromSeconds(10)
    }));

var app = builder.Build();
SeedClass.Seed(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseIpRateLimiting();
app.UseHttpsRedirection();
app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();

using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using FluentAssertions;
using Newtonsoft.Json;
using System.Text;

namespace RedditAPI.Testing
{
    public class SubredditIntegrationTests : IClassFixture<WebApplicationFactory<RedditAPI.Startup>>
    {
        private readonly WebApplicationFactory<RedditAPI.Startup> _factory;
        private readonly HttpClient _client;

        public SubredditIntegrationTests(WebApplicationFactory<RedditAPI.Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Post_Subreddit_ShouldReturnCreatedResponse()
        {
            // Create a simple anonymous object to represent the subreddit
            var subreddit = new { Name = "testsubreddit" };
            var content = new StringContent(JsonConvert.SerializeObject(subreddit), Encoding.UTF8, "application/json");

            // Send a POST request to the subreddit endpoint
            var response = await _client.PostAsync("/subreddit", content);

            // Assert the status code of the response
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            // Deserialize the response content to dynamically check the 'Name' property
            var responseBody = await response.Content.ReadAsStringAsync();
            var returnedSubreddit = JsonConvert.DeserializeObject<dynamic>(responseBody);

            // Verify that the subreddit name returned is the same as was sent
            ((string)returnedSubreddit.Name).Should().Be(subreddit.Name);
        }
    }
}

using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AspNetCoreStudies.Api.Features.Articles;
using AspNetCoreStudies.Tests;
using Xunit;

namespace AspNetCoreStudies.Features.Articles
{
    public class BlogsControllerTest : IClassFixture<TestFixture>
    {
        private readonly HttpClient _client;

        public BlogsControllerTest(TestFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task Get_all_should_return_articles()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/articles");

            var response = await _client.SendAsync(request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_article_that_does_not_exist_should_return_not_found()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/articles/0");

            var response = await _client.SendAsync(request);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Valid_post_should_create_article()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/articles");
            var json = JsonSerializer.Serialize(new Article
            {
                Title = "Article title",
                Content = "Article content"
            });

            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            request.Content = stringContent;

            var response = await _client.SendAsync(request);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
}

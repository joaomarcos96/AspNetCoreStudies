using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace AspNetCoreStudies.Tests
{
    public class BlogsControllerTest : IClassFixture<TestFixture>
    {
        private readonly HttpClient _client;

        public BlogsControllerTest(TestFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task Get_should_return_ok()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/blogs");

            var response = await _client.SendAsync(request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
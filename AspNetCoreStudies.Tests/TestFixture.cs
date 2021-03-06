using System;
using System.Data.Common;
using System.Net.Http;
using AspNetCoreStudies.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreStudies.Tests
{
    public class TestFixture : IDisposable
    {
        private DbConnection _connection;

        private readonly TestServer _server;

        public HttpClient Client { get; }

        public TestFixture()
        {
            var builder = new WebHostBuilder()
                .UseStartup<Startup>()
                .UseEnvironment("Testing")
                .ConfigureServices(services =>
                {
                    _connection = new SqliteConnection("DataSource=file::memory:?cache=shared");
                    _connection.Open();

                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseSqlite(_connection);
                    });

                    var serviceProvider = services.BuildServiceProvider();

                    using (var scope = serviceProvider.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var dbContext = scopedServices.GetRequiredService<ApplicationDbContext>();

                        dbContext.Database.EnsureDeleted();
                        dbContext.Database.EnsureCreated();
                    }
                });

            _server = new TestServer(builder);

            Client = _server.CreateClient();
        }

        public void Dispose()
        {
            Client.Dispose();
            _server.Dispose();

            if (_connection != null)
            {
                _connection.Close();
                _connection = null;
            }
        }
    }
}

using System;
using System.IO;
using System.Net.Http;
using AspNetCoreStudies.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreStudies.Tests
{
    public class TestFixture : IDisposable
    {
        private readonly TestServer _server;

        public HttpClient Client { get; }

        private readonly string _dbName = $"{Guid.NewGuid()}.db";

        public TestFixture()
        {
            var builder = new WebHostBuilder()
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .AddEnvironmentVariables();
                })
                .ConfigureServices(services =>
                {
                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseSqlite($"Data Source={_dbName}");
                    });

                    var serviceProvider = services.BuildServiceProvider();

                    using (var scope = serviceProvider.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var dbContext = scopedServices.GetRequiredService<ApplicationDbContext>();

                        dbContext.Database.EnsureCreated();
                    }

                });

            _server = new TestServer(builder);

            Client = _server.CreateClient();
        }

        public void Dispose()
        {
            File.Delete(_dbName);
            Client.Dispose();
            _server.Dispose();
        }
    }
}

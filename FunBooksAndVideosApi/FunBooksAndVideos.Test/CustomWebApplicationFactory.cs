using FunBooksAndVideos.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

namespace FunBooksAndVideos.IntegrationTests
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContextDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<BookAndVideoContext>));

                services.Remove(dbContextDescriptor);

                var dbConnectionDescriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbConnection));

                services.Remove(dbConnectionDescriptor);

                services.AddDbContext<BookAndVideoContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDB");
                });

            });

            builder.UseEnvironment("Development");
        }

        public BookAndVideoContext GetDbContext()=>Services.CreateScope().ServiceProvider.GetService< BookAndVideoContext>();
    }
}

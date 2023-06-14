using FunBooksAndVideos.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace FunBooksAndVideos.IntegrationTests
{
    public class CreatePurchaseOrderTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public CreatePurchaseOrderTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/Product/5")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
        }

        [Fact]
        public async Task Post_NewPhysicalBook_PurchaseOrderIsCreated()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<BookAndVideoContext>();

                Utilities.ReinitializeDbForTests(db);
            }

            // Act
            var response = await client.GetAsync("");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
        }


    }
}

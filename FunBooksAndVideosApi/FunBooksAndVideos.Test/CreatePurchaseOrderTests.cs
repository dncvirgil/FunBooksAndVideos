using FunBooksAndVideos.Api.Model;
using FunBooksAndVideos.Data;
using FunBooksAndVideos.Data.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using Xunit;

namespace FunBooksAndVideos.IntegrationTests
{
    public class CreatePurchaseOrderTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> factory;
        private const string PurchaseOrderURL = "/api/PurchaseOrder";

        public CreatePurchaseOrderTests(CustomWebApplicationFactory<Program> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task CreatePurchaseOrder_WithPhysicalBook_ShipmentIsCreated()
        {
            // Arrange
            var client = factory.CreateClient();

            var context = factory.GetDbContext();
            SeedDataForPhysiscalBook(context);

            var request = new CreatePurchaseOrderRequest
            {
                CustomerId = 1,
                TotalPrice = 10,
                ItemLines = new List<string> { "A Physical Book Title" }
            };
            
            // Act
            JsonContent content = JsonContent.Create(request);
            var response = await client.PostAsync(PurchaseOrderURL, content);

            // Assert
            response.EnsureSuccessStatusCode();

            var shipment = context.Shippings.FirstOrDefault();
            Assert.NotNull(shipment);
        }

        private static void SeedDataForPhysiscalBook(BookAndVideoContext db)
        {
            var existingProduct = new Product
            {
                Name = "A Physical Book Title",
                Description = "Some description",
                Price = 10,
                Url = "google.com",
                ProductType = new ProductType { Name = "Book" }
            };

            var existingCustomer = new Customer
            {
                Name = "Customer Name",
                DeliveryAddress = "Test Address",
                BillingAddress = "Some Address",
                Email = "test@mail.com",
                User = new User { Password = "password", UserName = "Username" }
            };

            db.Products.Add(existingProduct);
            db.Customers.Add(existingCustomer);
            db.SaveChanges();
        }
    }
}

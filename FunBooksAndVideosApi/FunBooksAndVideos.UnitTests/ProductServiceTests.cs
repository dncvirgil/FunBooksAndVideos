using FunBooksAndVideos.Data.Repositories.Interfaces;
using FunBooksAndVideos.Domain;
using FunBooksAndVideos.Service.Interfaces;
using Moq;
using Xunit;

namespace FunBooksAndVideos.Service.UnitTests
{

    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> productRepositoryMock;
        private IProductService? productService;

        public ProductServiceTests()
        {
            productRepositoryMock = new Mock<IProductRepository>();
        }

        [Fact]
        public async Task GetProducts_NoProductsFound_ReturnEmptyList()
        {
            //Arrange
            var mokedProducts = Enumerable.Empty<Data.Entities.Product>();
            productRepositoryMock.Setup(x => x.GetProducts(It.IsAny<ProductTypeEnum>()))
                                 .ReturnsAsync(mokedProducts);
            productService = new ProductService(productRepositoryMock.Object);

            //Act
            var products = await productService.GetProducts(ProductTypeEnum.Movie);

            //Assert
            Assert.NotNull(products);
            Assert.Empty(products);
        }
    }
}

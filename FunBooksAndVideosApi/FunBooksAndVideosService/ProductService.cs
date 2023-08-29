using FunBooksAndVideos.Data.Repositories.Interfaces;
using FunBooksAndVideos.Domain;
using FunBooksAndVideos.Service.Interfaces;

namespace FunBooksAndVideos.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<Product>> GetProducts(ProductTypeEnum productType)
        {
            var products = await productRepository.GetProducts(productType);
            return products;
        }
    }
}

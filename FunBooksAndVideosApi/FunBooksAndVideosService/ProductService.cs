using FunBooksAndVideos.Data.Repositories;
using FunBooksAndVideos.Domain;
using FunBooksAndVideos.Service.Interfaces;

namespace FunBooksAndVideos.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetProducts(ProductTypeEnum productType)
        {
            var products = await productRepository.GetProducts(productType);
            if(products == null)
            {
                return Enumerable.Empty<Product>();
            }

            //map to domain model product
            return products.Select(product =>
                new Domain.Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price
                });
        }
    }
}

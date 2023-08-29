using FunBooksAndVideos.Data.Mapping;
using FunBooksAndVideos.Data.Repositories.Interfaces;
using FunBooksAndVideos.Domain;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BookAndVideoContext context;

        public ProductRepository(BookAndVideoContext bookAndVideoContext)
        {
            this.context = bookAndVideoContext ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Product?> GetProductByName(string name)
        {
            var product = await context.Products.Include(x=>x.ProductType).FirstOrDefaultAsync(x => x.Name == name);
            return product?.ToDomain();
        }

        public async Task<IEnumerable<Product>> GetProducts(ProductTypeEnum productType)
        {
            var filteredProducts = context.Products.Where(x => x.ProductTypeId == (int)productType)
                                                   .Include(x => x.ProductType)
                                                   .Select(product => product.ToDomain())
                                                   .ToListAsync();
            return await filteredProducts;
        }
    }
}

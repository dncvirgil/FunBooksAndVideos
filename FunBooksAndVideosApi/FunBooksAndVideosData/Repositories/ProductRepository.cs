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
            this.context = bookAndVideoContext;
        }

        public async Task<Entities.Product> GetProductByName(string name)
        {
            var product = await context.Products.Include(x=>x.ProductType).FirstOrDefaultAsync(x => x.Name == name);
            return product;
        }

        public async Task<IEnumerable<Entities.Product>> GetProducts(ProductTypeEnum productType)
        {
            var filteredProducts = context.Products.Where(x => x.ProductTypeId == (int)productType);
            return await filteredProducts.ToListAsync();
        }
    }
}

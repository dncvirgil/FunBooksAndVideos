using FunBooksAndVideos.Data.Repositories.Interfaces;
using FunBooksAndVideos.Domain;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BookAndVideoContext _context;

        public ProductRepository(BookAndVideoContext bookAndVideoContext)
        {
            _context = bookAndVideoContext;
        }

        public async Task<Entities.Product> GetProductByName(string name)
        {
            var product = await _context.Products.Include(x=>x.ProductType).FirstOrDefaultAsync(x => x.Name == name);
            return product;
        }

        public async Task<IEnumerable<Entities.Product>> GetProducts(ProductTypeEnum productType)
        {
            var filteredProducts = _context.Products.Where(x => x.ProductTypeId == (int)productType);
            return await filteredProducts.ToListAsync();
        }
    }
}

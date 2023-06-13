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

        public async Task<IEnumerable<Entities.Product>> GetProducts(ProductTypeEnum productType)
        {
            var filteredProducts = _context.Products.Where(x => x.ProductTypeId == (int)productType);
            return await filteredProducts.ToListAsync();
        }
    }
}

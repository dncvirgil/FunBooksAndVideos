using FunBooksAndVideos.Data.Entities;
using FunBooksAndVideos.Data.Repositories.Interfaces;

namespace FunBooksAndVideos.Data.Repositories
{
    public class CustomerProductRepository : ICustomerProductRepository
    {
        private readonly BookAndVideoContext _context;
        public CustomerProductRepository(BookAndVideoContext _context)
        {
            this._context = _context;
        }

        public async Task Add(int customerId, int productId)
        {
            var customerProduct = new CustomerProduct()
            {
                CustomerId = customerId,
                ProductId = productId
            };

            _context.CustomerProduct.Add(customerProduct);
            _context.SaveChanges();
        }
    }
}

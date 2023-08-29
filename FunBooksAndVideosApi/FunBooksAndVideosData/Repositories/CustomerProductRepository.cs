using FunBooksAndVideos.Data.Entities;
using FunBooksAndVideos.Data.Repositories.Interfaces;

namespace FunBooksAndVideos.Data.Repositories
{
    public class CustomerProductRepository : ICustomerProductRepository
    {
        private readonly BookAndVideoContext context;
        public CustomerProductRepository(BookAndVideoContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(int customerId, int productId)
        {
            var customerProduct = new CustomerProduct()
            {
                CustomerId = customerId,
                ProductId = productId
            };

            context.CustomerProduct.Add(customerProduct);
            context.SaveChanges();
        }
    }
}

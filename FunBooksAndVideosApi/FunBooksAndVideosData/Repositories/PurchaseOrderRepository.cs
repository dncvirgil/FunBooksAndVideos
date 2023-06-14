using FunBooksAndVideos.Data.Entities;
using FunBooksAndVideos.Data.Repositories.Interfaces;

namespace FunBooksAndVideos.Data.Repositories
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly BookAndVideoContext _context;

        public PurchaseOrderRepository(BookAndVideoContext context)
        {
            _context = context;
        }

        public async Task<int> Create(int customerId, decimal totalPrice, List<Product> products)
        {
            var orderItems = products.Select(product => new OrderItems
            {
                Product = product,
                Quantity = 0,  //not implemented yet
                TotalPrice = 0 //not implemented yet
            }).ToList();

            var purchaseOrder = new PurchaseOrder
            {
                CustomerId = customerId,
                TotalPrice = totalPrice,
                OrderItems = orderItems
            };
            await _context.PurchaseOrders.AddAsync(purchaseOrder);
            await _context.SaveChangesAsync();
            return purchaseOrder.Id;
        }
    }
}

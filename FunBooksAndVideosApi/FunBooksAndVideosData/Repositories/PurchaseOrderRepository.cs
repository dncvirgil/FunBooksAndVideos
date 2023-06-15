using FunBooksAndVideos.Data.Entities;
using FunBooksAndVideos.Data.Repositories.Interfaces;

namespace FunBooksAndVideos.Data.Repositories
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly BookAndVideoContext context;

        public PurchaseOrderRepository(BookAndVideoContext context)
        {
            this.context = context;
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
            await context.PurchaseOrders.AddAsync(purchaseOrder);
            await context.SaveChangesAsync();
            return purchaseOrder.Id;
        }
    }
}

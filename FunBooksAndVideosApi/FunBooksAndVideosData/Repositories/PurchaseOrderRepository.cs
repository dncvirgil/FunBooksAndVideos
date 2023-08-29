using FunBooksAndVideos.Data.Entities;
using FunBooksAndVideos.Data.Repositories.Interfaces;

namespace FunBooksAndVideos.Data.Repositories
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly BookAndVideoContext context;

        public PurchaseOrderRepository(BookAndVideoContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Create(int customerId, decimal totalPrice, List<Domain.Product> products)
        {
            var orderItems = products.Select(product => new OrderItems
            {
                ProductId = product.Id,
                Quantity = 1,
                TotalPrice = product.Price
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

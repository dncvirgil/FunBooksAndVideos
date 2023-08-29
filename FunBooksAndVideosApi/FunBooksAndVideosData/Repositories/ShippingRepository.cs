using FunBooksAndVideos.Data.Entities;
using FunBooksAndVideos.Data.Repositories.Interfaces;

namespace FunBooksAndVideos.Data.Repositories
{
    public class ShippingRepository : IShippingRepository
    {
        private readonly BookAndVideoContext context;

        public ShippingRepository(BookAndVideoContext _context)
        {
            this.context = _context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(int purchaseOrderId, string address)
        {
            var shipping = new Shipping()
            {
                PurchaseOrderId = purchaseOrderId,
                Address = address,
                CreatedDate = DateTime.UtcNow
            };

            context.Shippings.Add(shipping);
            await context.SaveChangesAsync();
        }
    }
}

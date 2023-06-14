
using FunBooksAndVideos.Data.Entities;
using FunBooksAndVideos.Data.Repositories.Interfaces;

namespace FunBooksAndVideos.Data.Repositories
{
    public class ShippingRepository : IShippingRepository
    {
        private readonly BookAndVideoContext _context;

        public ShippingRepository(BookAndVideoContext _context)
        {
            this._context = _context;
        }

        public async Task Add(int purchaseOrderId, string address)
        {
            var shipping = new Shipping()
            {
                PurchaseOrderId = purchaseOrderId,
                Address = address,
                CreatedDate = DateTime.UtcNow
            };

            _context.Shippings.Add(shipping);
            _context.SaveChanges();
        }
    }
}

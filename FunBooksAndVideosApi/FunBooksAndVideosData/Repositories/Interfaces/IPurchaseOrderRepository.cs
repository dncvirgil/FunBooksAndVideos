using FunBooksAndVideos.Data.Entities;

namespace FunBooksAndVideos.Data.Repositories.Interfaces
{
    public interface IPurchaseOrderRepository
    {
        Task<int> Create(int customerId, decimal totalPrice, List<Product> products);
    }
}

namespace FunBooksAndVideos.Data.Repositories.Interfaces
{
    public interface ICustomerProductRepository
    {
        Task Add(int customerId, int productId);
    }
}

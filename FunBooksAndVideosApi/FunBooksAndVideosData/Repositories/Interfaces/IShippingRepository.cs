namespace FunBooksAndVideos.Data.Repositories.Interfaces
{
    public interface IShippingRepository
    {
        Task Add(int purchaseOrderId, string address);
    }
}

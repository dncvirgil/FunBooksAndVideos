using FunBooksAndVideos.Service.Model;
namespace FunBooksAndVideos.Service.Interfaces
{
    public interface IPurchaseOrderService
    {
        Task CreatePurchaseOrder(CreatePurchaseOrderRequestDto request);
    }
}

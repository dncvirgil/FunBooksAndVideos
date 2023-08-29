using FunBooksAndVideos.Domain;

namespace FunBooksAndVideos.Service.Processor
{
    public interface IPurchaseOrderProcessor
    {
        Task ProcessRequest(PurchaseOrder purchaseOrder);
    }
}

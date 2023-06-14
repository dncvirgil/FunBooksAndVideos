using FunBooksAndVideos.Processor.Model;

namespace FunBooksAndVideos.Processor
{
    public interface IPurchaseOrderProcessor
    {
        Task ProcessRequest(CreatePurchaseOrderRequest request);
    }
}

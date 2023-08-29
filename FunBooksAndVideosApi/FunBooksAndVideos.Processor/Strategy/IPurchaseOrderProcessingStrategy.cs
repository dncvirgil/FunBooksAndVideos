using FunBooksAndVideos.Processor.Model;

namespace FunBooksAndVideos.Processor.Strategy
{
    public interface IPurchaseOrderProcessingStrategy
    {
        public List<string> ProductType { get; }
        Task Process(CreatePurchaseOrderRequest request, int purchaseOrderId, Domain.Product product);
    }
}

using FunBooksAndVideos.Domain;

namespace FunBooksAndVideos.Service.Processor.Strategy
{
    public interface IPurchaseOrderProcessingStrategy
    {
        public List<string> ProductType { get; }
        Task Process(PurchaseOrder purchaseOrder, Product product);
    }
}

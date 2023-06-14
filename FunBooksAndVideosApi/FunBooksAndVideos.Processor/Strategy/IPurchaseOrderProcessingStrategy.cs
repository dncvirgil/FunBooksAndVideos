using FunBooksAndVideos.Data.Entities;
using FunBooksAndVideos.Processor.Model;

namespace FunBooksAndVideos.Processor.Strategy
{
    public interface IPurchaseOrderProcessingStrategy
    {
        public List<string> ProductType { get; }
        Task Process(CreatePurchaseOrderRequest request, Product product);
    }
}

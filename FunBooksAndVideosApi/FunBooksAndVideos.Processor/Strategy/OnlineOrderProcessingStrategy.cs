using FunBooksAndVideos.Data.Entities;
using FunBooksAndVideos.Processor.Model;

namespace FunBooksAndVideos.Processor.Strategy
{
    public class OnlineOrderProcessingStrategy : IPurchaseOrderProcessingStrategy
    {
        public List<string> ProductType { get => new List<string> { "eBook", "Video" }; }

        public Task Process(CreatePurchaseOrderRequest request, Product product)
        {
            throw new NotImplementedException();
        }
    }
}

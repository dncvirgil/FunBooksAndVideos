using FunBooksAndVideos.Data.Entities;
using FunBooksAndVideos.Processor.Model;

namespace FunBooksAndVideos.Processor.Strategy
{
    public class PhysicalOrderProcessingStrategy : IPurchaseOrderProcessingStrategy
    {
        public List<string> ProductType { get => new List<string> { "Book" }; }

        public Task Process(CreatePurchaseOrderRequest request, Product product)
        {
            throw new NotImplementedException();
        }
    }
}

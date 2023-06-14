using FunBooksAndVideos.Data.Entities;
using FunBooksAndVideos.Processor.Model;

namespace FunBooksAndVideos.Processor.Strategy
{
    public class MembershipOrderProcessingStrategy : IPurchaseOrderProcessingStrategy
    {
        public List<string> ProductType { get => new List<string> { "BookMembership", "VideoMembership", "PremiumMembership" }; }

        public Task Process(CreatePurchaseOrderRequest request, Product product)
        {
            throw new NotImplementedException();
        }
    }
}

using FunBooksAndVideos.Data.Repositories.Interfaces;
using FunBooksAndVideos.Domain;

namespace FunBooksAndVideos.Service.Processor.Strategy
{
    public sealed class OnlineOrderProcessingStrategy : IPurchaseOrderProcessingStrategy
    {
        public List<string> ProductType { get => new() { "eBook", "Video" }; }
        private readonly ICustomerProductRepository customerProductRepository;

        public OnlineOrderProcessingStrategy(ICustomerProductRepository customerProductRepository)
        {
            this.customerProductRepository = customerProductRepository ?? throw new ArgumentNullException(nameof(customerProductRepository));
        }

        public async Task Process(PurchaseOrder purchaseOrder, Product product)
        {
            await customerProductRepository.Add(purchaseOrder.Customer.Id, product.Id);
        }
    }
}

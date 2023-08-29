using FunBooksAndVideos.Data.Repositories.Interfaces;
using FunBooksAndVideos.Domain;

namespace FunBooksAndVideos.Service.Processor.Strategy
{
    public class PhysicalOrderProcessingStrategy : IPurchaseOrderProcessingStrategy
    {
        public List<string> ProductType { get => new() { "Book" }; }
        private readonly IShippingRepository shippingRepository;
        private readonly ICustomerProductRepository customerProductRepository;

        public PhysicalOrderProcessingStrategy(IShippingRepository shippingRepository, 
                                               ICustomerProductRepository customerProductRepository)
        {
            this.shippingRepository = shippingRepository ?? throw new ArgumentNullException(nameof(shippingRepository));
            this.customerProductRepository = customerProductRepository ?? throw new ArgumentNullException(nameof(customerProductRepository));
        }

        public async Task Process(PurchaseOrder purchaseOrder, Product product)
        {
            await shippingRepository.Add(purchaseOrder.Id, purchaseOrder.Customer.DeliveryAddress);
            await customerProductRepository.Add(purchaseOrder.Customer.Id, product.Id);
        }
    }
}

using FunBooksAndVideos.Data.Entities;
using FunBooksAndVideos.Data.Repositories.Interfaces;
using FunBooksAndVideos.Processor.Model;

namespace FunBooksAndVideos.Processor.Strategy
{
    public class PhysicalOrderProcessingStrategy : IPurchaseOrderProcessingStrategy
    {
        public List<string> ProductType { get => new() { "Book" }; }

        private readonly IShippingRepository shippingRepository;
        private readonly ICustomerRepository customerRepository;

        public PhysicalOrderProcessingStrategy(IShippingRepository shippingRepository, 
            ICustomerRepository customerRepository)
        {
            this.shippingRepository = shippingRepository;
            this.customerRepository = customerRepository;
        }

        public async Task Process(CreatePurchaseOrderRequest request, int purchaseOrderId, Product product)
        {
            var customer = await customerRepository.Get(request.CustomerId);
            await shippingRepository.Add(purchaseOrderId, customer.DeliveryAddress);
        }
    }
}

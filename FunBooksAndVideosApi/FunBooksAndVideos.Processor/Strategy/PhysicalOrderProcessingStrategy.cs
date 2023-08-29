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
            this.shippingRepository = shippingRepository ?? throw new ArgumentNullException(nameof(shippingRepository));
            this.customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task Process(CreatePurchaseOrderRequest request, int purchaseOrderId, Domain.Product product) //product not used
        {
            var customer = await customerRepository.Get(request.CustomerId);
            await shippingRepository.Add(purchaseOrderId, customer.DeliveryAddress);
        }
    }
}

using FunBooksAndVideos.Data.Repositories.Interfaces;
using FunBooksAndVideos.Service.Interfaces;
using FunBooksAndVideos.Service.Model;
using FunBooksAndVideos.Service.Processor;

namespace FunBooksAndVideos.Service
{
    internal class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderProcessor processor;
        private readonly IProductRepository productRepository;
        private readonly ICustomerRepository customerRepository;

        public PurchaseOrderService(IPurchaseOrderProcessor processor,
            IProductRepository productRepository,
            ICustomerRepository customerRepository)
        {
            this.processor = processor ?? throw new ArgumentNullException(nameof(processor));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));

        }

        public async Task CreatePurchaseOrder(CreatePurchaseOrderRequestDto request)
        {
            List<Domain.Product> products = await GetPurchasedProducts(request.ItemLines);

            if (!products.Any())
            {
                throw new Exception("No products found");
            }

            var customer = await customerRepository.Get(request.CustomerId) ?? throw new Exception("Customer not found");

            var purchaseOrder = new Domain.PurchaseOrder();
            purchaseOrder.Products = products;
            purchaseOrder.TotalPrice = request.TotalPrice;
            purchaseOrder.Customer = customer;

            await processor.ProcessRequest(purchaseOrder);
        }

        private async Task<List<Domain.Product>> GetPurchasedProducts(List<string> itemLines)
        {
            var products = new List<Domain.Product>();
            foreach (var item in itemLines)
            {
                var product = await productRepository.GetProductByName(item);
                if (product is not null)
                {
                    products.Add(product);
                }
            }

            return products;
        }
    }
}

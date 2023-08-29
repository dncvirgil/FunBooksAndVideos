using FunBooksAndVideos.Data.Repositories.Interfaces;
using FunBooksAndVideos.Processor.Model;
using FunBooksAndVideos.Processor.Strategy;

namespace FunBooksAndVideos.Processor
{
    public class PurchaseOrderProcessor : IPurchaseOrderProcessor
    {
        private readonly IEnumerable<IPurchaseOrderProcessingStrategy> availableStrategies;
        private readonly IProductRepository productRepository;
        private readonly IPurchaseOrderRepository purchaseOrderRepository;

        public PurchaseOrderProcessor(IEnumerable<IPurchaseOrderProcessingStrategy> strategies,
            IProductRepository productRepository,
            IPurchaseOrderRepository purchaseOrderRepository)
        {
            this.availableStrategies = strategies ?? throw new ArgumentNullException(nameof(strategies));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.purchaseOrderRepository = purchaseOrderRepository ?? throw new ArgumentNullException(nameof(purchaseOrderRepository));
        }
        public async Task ProcessRequest(CreatePurchaseOrderRequest request)
        {
            List<Domain.Product> products = await GetProducts(request);

            //save purchase order and order items
            var purchaseOrderId = await purchaseOrderRepository.Create(request.CustomerId, request.TotalPrice, products);

            foreach (var product in products)
            {
                var strategy = availableStrategies.FirstOrDefault(s => s.ProductType.Any(x => x.Equals(product.ProductType.Name)));
                if (strategy == null)
                {
                    throw new NotImplementedException();
                }

                await strategy!.Process(request, purchaseOrderId, product);
            }
        }

        private async Task<List<Domain.Product>> GetProducts(CreatePurchaseOrderRequest request)
        {
            var products = new List<Domain.Product>();
            foreach (var item in request.ItemLines)
            {
                var product = await productRepository.GetProductByName(item);
                //if same product then we should increase quantity
                products.Add(product);
            }

            return products;
        }
    }
}
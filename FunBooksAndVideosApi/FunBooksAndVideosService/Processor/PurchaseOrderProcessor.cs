using FunBooksAndVideos.Data.Repositories.Interfaces;
using FunBooksAndVideos.Domain;
using FunBooksAndVideos.Service.Processor.Strategy;

namespace FunBooksAndVideos.Service.Processor
{
    public class PurchaseOrderProcessor : IPurchaseOrderProcessor
    {
        private readonly IEnumerable<IPurchaseOrderProcessingStrategy> availableStrategies;
        private readonly IPurchaseOrderRepository purchaseOrderRepository;

        public PurchaseOrderProcessor(IEnumerable<IPurchaseOrderProcessingStrategy> availableStrategies,
                                      IPurchaseOrderRepository purchaseOrderRepository)
        {
            this.availableStrategies = availableStrategies ?? throw new ArgumentNullException(nameof(availableStrategies));
            this.purchaseOrderRepository = purchaseOrderRepository ?? throw new ArgumentNullException(nameof(purchaseOrderRepository));
        }
        public async Task ProcessRequest(PurchaseOrder purchaseOrder)
        {
            var purchaseOrderId = await purchaseOrderRepository.Create(purchaseOrder.Customer.Id, purchaseOrder.TotalPrice, purchaseOrder.Products);
            purchaseOrder.Id = purchaseOrderId;

            foreach (var product in purchaseOrder.Products)
            {
                var strategy = availableStrategies.FirstOrDefault(s => s.ProductType.Exists(x => x.Equals(product.ProductType.Name)));
                if (strategy is null)
                {
                    throw new NotImplementedException();
                }

                await strategy!.Process(purchaseOrder, product);
            }
        }
    }
}

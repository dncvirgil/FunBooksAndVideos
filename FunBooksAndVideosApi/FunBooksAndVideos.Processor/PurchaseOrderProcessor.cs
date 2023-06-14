using FunBooksAndVideos.Data.Repositories;
using FunBooksAndVideos.Processor.Model;
using FunBooksAndVideos.Processor.Strategy;

namespace FunBooksAndVideos.Processor
{
    public class PurchaseOrderProcessor : IPurchaseOrderProcessor
    {
        private readonly IEnumerable<IPurchaseOrderProcessingStrategy> availableStrategies;
        private readonly IProductRepository productRepository;

        public PurchaseOrderProcessor(IEnumerable<IPurchaseOrderProcessingStrategy> strategies,
            IProductRepository productRepository)
        {
            this.availableStrategies = strategies;
            this.productRepository = productRepository;
        }
        public async Task ProcessRequest(CreatePurchaseOrderRequest request)
        {
            request.ItemLines.ForEach(async line =>
            {
                var product = await productRepository.GetProductByName(line);
                var startegy = availableStrategies.FirstOrDefault(s => s.ProductType.Any(x=>x.Equals(product.ProductType.Name)));
                if (startegy == null)
                {
                    throw new NotImplementedException("Requested strategy not found");
                }

                await startegy!.Process(request, product);
            });
        }
    }
}
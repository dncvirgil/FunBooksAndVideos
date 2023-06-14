using FunBooksAndVideos.Processor;
using FunBooksAndVideos.Processor.Model;
using FunBooksAndVideos.Service.Interfaces;
using FunBooksAndVideos.Service.Model;

namespace FunBooksAndVideos.Service
{
    internal class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderProcessor processor;

        public PurchaseOrderService(IPurchaseOrderProcessor processor)
        {
            this.processor = processor;
        }

        public async Task CreatePurchaseOrder(CreatePurchaseOrderRequestDto request)
        {
            var processorModel = new CreatePurchaseOrderRequest()
            {
                CustomerId = request.CustomerId,
                PurchaseOrderId = request.PurchaseOrderId,
                TotalPrice = request.TotalPrice,
                ItemLines = request.ItemLines
            };

            await processor.ProcessRequest(processorModel);
        }
    }
}

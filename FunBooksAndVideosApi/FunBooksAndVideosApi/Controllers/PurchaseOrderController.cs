using FunBooksAndVideos.Api.Model;
using FunBooksAndVideos.Service.Interfaces;
using FunBooksAndVideos.Service.Model;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderService purchaseOrderService;

        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService)
        {
            this.purchaseOrderService = purchaseOrderService;
        }

        // POST: api/PurchaseOrder
        /// <summary>
        /// Creates a new purchase order based on content of cart.
        /// </summary>
        /// <param name="CreatePurchaseOrderRequest">Purchase order request with all items.</param>
        /// <returns> </returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreatePurchaseOrder(CreatePurchaseOrderRequest request)
        {
            //validate

            //map to service model request
            var requestDto = new CreatePurchaseOrderRequestDto()
            {
                CustomerId = request.CustomerId,
                TotalPrice = request.TotalPrice,
                ItemLines = request.ItemLines
            };
            await purchaseOrderService.CreatePurchaseOrder(requestDto);
            return Ok();
        }
    }
}

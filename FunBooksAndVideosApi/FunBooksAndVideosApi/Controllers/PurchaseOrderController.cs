using FunBooksAndVideos.Api.Model;
using FunBooksAndVideos.Service.Interfaces;
using FunBooksAndVideos.Service.Mapping;
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
            this.purchaseOrderService = purchaseOrderService ?? throw new ArgumentNullException(nameof(purchaseOrderService));
        }

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
            if (!IsValidPurchaseOrder(request))
            {
                return BadRequest();
            }

            await purchaseOrderService.CreatePurchaseOrder(request.ToDto());
            return Ok();
        }

        private static bool IsValidPurchaseOrder(CreatePurchaseOrderRequest request)
        {
            return request is not null &&
                   request.CustomerId > 0 &&
                   request.TotalPrice > 0 &&
                   request.ItemLines != null &&
                   request.ItemLines.Any();
        }
    }
}

using FunBooksAndVideos.Api.Model;
using FunBooksAndVideos.Service.Model;

namespace FunBooksAndVideos.Service.Mapping
{
    public static class RequestToDto
    {
        public static CreatePurchaseOrderRequestDto ToDto(this CreatePurchaseOrderRequest request)
        {
            return new CreatePurchaseOrderRequestDto
            {
                CustomerId = request.CustomerId,
                TotalPrice = request.TotalPrice,
                ItemLines = request.ItemLines
            };
        }
    }
}

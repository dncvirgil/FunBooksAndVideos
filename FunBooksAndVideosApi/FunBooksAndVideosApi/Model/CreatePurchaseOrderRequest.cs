namespace FunBooksAndVideos.Api.Model
{
    public class CreatePurchaseOrderRequest
    {
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<string> ItemLines { get; set;}
    }
}

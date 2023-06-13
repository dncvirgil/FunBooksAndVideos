namespace FunBooksAndVideos.Data.Entities
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}

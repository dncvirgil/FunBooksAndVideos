namespace FunBooksAndVideos.Data.Entities
{
    public class OrderItems
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual Product Product { get; set; }
    }
}

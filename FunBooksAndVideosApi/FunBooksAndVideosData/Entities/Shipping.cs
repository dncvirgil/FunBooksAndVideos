namespace FunBooksAndVideos.Data.Entities
{
    public class Shipping
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PurchaseOrderId { get; set; }
        public string Address { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}

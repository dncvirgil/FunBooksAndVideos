namespace FunBooksAndVideos.Data.Entities
{
    public class Shipping
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PurchaseOrderId { get; set; }
        public int AddressId { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual Address Address { get; set; }
    }
}

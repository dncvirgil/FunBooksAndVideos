namespace FunBooksAndVideos.Domain
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
    }
}

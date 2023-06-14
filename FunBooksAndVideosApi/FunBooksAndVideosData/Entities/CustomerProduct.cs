namespace FunBooksAndVideos.Data.Entities
{
    public class CustomerProduct
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}

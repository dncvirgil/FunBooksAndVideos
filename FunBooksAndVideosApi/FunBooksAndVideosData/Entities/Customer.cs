namespace FunBooksAndVideos.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }

        //we could have a separate address table so customers could have multiple delivery addresses
        public string BillingAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public virtual User User { get; set; }
    }
}

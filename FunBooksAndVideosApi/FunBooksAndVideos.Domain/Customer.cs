
namespace FunBooksAndVideos.Domain
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string? BillingAddress { get; set; }
        public string? DeliveryAddress { get; set; }
    }
}

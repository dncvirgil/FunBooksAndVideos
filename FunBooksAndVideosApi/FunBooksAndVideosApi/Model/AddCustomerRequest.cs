namespace FunBooksAndVideos.Api.Model
{
    public class AddCustomerRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? BillingAddress { get; set; }
        public string? DeliveryAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

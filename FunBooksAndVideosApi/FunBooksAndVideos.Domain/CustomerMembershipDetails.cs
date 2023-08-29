namespace FunBooksAndVideos.Domain
{
    public class CustomerMembershipDetails
    {
        public string MembershipTypeName { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

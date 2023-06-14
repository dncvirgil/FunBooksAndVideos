namespace FunBooksAndVideos.Data.Entities
{
    public class CustomerMembership
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int MembershipTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual MembershipType MembershipType { get; set; }

    }
}

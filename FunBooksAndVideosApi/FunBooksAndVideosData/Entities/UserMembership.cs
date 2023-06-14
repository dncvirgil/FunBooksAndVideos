namespace FunBooksAndVideos.Data.Entities
{
    public class UserMembership
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MembershipTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual User User { get; set; }
        public virtual MembershipType MembershipType { get; set; }

    }
}

﻿namespace FunBooksAndVideos.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int MembershipTypeId { get; set; }
        public virtual MembershipType MembershipType { get; set; }
    }
}

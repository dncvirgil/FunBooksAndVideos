using FunBooksAndVideos.Data;
using FunBooksAndVideos.Data.Entities;

namespace FunBooksAndVideos.IntegrationTests
{
    public static class Utilities
    {
        public static void InitializeDbForTests(BookAndVideoContext db)
        {
            db.MembershipTypes.AddRange(GetMembershipSeedingData());
            db.ProductTypes.AddRange(GetProductTypeSeedingData());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(BookAndVideoContext db)
        {
            db.MembershipTypes.RemoveRange(db.MembershipTypes);
            db.ProductTypes.RemoveRange(db.ProductTypes);

            InitializeDbForTests(db);
        }

        public static List<MembershipType> GetMembershipSeedingData()
        {
            return new List<MembershipType>()
            {
                new MembershipType(){ Name ="Book Club Membership" },
                new MembershipType(){ Name ="Video Club Membership" },
                new MembershipType(){ Name ="Premium Club Membership" }
            };
        }

        public static List<ProductType> GetProductTypeSeedingData()
        {
            return new List<ProductType>()
            {
                new ProductType(){ Name ="Book" },
                new ProductType(){ Name ="eBook" },
                new ProductType(){ Name ="Video" },
                new ProductType(){ Name ="Membership" }
            };
        }
    }
}

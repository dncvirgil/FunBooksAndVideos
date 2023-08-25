using FunBooksAndVideos.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Data
{
    public class BookAndVideoContext : DbContext
    {
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerMembership> CustomerMembership { get; set; }
        public DbSet<CustomerProduct> CustomerProduct { get; set; }

        public BookAndVideoContext(DbContextOptions<BookAndVideoContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PurchaseOrder>().Property(p => p.TotalPrice).HasPrecision(18, 2);
            modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(18, 2);
            modelBuilder.Entity<OrderItems>().Property(p => p.TotalPrice).HasPrecision(18, 2);

            modelBuilder.Entity<Shipping>()
                    .HasOne(e => e.PurchaseOrder)
                    .WithMany()
                    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductType>().HasData(
                    new ProductType() { Id = 1, Name = "Book"},
                    new ProductType() { Id = 2, Name = "Video" },
                    new ProductType() { Id = 3, Name = "eBook" },
                    new ProductType() { Id = 4, Name = "Membership" });

            modelBuilder.Entity<MembershipType>().HasData(
                    new MembershipType() { Id = 1, Name = "Book Club Membership" },
                    new MembershipType() { Id = 2, Name = "Video Club Membership" },
                    new MembershipType() { Id = 3, Name = "Premium Club Membership" });

            modelBuilder.Entity<Product>().HasData(
                    new Product() { Id = 1, Name = "Video \"Comprehensive First Aid Training\"", Description= "Video description", Price = 10, Url = "video url", ProductTypeId = 2},
                    new Product() { Id = 2, Name = "eBook \"The Girl on the train\"", Description = "eBook description", Price = 16, Url = "ebook url", ProductTypeId = 3 },
                    new Product() { Id = 3, Name = "Book \"The Girl on the train\"", Description = "Book description", Price = 15, Url = "book url", ProductTypeId = 1 },
                    new Product() { Id = 4, Name = "Book Club Membership", Description = "Book Club description", Price = 5, Url = "book memebership url", ProductTypeId = 4 },
                    new Product() { Id = 5, Name = "Video Club Membership", Description = "Video Club description", Price = 5, Url = "video memebership url", ProductTypeId = 4 },
                    new Product() { Id = 6, Name = "Premium Club Membership", Description = "Premium Club description", Price = 8, Url = "premium memebership url", ProductTypeId = 4 });
        }
    }
}

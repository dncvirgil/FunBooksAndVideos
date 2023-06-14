using FunBooksAndVideos.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Xml;

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
        public DbSet<Address> Address { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<UserMembership> UserMembership { get; set; }
        public DbSet<UserProduct> UserProduct { get; set; }

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

            modelBuilder.Entity<Shipping>()
                    .HasOne(e => e.Address)
                    .WithMany()
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

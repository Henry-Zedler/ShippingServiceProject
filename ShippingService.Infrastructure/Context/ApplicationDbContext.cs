using ShippingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ShippingService.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Package> Packages { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Address>().Property(e => e.Line1).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Address>().Property(e => e.City).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Package>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Package>().Property(e => e.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Package>().Property(e => e.Description).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Package>().Property(e => e.Seller).IsRequired().HasMaxLength(100);
        }
    }
}

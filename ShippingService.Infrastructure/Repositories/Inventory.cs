using ShippingService.Application.Interfaces;
using ShippingService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using ShippingService.Domain.Entities;

namespace ShippingService.Infrastructure.Repositories
{
    public class Inventory : IInventory
    {
        private readonly ApplicationDbContext context;
        public Inventory(IDbContextFactory<ApplicationDbContext> factory)
        {
            context = factory.CreateDbContext();
        }

        public async Task AddAsync(Address address)
        {
            context.Addresses.Add(address);
            await context.SaveChangesAsync();
        }

        public async Task AddAsync(Package package)
        {
            context.Packages.Add(package);
            await context.SaveChangesAsync();
        }

        public Task<List<Package>> GetAllPackagesAsync()
        {
            var packs = context.Packages.ToListAsync();
            return packs;
        }

        public Task<List<Address>> GetAllAddressesAsync()
        {
            var addresses = context.Addresses.ToListAsync();
            return addresses;
        }
    }
}

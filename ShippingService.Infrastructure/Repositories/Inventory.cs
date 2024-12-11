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

        public Task<List<Package>> PackageNameSearchAsync(string s)
        {
            if (s is not null)
            {
                var packs = context.Packages.Where(x => x.Name.Contains(s)).OrderBy(x => x.Name).ToListAsync();
                return packs;
            }
            else
            {
                var packs = context.Packages.ToListAsync();
                return packs;
            }
        }

        public Task<List<Address>> GetAllAddressesAsync()
        {
            var addresses = context.Addresses.ToListAsync();
            return addresses;
        }
        public async Task<Package?> GetPackageByIdAsync(int id)
        {
            var package = await context.Packages.FirstOrDefaultAsync(x => x.Id == id);
            return package;
        }
        public async Task<Address?> GetAddressByIdAsync(int aid)
        {
            var address1 = await context.Addresses.FirstOrDefaultAsync(x => x.Id == aid);
            return address1;
        }
        public async Task UpdateAsync(Address address)
        {
            context.Entry(address).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Package package)
        {
            context.Entry(package).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteByPackageIdAsync(int id)
        {
            var package = await GetPackageByIdAsync(id);
            if (package != null)
            {
                context.Packages.Remove(package);
                await context.SaveChangesAsync();
            }
        }
    }
}

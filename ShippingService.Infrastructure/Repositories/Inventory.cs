using ShippingService.Application.Interfaces;
using ShippingService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using ShippingService.Domain.Entities;
using System;
using ShippingService.Domain.Enums;

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
            context.PackEvents.Add(new PackEvent() { PackId = package.Id, Action = (PackAction)0 });
            await context.SaveChangesAsync();
        }

        public async Task AddAsync(PackEvent packevent)
        {
            context.PackEvents.Add(packevent);
            await context.SaveChangesAsync();
        }

        public Task<List<Package>> GetAllPackagesAsync()
        {
            var packs = context.Packages.ToListAsync();
            return packs;
        }

        public Task<List<PackEvent>> GetAllPackEventsAsync()
        {
            var packevents = context.PackEvents.ToListAsync();
            return packevents;
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

        public Task<List<Package>> PackageDescriptionSearchAsync(string s)
        {
            if (s is not null)
            {
                var packs = context.Packages.Where(x => x.Description.Contains(s)).OrderBy(x => x.Description).ToListAsync();
                return packs;
            }
            else
            {
                var packs = context.Packages.ToListAsync();
                return packs;
            }
        }

        public Task<List<Package>> PackageSellerSearchAsync(string s)
        {
            if (s is not null)
            {
                var packs = context.Packages.Where(x => x.Seller.Contains(s)).OrderBy(x => x.Seller).ToListAsync();
                return packs;
            }
            else
            {
                var packs = context.Packages.ToListAsync();
                return packs;
            }
        }

        public Task<List<PackEvent>> PackEventWithActionAsync(int actionId)
        {
            var packevents = context.PackEvents.Where(x => x.Action.Equals(actionId)).ToListAsync();
            return packevents;
        }
        public Task<List<PackEvent>> PackEventWithPackIdAsync(int packId)
        {
            var packevents = context.PackEvents.Where(x => x.PackId.Equals(packId)).OrderBy(x => x.PackId).ToListAsync();
            return packevents;
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
            //context.PackEvents.Add(new PackEvent() { PackId = package.Id, Action = (PackAction)1 });
            await context.SaveChangesAsync();
        }

        public async Task DeleteByPackageIdAsync(int id)
        {
            var package = await GetPackageByIdAsync(id);
            if (package != null)
            {
                context.Packages.Remove(package);
                context.PackEvents.Add(new PackEvent() { PackId = package.Id, Action = (PackAction)5 });
                await context.SaveChangesAsync();
            }
        }

        public async Task ClearPackageHistory()
        {
            context.PackEvents.RemoveRange(context.PackEvents);
            await context.SaveChangesAsync();
        }
    }
}

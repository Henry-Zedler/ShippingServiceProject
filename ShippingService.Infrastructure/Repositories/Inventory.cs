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
    }
}

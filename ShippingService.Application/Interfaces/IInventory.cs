using ShippingService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingService.Application.Interfaces
{
    public interface IInventory
    {

        Task AddAsync(Address address);
        Task AddAsync(Package package);

        Task<List<Package>> GetAllPackagesAsync();
        Task<List<Address>> GetAllAddressesAsync();
    }
}

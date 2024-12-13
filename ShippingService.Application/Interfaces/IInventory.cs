using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShippingService.Domain.Entities;

namespace ShippingService.Application.Interfaces
{
    public interface IInventory
    {

        Task AddAsync(Address address);
        Task AddAsync(Package package);
        Task AddAsync(PackEvent packEvent);

        Task<List<Package>> GetAllPackagesAsync();
        Task<List<Address>> GetAllAddressesAsync();
        Task<List<PackEvent>> GetAllPackEventsAsync();

        Task<List<Package>> PackageNameSearchAsync(string s);
        Task<List<Package>> PackageDescriptionSearchAsync(string s);
        Task<List<Package>> PackageSellerSearchAsync(string s);

        Task<List<PackEvent>> PackEventWithActionAsync(int actionId);
        Task<List<PackEvent>>PackEventWithPackIdAsync(int packId);

        Task<Package?> GetPackageByIdAsync(int id);
        Task<Address?> GetAddressByIdAsync(int aid);

        Task UpdateAsync(Address address);
        Task UpdateAsync(Package package);

        Task ClearPackageHistory();

        Task DeletePackageByIdAsync(int id);
        Task DeleteAddressByIdAsync(int id);
    }
}

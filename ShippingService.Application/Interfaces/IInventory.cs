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

        Task<List<Package>> GetAllPackagesAsync();
        
        Task<List<Address>> GetAllAddressesAsync();
        Task<List<Package>> PackageNameSearchAsync(string s);
        Task<List<Package>> PackageDescriptionSearchAsync(string s);
        Task<List<Package>> PackageSellerSearchAsync(string s);

        Task<Package?> GetPackageByIdAsync(int id);
        //Task<Book?> GetByIdAsync(int id);
        Task<Address?> GetAddressByIdAsync(int aid);
        Task UpdateAsync(Address address);
        Task UpdateAsync(Package package);
        Task DeleteByPackageIdAsync(int id);
    }
}

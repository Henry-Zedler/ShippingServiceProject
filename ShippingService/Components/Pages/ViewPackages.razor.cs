using ShippingService.Domain.Entities;

namespace ShippingService.Components.Pages
{
    public partial class ViewPackages
    {
        private List<Package>? packages;

        protected override async Task OnInitializedAsync()
        {
            packages = await Inventory.GetAllPackagesAsync();
        }
    }
}

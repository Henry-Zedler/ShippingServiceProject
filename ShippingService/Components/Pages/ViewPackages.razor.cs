using ShippingService.Domain.Entities;

namespace ShippingService.Components.Pages
{
    public partial class ViewPackages
    {
        private List<Package>? packages;

        protected override async Task OnInitializedAsync()
        {
            packages = await Repository.GetAllPackagesAsync();
        }

        protected async Task Search(Microsoft.AspNetCore.Components.ChangeEventArgs args)
        {
            if (args is not null)
            {
                var query = (string)args.Value;
                packages = await Repository.PackageNameSearchAsync(query);
            }
            else
            {
                packages = await Repository.GetAllPackagesAsync();
            }
            StateHasChanged();
        }
    }
}

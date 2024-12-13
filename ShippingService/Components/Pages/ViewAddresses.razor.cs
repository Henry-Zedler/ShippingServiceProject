using ShippingService.Domain.Entities;

namespace ShippingService.Components.Pages
{
    public partial class ViewAddresses
    {
        private List<Address>? addresses;

        protected override async Task OnInitializedAsync()
        {
            addresses = await Repository.GetAllAddressesAsync();
        }
    }
}
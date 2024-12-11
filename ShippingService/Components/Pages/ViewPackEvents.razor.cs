using ShippingService.Domain.Entities;

namespace ShippingService.Components.Pages
{
    public partial class ViewPackEvents
    {
        private List<PackEvent>? PackEvents { get; set; }

        protected override async Task OnInitializedAsync()
        {
            PackEvents = await Inventory.GetAllPackEventsAsync();
        }
    }
}

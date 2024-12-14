using System.ComponentModel;

namespace ShippingService.Domain.Enums
{
    public enum Status
    {
        [Description("Not Started")]
        Not_Started,
        [Description("Processing Order")]
        Processing_Order,
        [Description("Shipping")]
        Shipping,
        [Description("Delivered")]
        Delivered
    }
}

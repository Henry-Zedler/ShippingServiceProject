using System.ComponentModel;

namespace ShippingService.Domain.Enums
{
    public enum PackAction
    {
        [Description("Added")]
        Added=0,
        [Description("Edited")]
        Edited =1,
        [Description("Processing started")]
        Processing =2,
        [Description("Shipping started")]
        Shipping_Started =3,
        [Description("Shipping completed")]
        Shipping_Completed =4,
        [Description("Deleted")]
        Deleted =5
    }
}
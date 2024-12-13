using ShippingService.Domain.Enums;
using System;
using System.ComponentModel;

namespace ShippingService.Application.Helpers
{
    public static class EnumHelper
    {
        public static string GetEnumDescription(Status status)
        {
            var field = status.GetType().GetField(status.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attribute?.Description ?? status.ToString(); // Fallback to the enum value if no description is found
        }
    }
}

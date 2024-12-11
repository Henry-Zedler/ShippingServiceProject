using ShippingService.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ShippingService.Domain.Entities
{
    public class PackEvent
    {
        [Key]
        public int Id { get; set; }
        public int PackId { get; set; }
        public PackAction Action { get; set; }
    }
}

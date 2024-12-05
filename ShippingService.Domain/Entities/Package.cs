using ShippingService.Domain.Enums;
using System.ComponentModel.DataAnnotations;


namespace ShippingService.Domain.Entities
{
    public class Package
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }


        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }


        [Required]
        [MaxLength(100)]
        public string? Seller { get; set; }

        public Address? Address { get; set; }

        public Status Status { get; set; }
    }
}

using ShippingService.Domain.Enums;
using System.ComponentModel.DataAnnotations;


namespace ShippingService.Domain.Entities
{
    public class Package
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a name")]
        [MaxLength(100)]
        public string? Name { get; set; }


        [Required(ErrorMessage = "Please provide a description")]
        [MaxLength(100)]
        public string? Description { get; set; }


        [Required(ErrorMessage = "Please provide a description")]
        [MaxLength(100)]
        public string? Seller { get; set; }

        public Address? Address { get; set; }

        public Status Status { get; set; }
    }
}

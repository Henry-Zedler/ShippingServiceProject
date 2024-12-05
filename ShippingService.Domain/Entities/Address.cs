﻿using ShippingService.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ShippingService.Domain.Entities
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Line1 { get; set; }

        public string? Line2 { get; set; }

        [Required]
        [MaxLength(100)]
        public string? City { get; set; }

        public State State { get; set; }

        public int Zip { get; set; }
    }
}

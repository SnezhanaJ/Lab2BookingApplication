﻿using System.ComponentModel.DataAnnotations;

namespace LabBookingApp.Domain.Domain
{
    public class Apartment : BaseEntity
    {
        [Required]
        public string ApartmentName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price_per_night { get; set; }
        [Required]
        public double Rating { get; set; }
    }
}

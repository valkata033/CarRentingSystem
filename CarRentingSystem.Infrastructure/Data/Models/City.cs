﻿using CarRentingSystem.Infrastructure.Data.GlobalConstants;
using System.ComponentModel.DataAnnotations;

namespace CarRentingSystem.Infrastructure.Data.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.City.CityNameMaxValue)]
        public string Name { get; set; } = null!;

        public IEnumerable<Showroom> Showrooms { get; set; } = new List<Showroom>();

    }
}

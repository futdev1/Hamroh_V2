using Hamroh_V2.Domain.Entities.Drivers;
using Hamroh_V2.Service.DTOs.DriverDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hamroh_V2.Service.DTOs.DriverAdDTO
{
    public class DriverAdForCreationDto
    {
        [Required]
        public string Qayerdan { get; set; }

        [Required]
        public string Qayerga { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Summa { get; set; }

        [Required]
        public string Amenities { get; set; }

        [Required]
        public IList<Driver> DriverData { get; set; }
    }
}

using System;
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

        public string Comment { get; set; }

        [Required]
        public long DriverId { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Hamroh_V2.Service.DTOs.DriverDTO
{
    public class DriverForCreationDto
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public IFormFile CarImage { get; set; }

        [Required]
        public IFormFile DriverImage { get; set; }

        [Required]
        public string CarName { get; set; }
    }
}

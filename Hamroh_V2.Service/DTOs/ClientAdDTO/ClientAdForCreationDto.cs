using System;
using System.ComponentModel.DataAnnotations;

namespace Hamroh_V2.Service.DTOs.ClientAdDTO
{
    public class ClientAdForCreationDto
    {
        [Required]
        public string Qayerdan { get; set; }

        [Required]
        public string Qayerga { get; set; }

        [Required]
        public int PeopleCount { get; set; }

        [Required]
        public string Summa { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Comment { get; set; }

        [Required]
        public long ClientId { get; set; }
    }
}

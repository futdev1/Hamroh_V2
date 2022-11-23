using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

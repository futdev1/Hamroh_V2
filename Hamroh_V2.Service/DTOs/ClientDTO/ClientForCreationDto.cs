using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamroh_V2.Service.DTOs.ClientDTO
{
    public class ClientForCreationDto
    {
        [Required]
        public string Qayerdan { get; set; }

        [Required]
        public string Qayerga { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int PeopleCount { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Summa { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string Comment { get; set; }
    }
}

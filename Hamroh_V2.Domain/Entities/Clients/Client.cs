using System;
using System.ComponentModel.DataAnnotations;

namespace Hamroh_V2.Domain.Entities.Clients
{
    public class Client
    {
        [Required]
        public long Id { get; set; }

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

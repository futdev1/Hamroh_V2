using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamroh_V2.Domain.Entities.Drivers
{
    public class Driver
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string CarImage { get; set; }

        public string DriverImage { get; set; }

        [Required]
        public string CarName { get; set; }
    }
}

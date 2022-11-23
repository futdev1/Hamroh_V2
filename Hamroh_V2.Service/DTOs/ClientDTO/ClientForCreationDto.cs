using System.ComponentModel.DataAnnotations;

namespace Hamroh_V2.Service.DTOs.ClientDTO
{
    public class ClientForCreationDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}

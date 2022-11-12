using Hamroh_V2.Service.DTOs.ClientDTO;
using Hamroh_V2.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hamroh_V2.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClientsController :ControllerBase
    {
        private readonly IClientService clientService;

        public ClientsController(IClientService _clientService)
        {
            clientService = _clientService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(ClientForCreationDto clientDto)
        {
            return Ok(await clientService.CreateAsync(clientDto));
        }
    }
}

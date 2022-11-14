using Hamroh_V2.Domain.Entities.Clients;
using Hamroh_V2.Service.DTOs.ClientDTO;
using Hamroh_V2.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Hamroh_V2.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientsController(IClientService _clientService)
        {
            clientService = _clientService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromForm] ClientForCreationDto clientDto)
        {
            return Ok(await clientService.CreateAsync(clientDto));
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync([FromRoute] long id)
        { 
            return await clientService.DeleteAsync(p => p.Id == id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetAsync([FromRoute] long id)
        {
            return await clientService.GetAsync(p => p.Id == id);
        }

        [HttpGet]
        public IQueryable<Client> GetAllAsync(long? id)
        {
            if (id != null)
                return clientService.GetAllAsync(p => p.Id > id);
            else
                return clientService.GetAllAsync(null);
        }

        [HttpPut]
        public async Task<ActionResult<Client>> UpdateAsync(long id, ClientForCreationDto clientDto)
        {
            return await clientService.UpdateAsync(id, clientDto);
        }
    }
}

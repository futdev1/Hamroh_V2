using Hamroh_V2.Domain.Commons;
using Hamroh_V2.Domain.Entities.Clients;
using Hamroh_V2.Domain.Enums;
using Hamroh_V2.Service.DTOs.ClientDTO;
using Hamroh_V2.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<ActionResult<BaseResponse<Client>>> CreateAsync([FromForm] ClientForCreationDto clientDto)
        {
            var result = await clientService.CreateAsync(clientDto);
            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteAsync([FromRoute] long id)
        {
            var result = await clientService.DeleteAsync(p => p.Id == id && p.State != ItemState.Deleted);
            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<ClientForGetDto>>> GetAsync([FromRoute] long id)
        {
            var result = await clientService.GetAsync(p => p.Id == id);
            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public ActionResult<BaseResponse<IEnumerable<Client>>> GetAll([FromQuery] long? id)
        {
            if (id != null)
            {
                var result = clientService.GetAll(p => p.Id > id);
                return StatusCode(result.Code ?? result.Error.Code.Value, result);
            }

            else
            {
                var results = clientService.GetAll(null);
                return StatusCode(results.Code ?? results.Error.Code.Value, results);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Client>>> UpdateAsync(long id, ClientForCreationDto clientDto)
        {
            var result = await clientService.UpdateAsync(id, clientDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }
    }
}

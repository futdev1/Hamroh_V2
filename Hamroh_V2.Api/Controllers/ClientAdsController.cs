using Hamroh_V2.Domain.Commons;
using Hamroh_V2.Domain.Entities.ClientAds;
using Hamroh_V2.Service.DTOs.ClientAdDTO;
using Hamroh_V2.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hamroh_V2.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClientAdsController : ControllerBase
    {
        private IClientAdService clientAdService;

        public ClientAdsController(IClientAdService clientAdService)
        {
            this.clientAdService = clientAdService;
        }

        [HttpPost]

        public async Task<ActionResult<BaseResponse<ClientAd>>> CreateAsync([FromForm] ClientAdForCreationDto clientAdDto)
        {
            var result = await clientAdService.CreateAsync(clientAdDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public ActionResult<BaseResponse<IEnumerable<ClientAd>>> GetAll([FromQuery] long? id)
        {
            if (id != null)
            {
                var result = clientAdService.GetAll(p => p.Id > id);
                return StatusCode(result.Code ?? result.Error.Code.Value, result);
            }

            else
            {
                var result = clientAdService.GetAll(null);
                return StatusCode(result.Code ?? result.Error.Code.Value, result);
            }
        }
    }
}

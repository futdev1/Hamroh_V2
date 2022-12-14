using Hamroh_V2.Domain.Commons;
using Hamroh_V2.Domain.Configurations;
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

        //Constructor
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
        public ActionResult<BaseResponse<IEnumerable<ClientAd>>> GetAll([FromQuery] PaginationParameters? parameters = null)
        {
            var result = clientAdService.GetAll(null, parameters);
            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteAsync([FromRoute] long id)
        {
            var result = await clientAdService.DeleteAsync(p => p.Id == id);
            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<ClientAd>>> GetAsync([FromRoute] long id)
        {
            var result = await clientAdService.GetAsync(p => p.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse<ClientAd>>> UpdateAsync(long id, ClientAdForCreationDto cliendAdDto)
        {
            var result = await clientAdService.UpdateAsync(id, cliendAdDto);
            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }
    }
}

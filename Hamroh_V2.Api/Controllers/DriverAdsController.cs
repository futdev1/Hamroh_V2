using Hamroh_V2.Domain.Commons;
using Hamroh_V2.Domain.Entities.DriverAds;
using Hamroh_V2.Service.DTOs.DriverAdDTO;
using Hamroh_V2.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hamroh_V2.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DriverAdsController : ControllerBase
    {
        private IDriverAdService driverAdService;

        public DriverAdsController(IDriverAdService driverAdService)
        {
            this.driverAdService = driverAdService;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<DriverAd>>> CreateAsync([FromForm] DriverAdForCreationDto driverAdDto)
        {
            var result = await driverAdService.CreateAsync(driverAdDto);
            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<DriverAd>>> GetAsync(long id)
        {
            var result = await driverAdService.GetAsync(p => p.Id == id);
            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public ActionResult<BaseResponse<IEnumerable<DriverAd>>> GetAll(long? id)
        {
            if(id == null)
            {
                var result = driverAdService.GetAll(null);
                return StatusCode(result.Code ?? result.Error.Code.Value, result);
            }

            else
            {
                var result = driverAdService.GetAll(p => p.Id > id);
                return StatusCode(result.Code ?? result.Error.Code.Value); 
            }
        }

        [HttpDelete]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteAsync(long id)
        {
            var result = await driverAdService.DeleteAsync(p => p.Id == id);
            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse<DriverAd>>> UpdateAsync(long id, DriverAdForCreationDto driverAdDto)
        {
            var result = await driverAdService.UpdateAsync(id, driverAdDto);
            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }
    }
}

using Hamroh_V2.Domain.Commons;
using Hamroh_V2.Domain.Configurations;
using Hamroh_V2.Domain.Entities.Drivers;
using Hamroh_V2.Service.DTOs.DriverDTO;
using Hamroh_V2.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hamroh_V2.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DriversController : ControllerBase
    {
        private IDriverService driverService;

        public DriversController(IDriverService driverService)
        {
            this.driverService = driverService;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Driver>>> CreateAsync([FromForm] DriverForCreationDto driverDto)
        {
            var result = await driverService.CreateAsync(driverDto);
            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetAsync([FromForm] long id)
        {
            return await driverService.GetAsync(p => p.Id == id);
        }

        [HttpGet]
        public ActionResult<BaseResponse<IEnumerable<Driver>>> GetAll([FromQuery] PaginationParameters parameters = null)
        {
            BaseResponse<IEnumerable<Driver>> result = driverService.GetAll(null, parameters);
            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteAsync(long id)
        {
            var result = await driverService.DeleteAsync(p => p.Id == id);
            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut]
        public async Task<ActionResult<Driver>> UpdateAsync(long id, DriverForCreationDto driverDto)
        {
            return await driverService.UpdateAsync(id, driverDto);
            ;
        }
    }
}

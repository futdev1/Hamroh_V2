using Hamroh_V2.Domain.Commons;
using Hamroh_V2.Domain.Entities.Drivers;
using Hamroh_V2.Service.DTOs.DriverDTO;
using Hamroh_V2.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Driver> GetAll(long id)
        {
            return driverService.GetAll(p => p.Id > id);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAsync(long id)
        {
            return await driverService.DeleteAsync(p => p.Id == id);
        }

        [HttpPut]
        public async Task<ActionResult<Driver>> UpdateAsync(long id, DriverForCreationDto driverDto)
        {
            return await driverService.UpdateAsync(id, driverDto);
;        }
    }
}

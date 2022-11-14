using Hamroh_V2.Domain.Entities.Drivers;
using Hamroh_V2.Service.DTOs.DriverDTO;
using Hamroh_V2.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<Driver>> CreateAsync([FromForm] DriverForCreationDto driverDto)
        {
            return Ok(await driverService.CreateAsync(driverDto));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetAsync([FromForm] long id)
        {
            return await driverService.GetAsync(p => p.Id == id);
        }
    }
}

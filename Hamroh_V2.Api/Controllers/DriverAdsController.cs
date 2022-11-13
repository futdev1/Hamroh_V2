using Hamroh_V2.Service.DTOs.DriverAdDTO;
using Hamroh_V2.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult> CreateAsync(DriverAdForCreationDto driverAdForCreationDto)
        {
            return Ok(await driverAdService.CreateAsync(driverAdForCreationDto));
        }
    }
}

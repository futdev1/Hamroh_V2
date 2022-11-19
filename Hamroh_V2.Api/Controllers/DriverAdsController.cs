using Hamroh_V2.Domain.Entities.DriverAds;
using Hamroh_V2.Domain.Entities.Drivers;
using Hamroh_V2.Service.DTOs.DriverAdDTO;
using Hamroh_V2.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public async Task<ActionResult<DriverAd>> GetAsync(long id)
        {
            return await driverAdService.GetAsync(p => p.Id == id);
        }

        [HttpGet]
        public IEnumerable<DriverAd> GetAll(long id)
        {
            return driverAdService.GetAll(p => p.Id > id);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAsync(long id)
        {
            return await driverAdService.DeleteAsync(p => p.Id == id);
        }

        [HttpPut]
        public async Task<ActionResult<DriverAd>> UpdateAsync(long id, DriverAdForCreationDto driverAdDto)
        {
            return await driverAdService.UpdateAsync(id, driverAdDto);
        }
    }
}

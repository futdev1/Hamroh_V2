using Hamroh_V2.Data.IRepositories;
using Hamroh_V2.Domain.Entities.DriverAds;
using Hamroh_V2.Domain.Entities.Drivers;
using Hamroh_V2.Service.DTOs.DriverAdDTO;
using Hamroh_V2.Service.DTOs.DriverDTO;
using Hamroh_V2.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hamroh_V2.Service.Services
{
    public class DriverAdService : IDriverAdService
    {
        internal IDriverAdRepository driverAdRepository;

        public DriverAdService(IDriverAdRepository driverAdRepository)
        {
            this.driverAdRepository = driverAdRepository;
        }

        public async Task<DriverAd> CreateAsync(DriverAdForCreationDto driverAdDto)
        {
            DriverAd driverAd = new DriverAd()
            {
                Qayerdan = driverAdDto.Qayerdan,
                Qayerga = driverAdDto.Qayerga,
                Summa = driverAdDto.Summa,
                Date = driverAdDto.Date,
                Amenities = driverAdDto.Amenities,
            };

            return await driverAdRepository.CreateAsync(driverAd);
        }

        public async Task<bool> DeleteAsync(Expression<Func<DriverAd, bool>> pred)
        {
            return await driverAdRepository.DeleteAsync(pred);
        }

        public IEnumerable<DriverAd> GetAll(Expression<Func<DriverAd, bool>> pred)
        {
            return driverAdRepository.GetAll(pred);
        }

        public async Task<DriverAd> GetAsync(Expression<Func<DriverAd, bool>> pred)
        {
            return await driverAdRepository.GetAsync(pred); 
        }

        public async Task<DriverAd> UpdateAsync(long id, DriverAdForCreationDto driverAdDto)
        {
            DriverAd driverAd = await driverAdRepository.GetAsync(p => p.Id == id);
            if(driverAd != null)
            {
                driverAd.Qayerdan = driverAdDto.Qayerdan;
                driverAd .Qayerga = driverAdDto.Qayerga;
                driverAd.Summa = driverAdDto.Summa;
                driverAd.Date = driverAdDto.Date;
                driverAd.Amenities = driverAdDto.Amenities;
            }

            return await driverAdRepository.UpdateAsync(driverAd);
        }
    }
}

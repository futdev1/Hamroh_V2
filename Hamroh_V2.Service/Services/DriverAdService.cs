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
            IList<Driver> drivers = driverAdDto.DriverData;
            DriverAd driverAd = new DriverAd()
            {
                Qayerdan = driverAdDto.Qayerdan,
                Qayerga = driverAdDto.Qayerga,
                Summa = driverAdDto.Summa,
                Date = driverAdDto.Date,
                Amenities = driverAdDto.Amenities,
                DriverData = drivers
            };


            return await driverAdRepository.CreateAsync(driverAd);
        }

        public async Task<bool> DeleteAsync(Expression<Func<DriverAd, bool>> pred)
        {
            return await driverAdRepository.DeleteAsync(pred);
        }

        public IQueryable<DriverAd> GetAllAsync(Expression<Func<DriverAd, bool>> pred)
        {
            return driverAdRepository.GetAll(pred);
        }

        public async Task<DriverAd> GetAsync(Expression<Func<DriverAd, bool>> pred)
        {
            return await driverAdRepository.GetAsync(pred); 
        }

        public Task<DriverAd> UpdateAsync(DriverAd client)
        {
            return driverAdRepository.UpdateAsync(client);
        }
    }
}

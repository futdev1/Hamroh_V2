using Hamroh_V2.Data.IRepositories;
using Hamroh_V2.Domain.Entities.Drivers;
using Hamroh_V2.Service.DTOs.DriverDTO;
using Hamroh_V2.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hamroh_V2.Service.Services
{
    public class DriverService : IDriverService
    {
        internal IDriverRepository driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            this.driverRepository = driverRepository;
        }
        public async Task<Driver> CreateAsync(DriverForCreationDto driverDto)
        {
            var driver = new Driver()
            {
                FullName = driverDto.FullName,
                PhoneNumber = driverDto.PhoneNumber,
                //CarImage = driverDto.CarImage,
                //DriverImage = driverDto.DriverImage,
                CarName = driverDto.CarName,
            };

            return await driverRepository.CreateAsync(driver);
        }

        public async Task<bool> DeleteAsync(Expression<Func<Driver, bool>> pred)
        {
            return await driverRepository.DeleteAsync(pred);
        }

        public IEnumerable<Driver> GetAll(Expression<Func<Driver, bool>> pred = null)
        {
            return driverRepository.GetAll(pred);
        }

        public async Task<Driver> GetAsync(Expression<Func<Driver, bool>> pred)
        {
            return await driverRepository.GetAsync(pred);
        }

        public async Task<Driver> UpdateAsync(long id, DriverForCreationDto driverDto)
        {
            var driver = await driverRepository.GetAsync(p => p.Id == id);

            if(driver != null)
            {
                driver.FullName = driverDto.FullName;
                driver.PhoneNumber = driverDto.PhoneNumber;
                driver.CarName = driverDto.CarName;
                //driver.CarImage = driverDto.CarImage;
                //driver.DriverImage = driverDto.DriverImage;

            }


            return await driverRepository.UpdateAsync(driver);
        }
    }
}

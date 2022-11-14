using Hamroh_V2.Data.IRepositories;
using Hamroh_V2.Domain.Entities.Drivers;
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
                CarImage = driverDto.CarImage.ToString(),
                DriverImage = driverDto.DriverImage.ToString(),
                CarName = driverDto.CarName,
            };

            return await driverRepository.CreateAsync(driver);
        }

        public async Task<bool> DeleteAsync(Expression<Func<Driver, bool>> pred)
        {
            return await driverRepository.DeleteAsync(pred);
        }

        public IQueryable<Driver> GetAllAsync(Expression<Func<Driver, bool>> pred)
        {
            return driverRepository.GetAll(pred);
        }

        public async Task<Driver> GetAsync(Expression<Func<Driver, bool>> pred)
        {
            return await driverRepository.GetAsync(pred);
        }

        public Task<Driver> UpdateAsync(Driver client)
        {
            throw new NotImplementedException();
        }
    }
}

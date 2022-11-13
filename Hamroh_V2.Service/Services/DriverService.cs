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
        public Task<Driver> CreateAsync(DriverForCreationDto clientDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Expression<Func<Driver, bool>> pred)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Driver> GetAllAsync(Expression<Func<Driver, bool>> pred)
        {
            throw new NotImplementedException();
        }

        public Task<Driver> GetAsync(Expression<Func<Driver, bool>> pred)
        {
            throw new NotImplementedException();
        }

        public Task<Driver> UpdateAsync(Driver client)
        {
            throw new NotImplementedException();
        }
    }
}

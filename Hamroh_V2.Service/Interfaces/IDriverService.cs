using Hamroh_V2.Domain.Entities.Drivers;
using Hamroh_V2.Service.DTOs.DriverDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hamroh_V2.Service.Interfaces
{
    public interface IDriverService
    {
        Task<Driver> CreateAsync(DriverForCreationDto driverDto);

        Task<bool> DeleteAsync(Expression<Func<Driver, bool>> pred);

        IQueryable<Driver> GetAllAsync(Expression<Func<Driver, bool>> pred);

        Task<Driver> GetAsync(Expression<Func<Driver, bool>> pred);

        Task<Driver> UpdateAsync(Driver driverDto);
    }
}

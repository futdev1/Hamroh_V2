using Hamroh_V2.Domain.Commons;
using Hamroh_V2.Domain.Entities.Drivers;
using Hamroh_V2.Service.DTOs.DriverDTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hamroh_V2.Service.Interfaces
{
    public interface IDriverService
    {
        Task<BaseResponse<Driver>> CreateAsync(DriverForCreationDto driverDto);

        Task<bool> DeleteAsync(Expression<Func<Driver, bool>> pred);

        IEnumerable<Driver> GetAll(Expression<Func<Driver, bool>> pred = null);

        Task<Driver> GetAsync(Expression<Func<Driver, bool>> pred);

        Task<Driver> UpdateAsync(long id, DriverForCreationDto driverDto);

        Task<string> SaveFileAsync(Stream file, string fileName);
    }
}


using Hamroh_V2.Domain.Entities.DriverAds;
using Hamroh_V2.Service.DTOs.DriverAdDTO;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hamroh_V2.Service.Interfaces
{
    public interface IDriverAdService
    {
        Task<DriverAd> CreateAsync(DriverAdForCreationDto driverAdDto);

        Task<bool> DeleteAsync(Expression<Func<DriverAd, bool>> pred);

        IQueryable<DriverAd> GetAllAsync(Expression<Func<DriverAd, bool>> pred);

        Task<DriverAd> GetAsync(Expression<Func<DriverAd, bool>> pred);

        Task<DriverAd> UpdateAsync(long id, DriverAdForCreationDto client);
    }
}

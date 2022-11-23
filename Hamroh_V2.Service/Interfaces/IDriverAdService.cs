
using Hamroh_V2.Domain.Commons;
using Hamroh_V2.Domain.Entities.DriverAds;
using Hamroh_V2.Service.DTOs.DriverAdDTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hamroh_V2.Service.Interfaces
{
    public interface IDriverAdService
    {
        Task<BaseResponse<DriverAd>> CreateAsync(DriverAdForCreationDto driverAdDto);

        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<DriverAd, bool>> pred);

        BaseResponse<IEnumerable<DriverAd>> GetAll(Expression<Func<DriverAd, bool>> pred);

        Task<BaseResponse<DriverAd>> GetAsync(Expression<Func<DriverAd, bool>> pred);

        Task<BaseResponse<DriverAd>> UpdateAsync(long id, DriverAdForCreationDto client);
    }
}

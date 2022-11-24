using Hamroh_V2.Domain.Commons;
using Hamroh_V2.Domain.Configurations;
using Hamroh_V2.Domain.Entities.ClientAds;
using Hamroh_V2.Service.DTOs.ClientAdDTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hamroh_V2.Service.Interfaces
{
    public interface IClientAdService
    {
        Task<BaseResponse<ClientAd>> CreateAsync(ClientAdForCreationDto clientAdDto);

        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<ClientAd, bool>> pred);

        BaseResponse<IEnumerable<ClientAd>> GetAll(Expression<Func<ClientAd, bool>> pred, PaginationParameters parameters);

        Task<BaseResponse<ClientAd>> GetAsync(Expression<Func<ClientAd, bool>> pred);

        Task<BaseResponse<ClientAd>> UpdateAsync(long id, ClientAdForCreationDto clientAdDto);
    }
}

using AutoMapper;
using Hamroh_V2.Data.IRepositories;
using Hamroh_V2.Domain.Commons;
using Hamroh_V2.Domain.Entities.DriverAds;
using Hamroh_V2.Service.DTOs.DriverAdDTO;
using Hamroh_V2.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hamroh_V2.Service.Services
{
    public class DriverAdService : IDriverAdService
    {
        internal IDriverAdRepository driverAdRepository;
        internal IMapper mapper;
        internal IConfiguration config;

        public DriverAdService(IDriverAdRepository driverAdRepository, IMapper mapper, IConfiguration config)
        {
            this.driverAdRepository = driverAdRepository;
            this.mapper = mapper;
            this.config = config;
        }

        public async Task<BaseResponse<DriverAd>> CreateAsync(DriverAdForCreationDto driverAdDto)
        {
            BaseResponse<DriverAd> response = new BaseResponse<DriverAd>();

            DriverAd mappedDriverAd = mapper.Map<DriverAd>(driverAdDto);

            DriverAd result = await driverAdRepository.CreateAsync(mappedDriverAd);

            response.Data = result;

            return response;
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
            if (driverAd != null)
            {
                driverAd.Qayerdan = driverAdDto.Qayerdan;
                driverAd.Qayerga = driverAdDto.Qayerga;
                driverAd.Summa = driverAdDto.Summa;
                driverAd.Date = driverAdDto.Date;
                driverAd.Amenities = driverAdDto.Amenities;
            }

            return await driverAdRepository.UpdateAsync(driverAd);
        }
    }
}

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

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<DriverAd, bool>> pred)
        {
            BaseResponse<bool> response = new BaseResponse<bool>();

            DriverAd driverAd = await driverAdRepository.GetAsync(pred);

            if(driverAd == null)
            {
                response.Error = new ErrorResponse(404, "Driver ad not found!");
                return response;
            }

            driverAd.Delete(); 
            DriverAd result = await driverAdRepository.UpdateAsync(driverAd);

            response.Data = true;
            return response;
        }

        public BaseResponse<IEnumerable<DriverAd>> GetAll(Expression<Func<DriverAd, bool>> pred)
        {
            BaseResponse<IEnumerable<DriverAd>> response = new BaseResponse<IEnumerable<DriverAd>>();

            var result = driverAdRepository.GetAll(pred);

            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<DriverAd>> GetAsync(Expression<Func<DriverAd, bool>> pred)
        {
            BaseResponse<DriverAd> response = new BaseResponse<DriverAd>();

            var driverAd = await driverAdRepository.GetAsync(pred);

            if(driverAd == null)
            {
                response.Error = new ErrorResponse(404, "Driver ad not found");
                return response;
            }

            response.Data = driverAd;

            return response;
        }

        public async Task<BaseResponse<DriverAd>> UpdateAsync(long id, DriverAdForCreationDto driverAdDto)
        {
            BaseResponse<DriverAd> response = new BaseResponse<DriverAd>();

            var driverAd = await driverAdRepository.GetAsync(p => p.Id == id);
            
            if(driverAd == null)
            {
                response.Error = new ErrorResponse(404, "Driver ad not found!");
                return response;
            }

            driverAd.Qayerdan = driverAdDto.Qayerdan;
            driverAd.Qayerga = driverAdDto.Qayerga;
            driverAd.Summa = driverAdDto.Summa;
            driverAd.Date = driverAdDto.Date;
            driverAd.Amenities = driverAdDto.Amenities;
            driverAd.Comment = driverAdDto.Comment;
            driverAd.DriverId = driverAdDto.DriverId;

            response.Data = driverAd;

            return response;
        }
    }
}

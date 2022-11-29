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
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        private IConfiguration config;

        //Constructor
        public DriverAdService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.config = config;
        }

        /// <summary>
        /// The sectionthat stores data to the server
        /// </summary>
        /// <param name="driverAdDto"></param>
        /// <returns></returns>
        public async Task<BaseResponse<DriverAd>> CreateAsync(DriverAdForCreationDto driverAdDto)
        {
            BaseResponse<DriverAd> response = new BaseResponse<DriverAd>();

            DriverAd mappedDriverAd = mapper.Map<DriverAd>(driverAdDto);
            mappedDriverAd.Create();

            DriverAd result = await unitOfWork.DriverAds.CreateAsync(mappedDriverAd);

            response.Data = result;

            return response;
        }

        /// <summary>
        /// this is used to delete unnecessary data from the database
        /// </summary>
        /// <param name="pred"></param>
        /// <returns></returns>
        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<DriverAd, bool>> pred)
        {
            BaseResponse<bool> response = new BaseResponse<bool>();

            DriverAd driverAd = await unitOfWork.DriverAds.GetAsync(pred);

            if (driverAd == null)
            {
                response.Error = new ErrorResponse(404, "Driver ad not found!");
                return response;
            }

            driverAd.Delete();
            DriverAd result = await unitOfWork.DriverAds.UpdateAsync(driverAd);

            response.Data = true;
            return response;
        }

        /// <summary>
        /// We use it to get the necessary all information from the database
        /// </summary>
        /// <param name="pred"></param>
        /// <returns></returns>
        public BaseResponse<IEnumerable<DriverAd>> GetAll(Expression<Func<DriverAd, bool>> pred)
        {
            BaseResponse<IEnumerable<DriverAd>> response = new BaseResponse<IEnumerable<DriverAd>>();

            var result = unitOfWork.DriverAds.GetAll(pred);

            response.Data = result;

            return response;
        }

        /// <summary>
        /// We use it to get the necessary information from the database
        /// </summary>
        /// <param name="pred"></param>
        /// <returns></returns>
        public async Task<BaseResponse<DriverAd>> GetAsync(Expression<Func<DriverAd, bool>> pred)
        {
            BaseResponse<DriverAd> response = new BaseResponse<DriverAd>();

            var driverAd = await unitOfWork.DriverAds.GetAsync(pred);

            if (driverAd == null)
            {
                response.Error = new ErrorResponse(404, "Driver ad not found");
                return response;
            }

            response.Data = driverAd;

            return response;
        }

        /// <summary>
        /// This is used to change the data from the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="driverAdDto"></param>
        /// <returns></returns>
        public async Task<BaseResponse<DriverAd>> UpdateAsync(long id, DriverAdForCreationDto driverAdDto)
        {
            BaseResponse<DriverAd> response = new BaseResponse<DriverAd>();

            var driverAd = await unitOfWork.DriverAds.GetAsync(p => p.Id == id);

            if (driverAd == null)
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

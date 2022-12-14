using AutoMapper;
using Hamroh_V2.Data.IRepositories;
using Hamroh_V2.Domain.Commons;
using Hamroh_V2.Domain.Configurations;
using Hamroh_V2.Domain.Entities.ClientAds;
using Hamroh_V2.Domain.Enums;
using Hamroh_V2.Service.DTOs.ClientAdDTO;
using Hamroh_V2.Service.Extensions;
using Hamroh_V2.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hamroh_V2.Service.Services
{
    public class ClientAdService : IClientAdService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        private IConfiguration config;

        //Constructor
        public ClientAdService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.config = config;
        }

        /// <summary>
        /// The sectionthat stores data to the server
        /// </summary>
        /// <param name="clientAdDto"></param>
        /// <returns></returns>
        public async Task<BaseResponse<ClientAd>> CreateAsync(ClientAdForCreationDto clientAdDto)
        {
            BaseResponse<ClientAd> response = new BaseResponse<ClientAd>();

            ClientAd clientAdMapped = mapper.Map<ClientAd>(clientAdDto);
            clientAdMapped.Create();

            ClientAd clientAd = await unitOfWork.ClientAds.CreateAsync(clientAdMapped);

            response.Data = clientAd;

            return response;
        }

        /// <summary>
        /// this is used to delete unnecessary data from the database
        /// </summary>
        /// <param name="pred"></param>
        /// <returns></returns>
        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<ClientAd, bool>> pred)
        {
            BaseResponse<bool> response = new BaseResponse<bool>();

            ClientAd clientAd = await unitOfWork.ClientAds.GetAsync(pred);

            if (clientAd == null)
            {
                response.Error = new ErrorResponse(404, "Client Ad not found!");
                return response;
            }

            clientAd.Delete();

            ClientAd result = await unitOfWork.ClientAds.UpdateAsync(clientAd);

            response.Data = true;

            return response;
        }

        /// <summary>
        /// We use it to get the necessary all information from the database
        /// </summary>
        /// <param name="pred"></param>
        /// <returns></returns>
        public BaseResponse<IEnumerable<ClientAd>> GetAll(Expression<Func<ClientAd, bool>> pred = null, PaginationParameters parameters = null)
        {
            BaseResponse<IEnumerable<ClientAd>> response = new BaseResponse<IEnumerable<ClientAd>>();

            IEnumerable<ClientAd> clientAds = unitOfWork.ClientAds.GetAll(pred).Where(p => p.State != ItemState.Deleted).ToPagedAsEnumerable(parameters);

            response.Data = clientAds;

            return response;
        }

        /// <summary>
        /// We use it to get the necessary information from the database
        /// </summary>
        /// <param name="pred"></param>
        /// <returns></returns>
        public async Task<BaseResponse<ClientAd>> GetAsync(Expression<Func<ClientAd, bool>> pred)
        {
            BaseResponse<ClientAd> response = new BaseResponse<ClientAd>();

            ClientAd clientAd = await unitOfWork.ClientAds.GetAsync(pred);

            if (clientAd == null)
            {
                response.Error = new ErrorResponse(404, "Client Ad not found!");
                return response;
            }

            response.Data = clientAd;

            return response;
        }

        /// <summary>
        /// This is used to change the data from the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clientAdDto"></param>
        /// <returns></returns>
        public async Task<BaseResponse<ClientAd>> UpdateAsync(long id, ClientAdForCreationDto clientAdDto)
        {
            BaseResponse<ClientAd> response = new BaseResponse<ClientAd>();

            ClientAd clientAd = await unitOfWork.ClientAds.GetAsync(p => p.Id == id);

            if (clientAd == null)
            {
                response.Error = new ErrorResponse(404, "Client Ad not found!");
                return response;
            }

            clientAd.Qayerdan = clientAdDto.Qayerdan;
            clientAd.Qayerga = clientAdDto.Qayerga;
            clientAd.PeopleCount = clientAdDto.PeopleCount;
            clientAd.Summa = clientAdDto.Summa;
            clientAd.ClientId = clientAdDto.ClientId;
            clientAd.Date = clientAdDto.Date;
            clientAd.Comment = clientAdDto.Comment;

            clientAd.Update();

            ClientAd result = await unitOfWork.ClientAds.UpdateAsync(clientAd);

            response.Data = result;

            return response;
        }
    }
}

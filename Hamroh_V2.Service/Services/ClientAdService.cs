using AutoMapper;
using Hamroh_V2.Data.IRepositories;
using Hamroh_V2.Domain.Commons;
using Hamroh_V2.Domain.Entities.ClientAds;
using Hamroh_V2.Service.DTOs.ClientAdDTO;
using Hamroh_V2.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hamroh_V2.Service.Services
{
    public class ClientAdService : IClientAdService
    {
        private IMapper mapper;
        private IConfiguration config;
        private IClientAdRepository clientAdRepository;

        //Constructor
        public ClientAdService(IClientAdRepository clientAdRepository, IMapper mapper, IConfiguration config)
        {
            this.clientAdRepository = clientAdRepository;
            this.mapper = mapper;
            this.config = config;
        }

        public async Task<BaseResponse<ClientAd>> CreateAsync(ClientAdForCreationDto clientAdDto)
        {
            BaseResponse<ClientAd> response = new BaseResponse<ClientAd>();

            ClientAd clientAdMapped = mapper.Map<ClientAd>(clientAdDto);
            clientAdMapped.Create();

            ClientAd clientAd = await clientAdRepository.CreateAsync(clientAdMapped);

            response.Data = clientAd;

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<ClientAd, bool>> pred)
        {
            BaseResponse<bool> response = new BaseResponse<bool>();

            ClientAd clientAd = await clientAdRepository.GetAsync(pred);

            if (clientAd == null)
            {
                response.Error = new ErrorResponse(404, "Client Ad not found!");
                return response;
            }

            clientAd.Delete();

            ClientAd result = await clientAdRepository.UpdateAsync(clientAd);

            response.Data = true;

            return response;
        }

        public BaseResponse<IEnumerable<ClientAd>> GetAll(Expression<Func<ClientAd, bool>> pred)
        {
            BaseResponse<IEnumerable<ClientAd>> response = new BaseResponse<IEnumerable<ClientAd>>();

            IEnumerable<ClientAd> clientAds = clientAdRepository.GetAll(pred);

            response.Data = clientAds;

            return response;
        }

        public async Task<BaseResponse<ClientAd>> GetAsync(Expression<Func<ClientAd, bool>> pred)
        {
            BaseResponse<ClientAd> response = new BaseResponse<ClientAd>();

            ClientAd clientAd = await clientAdRepository.GetAsync(pred);

            if (clientAd == null)
            {
                response.Error = new ErrorResponse(404, "Client Ad not found!");
                return response;
            }

            response.Data = clientAd;

            return response;
        }

        public async Task<BaseResponse<ClientAd>> UpdateAsync(long id, ClientAdForCreationDto clientAdDto)
        {
            BaseResponse<ClientAd> response = new BaseResponse<ClientAd>();

            ClientAd clientAd = await clientAdRepository.GetAsync(p => p.Id == id);

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

            ClientAd result = await clientAdRepository.UpdateAsync(clientAd);

            response.Data = result;

            return response;
        }
    }
}

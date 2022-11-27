using AutoMapper;
using Hamroh_V2.Data.IRepositories;
using Hamroh_V2.Domain.Commons;
using Hamroh_V2.Domain.Entities.Clients;
using Hamroh_V2.Service.DTOs.ClientDTO;
using Hamroh_V2.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hamroh_V2.Service.Services
{
    public class ClientService : IClientService
    {
        private IUnitOfWork unitOfWork;
        private IClientRepository clientRepository;
        private IConfiguration config;
        private IMapper mapper;

        //Constructor
        public ClientService(IUnitOfWork unitOfWork, IClientRepository clientRepository, IConfiguration config, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.clientRepository = clientRepository;
            this.config = config;
            this.mapper = mapper;
        }

        /// <summary>
        /// The sectionthat stores data to the server
        /// </summary>
        /// <param name="clientDto"></param>
        /// <returns></returns>
        public async Task<BaseResponse<Client>> CreateAsync(ClientForCreationDto clientDto)
        {
            BaseResponse<Client> response = new BaseResponse<Client>();

            Client mappedClient = mapper.Map<Client>(clientDto);

            mappedClient.Create();

            Client result = await unitOfWork.Clients.CreateAsync(mappedClient);

            response.Data = result;

            return response;
        }

        /// <summary>
        /// this is used to delete unnecessary data from the database
        /// </summary>
        /// <param name="pred"></param>
        /// <returns></returns>
        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Client, bool>> pred)
        {
            BaseResponse<bool> response = new BaseResponse<bool>();

            Client client = await clientRepository.GetAsync(pred);

            if (client == null)
            {
                response.Error = new ErrorResponse(404, "Client not found");
                return response;
            }

            else
            {
                client.Delete();

                Client result = await clientRepository.UpdateAsync(client);

                response.Data = true;

                return response;
            }
        }

        /// <summary>
        /// We use it to get the necessary all information from the database
        /// </summary>
        /// <param name="pred"></param>
        /// <returns></returns>
        public BaseResponse<IEnumerable<Client>> GetAll(Expression<Func<Client, bool>> pred = null)
        {
            BaseResponse<IEnumerable<Client>> response = new BaseResponse<IEnumerable<Client>>();

            IEnumerable<Client> result = clientRepository.GetAll(pred);

            response.Data = result;

            return response;
        }

        /// <summary>
        /// We use it to get the necessary information from the database
        /// </summary>
        /// <param name="pred"></param>
        /// <returns></returns>
        public async Task<BaseResponse<ClientForGetDto>> GetAsync(Expression<Func<Client, bool>> pred)
        {
            BaseResponse<ClientForGetDto> response = new BaseResponse<ClientForGetDto>();

            Client client = await unitOfWork.Clients.GetAsync(pred);

            ClientForGetDto mappedClient = new ClientForGetDto()
            {
                FirstName = client.FirstName,
                PhoneNumber = client.PhoneNumber,
            };

            if (client == null)
            {
                response.Error = new ErrorResponse(404, "Client not found");
                return response;
            }

            response.Data = mappedClient;

            return response;
        }

        /// <summary>
        /// This is used to change the data from the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clientDto"></param>
        /// <returns></returns>
        public async Task<BaseResponse<Client>> UpdateAsync(long id, ClientForCreationDto clientDto)
        {
            BaseResponse<Client> response = new BaseResponse<Client>();

            Client client = await clientRepository.GetAsync(p => p.Id == id);

            if (client == null)
            {
                response.Error = new ErrorResponse(404, "Client not found");
                return response;
            }

            else
            {
                client.FirstName = clientDto.FirstName;
                client.PhoneNumber = clientDto.PhoneNumber;
                client.Update();

                Client result = await clientRepository.UpdateAsync(client);

                response.Data = result;

                return response;
            }
        }
    }
}

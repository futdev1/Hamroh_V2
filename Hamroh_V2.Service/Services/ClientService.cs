using Hamroh_V2.Data.IRepositories;
using Hamroh_V2.Domain.Commons;
using Hamroh_V2.Domain.Entities.Clients;
using Hamroh_V2.Service.DTOs.ClientDTO;
using Hamroh_V2.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hamroh_V2.Service.Services
{
    public class ClientService : IClientService
    {
        internal IClientRepository clientRepository;
        internal IConfiguration config;
        internal IWebHostEnvironment env;

        public ClientService(IClientRepository clientRepository, IConfiguration config, IWebHostEnvironment env)
        {
            this.clientRepository = clientRepository;
            this.config = config;
            this.env = env;
        }

        public Task<Client> CreateAsync(ClientForCreationDto clientDto)
        {
            Client client = new Client()
            {
                FirstName = clientDto.FirstName,
                Qayerdan = clientDto.Qayerdan,
                Qayerga = clientDto.Qayerga,
                Date = clientDto.Date,
                PeopleCount = clientDto.PeopleCount,
                PhoneNumber = clientDto.PhoneNumber,
                Summa = clientDto.Summa,
                Comment = clientDto.Comment
            };

            return clientRepository.CreateAsync(client);
            
        }

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

        public IQueryable<Client> GetAllAsync(Expression<Func<Client, bool>> pred = null)
        {
            return clientRepository.GetAll(pred);
        }

        public Task<Client> GetAsync(Expression<Func<Client, bool>> pred)
        {
            return clientRepository.GetAsync(pred);
        }

        public async Task<Client> UpdateAsync(long id, ClientForCreationDto clientDto)
        {
            Client client = await clientRepository.GetAsync(p => p.Id == id);

            if(client != null)
            {
                client.FirstName = clientDto.FirstName;
                client.PhoneNumber = clientDto.PhoneNumber;
                client.Summa = clientDto.Summa;
                client.Qayerdan = clientDto.Qayerdan;
                client.Qayerga = clientDto.Qayerga;
                client.Comment = clientDto.Comment;
                client.PeopleCount = clientDto.PeopleCount;
                client.Date = clientDto.Date;
            }
            return await clientRepository.UpdateAsync(client);
        }
    }
}

using Hamroh_V2.Data.IRepositories;
using Hamroh_V2.Domain.Entities.Clients;
using Hamroh_V2.Service.DTOs.ClientDTO;
using Hamroh_V2.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hamroh_V2.Service.Services
{
    public class ClientService : IClientService
    {
        internal IClientRepository clientRepository;
        public ClientService(IClientRepository _clientRepository)
        {
             clientRepository = _clientRepository;
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

        public Task<bool> DeleteAsync(Expression<Func<Client, bool>> pred)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Client> GetAllAsync(Expression<Func<Task, bool>> pred)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetAsync(Expression<Func<Client, bool>> pred)
        {
            throw new NotImplementedException();
        }

        public Task<Client> UpdateAsync(Client client)
        {
            throw new NotImplementedException();
        }
    }
}

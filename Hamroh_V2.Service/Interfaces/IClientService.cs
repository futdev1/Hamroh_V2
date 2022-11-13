using Hamroh_V2.Domain.Entities.Clients;
using Hamroh_V2.Service.DTOs.ClientDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hamroh_V2.Service.Interfaces
{
    public interface IClientService
    {
        Task<Client> CreateAsync(ClientForCreationDto clientDto);

        Task<bool> DeleteAsync(Expression<Func<Client, bool>> pred);

        IQueryable<Client> GetAllAsync(Expression<Func<Client, bool>> pred);

        Task<Client> GetAsync(Expression<Func<Client, bool>> pred);

        Task<Client> UpdateAsync(Client client);
    }
}

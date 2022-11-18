﻿using Hamroh_V2.Domain.Commons;
using Hamroh_V2.Domain.Entities.Clients;
using Hamroh_V2.Service.DTOs.ClientDTO;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hamroh_V2.Service.Interfaces
{
    public interface IClientService
    {
        Task<Client> CreateAsync(ClientForCreationDto clientDto);

        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Client, bool>> pred);

        IQueryable<Client> GetAllAsync(Expression<Func<Client, bool>> pred);

        Task<Client> GetAsync(Expression<Func<Client, bool>> pred);

        Task<Client> UpdateAsync(long id, ClientForCreationDto client);
    }
}

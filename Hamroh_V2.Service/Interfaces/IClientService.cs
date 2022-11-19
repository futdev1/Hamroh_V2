﻿using Hamroh_V2.Domain.Commons;
using Hamroh_V2.Domain.Entities.Clients;
using Hamroh_V2.Service.DTOs.ClientDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hamroh_V2.Service.Interfaces
{
    public interface IClientService
    {
        Task<BaseResponse<Client>> CreateAsync(ClientForCreationDto clientDto);

        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Client, bool>> pred);

        BaseResponse<IEnumerable<Client>> GetAll(Expression<Func<Client, bool>> pred);

        Task<BaseResponse<Client>> GetAsync(Expression<Func<Client, bool>> pred);

        Task<BaseResponse<Client>> UpdateAsync(long id, ClientForCreationDto client);
    }
}

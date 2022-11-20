using AutoMapper;
using Hamroh_V2.Domain.Entities.Clients;
using Hamroh_V2.Domain.Entities.Drivers;
using Hamroh_V2.Service.DTOs.ClientDTO;
using Hamroh_V2.Service.DTOs.DriverDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamroh_V2.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClientForCreationDto, Client>().ReverseMap();
            CreateMap<DriverForCreationDto, Driver>().ReverseMap();
        }
    }
}

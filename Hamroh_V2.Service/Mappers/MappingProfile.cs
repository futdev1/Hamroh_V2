using AutoMapper;
using Hamroh_V2.Domain.Entities.ClientAds;
using Hamroh_V2.Domain.Entities.Clients;
using Hamroh_V2.Domain.Entities.DriverAds;
using Hamroh_V2.Domain.Entities.Drivers;
using Hamroh_V2.Service.DTOs.ClientAdDTO;
using Hamroh_V2.Service.DTOs.ClientDTO;
using Hamroh_V2.Service.DTOs.DriverAdDTO;
using Hamroh_V2.Service.DTOs.DriverDTO;

namespace Hamroh_V2.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClientForCreationDto, Client>().ReverseMap();
            CreateMap<ClientAdForCreationDto, ClientAd>().ReverseMap();
            CreateMap<DriverForCreationDto, Driver>().ReverseMap();
            CreateMap<DriverAdForCreationDto, DriverAd>().ReverseMap();
        }
    }
}

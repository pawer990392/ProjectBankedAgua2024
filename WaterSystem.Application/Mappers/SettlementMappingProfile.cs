using AutoMapper;
using WaterSystem.Application.Dtos.Request;
using WaterSystem.Application.Dtos.Response;
using WaterSystem.Domain.Entities;
using WaterSystem.Infrastructure.Commons.Bases.Response;

namespace WaterSystem.Application.Mappers
{
    public class SettlementMappingProfile : Profile
    {
        //trasformacion de los objetos
        public SettlementMappingProfile()
        {
            CreateMap<Settlement, SettlementRequestDto>().ReverseMap();
            CreateMap<BaseEntityResponse<Settlement>,BaseEntityResponse<SettlementResponseDto>>().ReverseMap();
            CreateMap<Settlement, SettlementResponseDto>().ForMember(x=>x.IdSettlement,x=>x.MapFrom(y=>y.Id))
            .ReverseMap();
            CreateMap<SettlementRequestDto, Settlement>().ReverseMap();
            CreateMap<Settlement, SettlementSelectResponseDto>().
                ForMember(x => x.IdSettlement, x => x.MapFrom(y => y.Id)).ReverseMap();
        }
    }
}

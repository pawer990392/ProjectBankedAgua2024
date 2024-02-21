using AutoMapper;
using WaterSystem.Application.Dtos.Request;
using WaterSystem.Domain.Entities;

namespace WaterSystem.Application.Mappers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {//inidca en el video 42:00 22
            CreateMap<UserRequestDto, User>().ReverseMap();
            CreateMap<TokenRequestDto, User>().ReverseMap();
        }
    }
}

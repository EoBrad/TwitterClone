using AutoMapper;
using TwitterClone.Dtos.User;

namespace TwitterClone.Mapper;

public class DtoToDto : Profile
{
    public DtoToDto()
    {   
        CreateMap<UpdateUserRequestDto, UpdateUserDto>();
    }
}

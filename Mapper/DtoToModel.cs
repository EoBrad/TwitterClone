using AutoMapper;
using TwitterClone.Dtos;

namespace TwitterClone.Mapper;

public class DtoToModel : Profile
{
    public DtoToModel()
    {
        CreateMap<CreateUserDto, Models.User>();
    }
}

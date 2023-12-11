using AutoMapper;
using TwitterClone.Dtos.User;

namespace TwitterClone.Mapper;

public class DtoToModel : Profile
{
    public DtoToModel()
    {
        CreateMap<CreateUserDto, Models.User>();
        CreateMap<UpdateUserDto, Models.User>();
    }
}

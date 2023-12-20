using AutoMapper;
using TwitterClone.Dtos.Tweet;
using TwitterClone.Dtos.User;

namespace TwitterClone.Mapper;

public class DtoToModel : Profile
{
    public DtoToModel()
    {
        CreateMap<CreateUserDto, Models.User>();
        CreateMap<CreateTweetDto, Models.Tweet>();
    }
}

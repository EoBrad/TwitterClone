using AutoMapper;
using TwitterClone.Responses;

namespace TwitterClone.Mapper;

public class ModelToResponse : Profile
{
    public ModelToResponse()
    {
        CreateMap<Models.User, UserProfileResponse>();
    }
}

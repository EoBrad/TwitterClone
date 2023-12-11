using AutoMapper;
using TwitterClone.Dtos.User;

namespace TwitterClone.Mapper;

public class DtoToModel : Profile
{
    public DtoToModel()
    {
        CreateMap<CreateUserDto, Models.User>();
        CreateMap<UpdateUserDto, Models.User>()
                .ForMember(u => u.CreatedAt, opt => opt.Ignore())
                .ForMember(u => u.Email, opt => opt.Ignore())
                .ForMember(u => u.UserId, opt => opt.Ignore())
                .ForMember(u => u.Password, opt => opt.Ignore())
                .ForMember(u => u.Username, opt => opt.Ignore())
                .ForMember(u => u.DateOfBirth, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}

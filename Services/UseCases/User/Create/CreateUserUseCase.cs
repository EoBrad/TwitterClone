using AutoMapper;
using TwitterClone.Dtos;
using TwitterClone.Models;
using TwitterClone.Responses;

namespace TwitterClone.Services.UseCases.User.Create;

public class CreateUserUseCase : ICreateUserUseCase
{
    private readonly IMapper _mapper;

    private readonly IUserRepository _userRepository;

    public CreateUserUseCase(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public async Task<CreateUserResponse> Execute(CreateUserDto createUserDto)
    {
        await _userRepository.CheckUsernameOrEmailExists(createUserDto.Username, createUserDto.Email);

        var user = _mapper.Map<Models.User>(createUserDto);

        await _userRepository.CreateUser(user);

        var token = Jwt.GenerateToken(user);

        return new CreateUserResponse 
        {
            token = token,
            message = "User created successfully"
        };
    }
}

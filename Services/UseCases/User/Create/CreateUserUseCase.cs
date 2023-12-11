using AutoMapper;
using TwitterClone.Dtos.User;
using TwitterClone.Models;
using TwitterClone.Responses;
using TwitterClone.Services.Utility;

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

        createUserDto.Password = Encrypt.EncryptPassword(createUserDto.Password);

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

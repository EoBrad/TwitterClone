using System.Net;
using TwitterClone.Dtos;
using TwitterClone.Dtos.User;
using TwitterClone.Exeptions;
using TwitterClone.Models;
using TwitterClone.Responses;
using TwitterClone.Services.Utility;

namespace TwitterClone.Services.UseCases.User.Login;

public class LoginUserUseCase : ILoginUserUseCase
{

    private readonly IUserRepository _userRepository;

    public LoginUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<LoginUserResponse> Execute(LoginUserDto request)
    {

        request.Password = Encrypt.EncryptPassword(request.Password);

        if(await _userRepository.LoginUser(request))
        {
            var user = await _userRepository.FindUserByEmailOrUsername(request.UserCredential);

            var token = Jwt.GenerateToken(user);

            return new LoginUserResponse
            {
                Expires = DateTime.UtcNow.AddHours(1),
                Token = token,
            };
        }

        throw new TwitterCloneExeption("Invalid username or password", (int)HttpStatusCode.Unauthorized);
    }
}

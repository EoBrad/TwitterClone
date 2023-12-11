using TwitterClone.Dtos;
using TwitterClone.Dtos.User;

namespace TwitterClone.Models;

public interface IUserRepository
{
    Task CreateUser(User user);
    Task<User> FindUserByEmailOrUsername(string userCredential);

    
    Task CheckUsernameOrEmailExists(string username, string email);

    Task<bool> LoginUser(LoginUserDto loginUserDto);

    Task UpdateUserAsync(User user);

    Task<User> FindUserByIdAsync(Guid userId);
}

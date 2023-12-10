namespace TwitterClone.Models;

public interface IUserRepository
{
    Task CreateUser(User user);
    Task<User> FindUserByEmail(string email);

    Task CheckUsernameOrEmailExists(string username, string email);
}

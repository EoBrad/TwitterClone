using TwitterClone.Models;
using TwitterClone.Repositorys.User;

namespace TwitterClone.Services.Configuration;

public static class AddRepositoriesConfiguration
{
    public static void AddRepositories(this IServiceCollection service)
    {
        service.AddScoped<IUserRepository, UserRepository>();
    }
}

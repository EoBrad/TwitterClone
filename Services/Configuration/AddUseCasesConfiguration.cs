using TwitterClone.Services.UseCases.User.Create;
using TwitterClone.Services.UseCases.User.Login;

namespace TwitterClone.Services.Configuration;

public static class AddUseCasesConfiguration
{
    public static void AddUseCases(this IServiceCollection service)
    {
        service.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
        service.AddScoped<ILoginUserUseCase, LoginUserUseCase>();
    }
}

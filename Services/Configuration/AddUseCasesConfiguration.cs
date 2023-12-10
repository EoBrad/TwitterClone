using TwitterClone.Services.UseCases.User.Create;

namespace TwitterClone.Services.Configuration;

public static class AddUseCasesConfiguration
{
    public static void AddUseCases(this IServiceCollection service)
    {
        service.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
    }
}

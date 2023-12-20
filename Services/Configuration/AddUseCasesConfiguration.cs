using TwitterClone.Services.UseCases.Profile;
using TwitterClone.Services.UseCases.Tweet.Create;
using TwitterClone.Services.UseCases.User.Create;
using TwitterClone.Services.UseCases.User.Login;
using TwitterClone.Services.UseCases.User.Update;

namespace TwitterClone.Services.Configuration;

public static class AddUseCasesConfiguration
{
    public static void AddUseCases(this IServiceCollection service)
    {
        service.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
        service.AddScoped<ILoginUserUseCase, LoginUserUseCase>();
        service.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
        service.AddScoped<IProfileUseCase, ProfileUseCase>();
        service.AddScoped<ICreateTweetUseCase, CreateTweetUseCase>();
    }
}

using TwitterClone.Responses;

namespace TwitterClone.Services.UseCases.Profile;

public interface IProfileUseCase
{
    Task<UserProfileResponse> Execute(string username);
}
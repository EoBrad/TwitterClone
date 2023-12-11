using TwitterClone.Dtos.User;

namespace TwitterClone.Services.UseCases.User.Update;

public interface IUpdateUserUseCase
{
    Task Execute(UpdateUserDto updateUserDto, FormFile image, string token);
}

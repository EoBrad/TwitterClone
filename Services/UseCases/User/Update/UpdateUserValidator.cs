using FluentValidation;
using TwitterClone.Dtos.User;

namespace TwitterClone.Services.UseCases.User.Update;

public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserDtoValidator()
    {
        RuleFor(x => x.Image.ContentType).Custom((contentType, context) =>
        {
            if (!contentType.Contains("image"))
                context.AddFailure("File", "File must be an image");
        }); 

        RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(3).MaximumLength(20);

        RuleFor(x => x.LastName).NotNull().NotEmpty().MinimumLength(3).MaximumLength(50);
    }
}

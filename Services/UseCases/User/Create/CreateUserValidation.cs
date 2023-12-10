using FluentValidation;
using TwitterClone.Dtos;

namespace TwitterClone.Services.UseCases.User.Create;

public class CreateUserValidation : AbstractValidator<CreateUserDto>
{
    public CreateUserValidation()
    {
        RuleFor(x => x.Username).NotEmpty()
                                .MinimumLength(5)
                                .MaximumLength(35);

        RuleFor(x => x.Password).NotEmpty()
                                .MinimumLength(5)
                                .MaximumLength(20);

        RuleFor(x => x.Name).NotEmpty()
                            .MinimumLength(3)
                            .MaximumLength(20);

        RuleFor(x => x.Email).NotEmpty()
                            .EmailAddress();


        RuleFor(x => x.LastName).NotEmpty()
                                .MinimumLength(3);

        RuleFor(x => x.DateOfBirth).NotEmpty().Custom((date, context) => 
        {
            if (date.Year - DateTime.Now.Year < 18)
            {
                context.AddFailure("DateOfBirth", "User must be at least 18 years old");
            }
        });
    }
}

using FluentValidation;
using TwitterClone.Dtos;
using TwitterClone.Dtos.User;

namespace TwitterClone.Services.UseCases.User.Create;

public class CreateUserValidation : AbstractValidator<CreateUserDto>
{
    public CreateUserValidation()
    {
        RuleFor(x => x.Username).NotEmpty()
                                .MinimumLength(5)
                                .MaximumLength(35).Custom((username, context) => 
                                {
                                    if (username.First() != '@')
                                    {
                                        context.AddFailure("Username", "Username must start with @");
                                    }
                                });

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
            if (DateTime.Now.Day >= date.Day && DateTime.Now.Month >= date.Month && DateTime.Now.Year - date.Year < 18 )
            {
                context.AddFailure("DateOfBirth", "User must be at least 18 years old");
            }
        });
    }
}

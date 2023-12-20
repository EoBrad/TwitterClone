using FluentValidation;
using TwitterClone.Dtos.Tweet;

namespace TwitterClone.Services.UseCases.Tweet.Create;

public class CreateTweetValidation : AbstractValidator<CreateTweetDto>
{
    public CreateTweetValidation()
    {
        RuleFor(x => x.Content).NotEmpty().MaximumLength(255);
    }
}

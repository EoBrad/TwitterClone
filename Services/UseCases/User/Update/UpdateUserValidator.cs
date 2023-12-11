using FluentValidation;

namespace TwitterClone.Services.UseCases.User.Update;

public class FileValidator : AbstractValidator<IFormFile>
{
    public FileValidator()
    {
        RuleFor(x => x.ContentType).Custom((contentType, context) => 
        {
            if(contentType.Contains("image"))
                context.AddFailure("File", "File must be an image");  
        });
    }
}

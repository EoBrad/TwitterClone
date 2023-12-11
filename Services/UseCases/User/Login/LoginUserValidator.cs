using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using TwitterClone.Dtos;
using TwitterClone.Dtos.User;

namespace TwitterClone.Services.UseCases.User.Login
{
    public class LoginUserValidator : AbstractValidator<LoginUserDto>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.UserCredential).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterClone.Dtos;
using TwitterClone.Dtos.User;
using TwitterClone.Responses;

namespace TwitterClone.Services.UseCases.User.Create;

public interface ICreateUserUseCase
{
    Task<CreateUserResponse> Execute(CreateUserDto createUserDto);
}

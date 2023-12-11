
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Dtos;
using TwitterClone.Responses;
using TwitterClone.Services.UseCases.User.Create;
using TwitterClone.Services.UseCases.User.Login;

namespace TwitterClone.Controllers;

[ApiController]
[Route("api/v1/user")]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto, [FromServices] ICreateUserUseCase createUserUseCase)
    {
        var res = await createUserUseCase.Execute(createUserDto);
        return Created(string.Empty, res);
    }

    
}

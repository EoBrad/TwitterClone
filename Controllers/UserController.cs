
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Dtos;
using TwitterClone.Dtos.User;
using TwitterClone.Responses;
using TwitterClone.Services.UseCases.User.Create;
using TwitterClone.Services.UseCases.User.Login;
using TwitterClone.Services.UseCases.User.Update;

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

    [HttpPatch]
    [Authorize]
    public async Task<IActionResult> UpdateUser([FromForm] UpdateUserDto updateUserDto, [FromServices] IUpdateUserUseCase updateUserUseCase)
    {
        var bearer = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        
        await updateUserUseCase.Execute(updateUserDto, updateUserDto.Image, bearer);

        return Ok();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Dtos;
using TwitterClone.Responses;
using TwitterClone.Services.UseCases.User.Login;

namespace TwitterClone.Controllers
{
    [ApiController]
    [Route("api/v1/login")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(LoginUserResponse), StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto, [FromServices] ILoginUserUseCase loginUserUseCase)
        {
            var res = await loginUserUseCase.Execute(loginUserDto);

            return Ok(res);
        }
    }
}
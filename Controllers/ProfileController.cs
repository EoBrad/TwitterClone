using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Responses;
using TwitterClone.Services.UseCases.Profile;

namespace TwitterClone.Controllers
{
    [ApiController]
    [Route("api/v1/profile")]
    public class ProfileController : ControllerBase
    {
        [HttpGet]
        [Route("{username}")]
        [ProducesResponseType(typeof(UserProfileResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromRoute]string username, [FromServices] IProfileUseCase profileUseCase)
        {
            var user = await profileUseCase.Execute(username);

            return Ok(user);
        }
    }
}
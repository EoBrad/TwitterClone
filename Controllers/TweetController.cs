using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Dtos.Tweet;
using TwitterClone.Services.UseCases.Tweet.Create;

namespace TwitterClone.Controllers;

[ApiController]
[Route("api/tweet")]
public class TweetController : ControllerBase
{   
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateTweet([FromBody] CreateTweetDto createTweetDto, [FromServices] ICreateTweetUseCase service)
    {
        var bearer = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        await service.Execute(createTweetDto, bearer);

        return Created(string.Empty, null);
    }
}

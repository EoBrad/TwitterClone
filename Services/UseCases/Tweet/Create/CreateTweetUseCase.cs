using AutoMapper;
using TwitterClone.Dtos.Tweet;
using TwitterClone.Repositorys.Tweet;
using TwitterClone.Services.Utility;

namespace TwitterClone.Services.UseCases.Tweet.Create;

public class CreateTweetUseCase : ICreateTweetUseCase
{
    private readonly ITweetRepository _tweetRepository;
    
    private readonly IMapper _mapper;

    public CreateTweetUseCase(ITweetRepository tweetRepository, IMapper mapper)
    {
        _mapper = mapper;
        _tweetRepository = tweetRepository;
    }
    public async Task Execute(CreateTweetDto createTweetDto, string token)
    {
        var tweet = _mapper.Map<Models.Tweet>(createTweetDto);

        var userId = Jwt.GetUserByToken(token);

        tweet.UserId = new Guid(userId);

        await _tweetRepository.CreateTweetAsync(tweet);
    }
}

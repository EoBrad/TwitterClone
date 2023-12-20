using AutoMapper;
using TwitterClone.Dtos.Tweet;
using TwitterClone.Repositorys.Tweet;

namespace TwitterClone.Services.UseCases.Tweet.Create;

public class CreateUserUseCase : ICreateTweetUseCase
{
    private readonly ITweetRepository _tweetRepository;
    
    private readonly IMapper _mapper;

    public CreateUserUseCase(ITweetRepository tweetRepository, IMapper mapper)
    {
        _mapper = mapper;
        _tweetRepository = tweetRepository;
    }
    public async Task Execute(CreateTweetDto createTweetDto, Guid userId)
    {
        var tweet = _mapper.Map<Models.Tweet>(createTweetDto);

        tweet.UserId = userId;

        await _tweetRepository.CreateTweetAsync(tweet);
    }
}

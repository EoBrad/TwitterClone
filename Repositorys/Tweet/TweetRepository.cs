
using TwitterClone.Context;

namespace TwitterClone.Repositorys.Tweet;

public class TweetRepository : ITweetRepository
{

    private readonly AppDbContext _context;

    public TweetRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task CreateTweetAsync(Models.Tweet tweet)
    {
        await _context.Tweets.AddAsync(tweet);

        await _context.SaveChangesAsync();
    }
}

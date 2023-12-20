using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TwitterClone.Repositorys.Tweet;

public interface ITweetRepository
{
    Task CreateTweetAsync(Models.Tweet tweet);
}
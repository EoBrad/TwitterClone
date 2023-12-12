using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterClone.Models;

[Table("tweets")]
public class Tweet
{
    public Guid TweetId { get; set; }

    public string Content { get; set; }

    [Timestamp]
    public DateTime CreatedAt { get; set; }

    public User user;

    public Guid UserId;

    public List<TweetUserLike> TweetUserLikes { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterClone.Models;


[Table("tweetUserLikes")]
public class TweetUserLike
{
    public Guid TweetUserLikeId { get; set; }
    public Tweet Tweet { get; set; }
    public User User { get; set; }

    public Guid UserId { get; set; }

    public Guid TweetId { get; set; }

    [Timestamp]
    public DateTime CreatedAt { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterClone.Models;


[Table("users")]
public class User
{
    [Key]
    public Guid UserId { get; set; }

    [MaxLength(20)]
    public string Name { get; set; }

    [MaxLength(100)]
    public string LastName { get; set; }

    public string PhotoURL { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    [Timestamp]
    public DateTime CreatedAt { get; set; }

    [MaxLength(20)]
    public string Username { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Bio { get; set; }

    public List<Tweet> Tweets { get; set; }
}
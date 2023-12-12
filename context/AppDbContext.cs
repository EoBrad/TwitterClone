using Microsoft.EntityFrameworkCore;
using TwitterClone.Models;

namespace TwitterClone.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Tweet> Tweets { get; set; }

    public DbSet<TweetUserLike> Likes { get; set; }
}

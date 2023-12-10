using Microsoft.EntityFrameworkCore;
using TwitterClone.Models;

namespace TwitterClone.context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
    }

    public DbSet<User> Users { get; set; }
}

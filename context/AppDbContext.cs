using Microsoft.EntityFrameworkCore;

namespace TwitterClone.context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
    }
}

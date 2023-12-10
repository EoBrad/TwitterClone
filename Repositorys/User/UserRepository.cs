using Microsoft.EntityFrameworkCore;
using TwitterClone.context;
using TwitterClone.Models;

namespace TwitterClone.Repositorys.User;

public class UserRepository : IUserRepository
{

    private AppDbContext _context;

    public async Task CreateUser(Models.User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<Models.User> FindUserByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
    }
}

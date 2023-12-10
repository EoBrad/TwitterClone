using System.Net;
using Microsoft.EntityFrameworkCore;
using TwitterClone.context;
using TwitterClone.Exeptions;
using TwitterClone.Models;

namespace TwitterClone.Repositorys.User;

public class UserRepository : IUserRepository
{

    private AppDbContext _context;

    public async Task CheckUsernameOrEmailExists(string username, string email)
    {
        var user = await _context.Users.FirstAsync(x => x.Username == username || x.Email == email);

        if(user.Username == username)
            throw new TwitterCloneExeption("Username already exists", (int)HttpStatusCode.BadRequest);

        if(user.Email == email)
            throw new TwitterCloneExeption("Email already exists", (int)HttpStatusCode.BadRequest);
    }

    public async Task CreateUser(Models.User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<Models.User> FindUserByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
    }
}

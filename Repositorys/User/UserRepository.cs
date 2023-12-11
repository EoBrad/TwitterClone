using System.Net;
using Microsoft.EntityFrameworkCore;
using TwitterClone.Context;
using TwitterClone.Dtos;
using TwitterClone.Dtos.User;
using TwitterClone.Exeptions;
using TwitterClone.Models;

namespace TwitterClone.Repositorys.User;

public class UserRepository : IUserRepository
{

    private AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CheckUsernameOrEmailExists(string username, string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username || x.Email == email);

        if (user == null)
            return;
        
        if(user.Username == username)
            throw new TwitterCloneExeption("Username already exists", (int)HttpStatusCode.BadRequest);

        if(user.Email == email)
            throw new TwitterCloneExeption("Email already exists", (int)HttpStatusCode.BadRequest);
    }

    public async Task CreateUser(Models.User user)
    {
        await _context.Users.AddAsync(user);

        _context.SaveChanges();
    }

    public async Task<Models.User> FindUserByEmailOrUsername(string userCredential)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email == userCredential || x.Username == userCredential);
    }

    public async Task<Models.User> FindUserByIdAsync(Guid userId)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public async Task<bool> LoginUser(LoginUserDto loginUserDto)
    {
        var userLogin = await _context.Users
        .CountAsync(x => x.Username == loginUserDto.UserCredential || x.Email == loginUserDto.UserCredential && x.Password == loginUserDto.Password);

        if (userLogin > 0)
        {
            return true;
        }

        return false;
    }

    public async Task UpdateUserAsync(Models.User user)
    {
        _context.Users.Update(user);

       await _context.SaveChangesAsync();
    }
}

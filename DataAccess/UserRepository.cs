using Microsoft.EntityFrameworkCore;
using Models;
using CustomExceptions;
using System.Linq;
using System.Data.SqlClient;

namespace DataAccess;

public class UserRepository : IUserDAO
{
    private readonly StonksDbContext _context;
    public UserRepository(StonksDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }
    public async Task<User> GetUserById(int userID)
    {
        User? foundUser = await _context.Users.FirstOrDefaultAsync(user => user.UserId == userID);
        if(foundUser != null) return foundUser;
        throw new RecordNotFoundException("could not find the user with such id");
    }
    public async Task<User> GetUserByEmail(string email)
    {
        User? foundUser = await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
        if(foundUser != null) return foundUser;
        throw new RecordNotFoundException("could not find the user with such id");
    }
    public async Task<User> CreateUser(User user)
    {
        _context.Add(user);
        await _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();
        return user;
    }
    public async Task<bool> UpdateUser(User user)
    {
        _context.Update(user);
        await _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();
        return true;
    }

}

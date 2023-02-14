using Models;
using DataAccess;
using CustomExceptions;

namespace Services;

public class UserServices
{
    private readonly IUserDAO _userRepo;

    public UserServices(IUserDAO repo)
    {
        _userRepo = repo;
    }

    public async Task<List<User>> GetAllUsers()
    {
        try 
        {
            return await _userRepo.GetAllUsers();     
        }
        catch(RecordNotFoundException)
        {
            throw new RecordNotFoundException();
        }
    }
    public async Task<User> GetUserById(int userID)
    {
        try
        {
            return await _userRepo.GetUserById(userID);
        }
        catch(RecordNotFoundException)
        {
            throw new RecordNotFoundException();
        }
    }
    public async Task<User> GetUserByEmail(string email)
    {
        try
        {
            return await _userRepo.GetUserByEmail(email);
        }
        catch(RecordNotFoundException)
        {
            throw new RecordNotFoundException();
        }
    }
    public async Task<User> CreateUser(User user)
    {
        try
        {
            return await _userRepo.CreateUser(user);
        }
        catch(Exception)
        {
            throw;
        }
    }
    public async Task<bool> UpdateUser(User user)
    {
        try
        {
            return await _userRepo.UpdateUser(user);
        }
        catch(RecordNotFoundException)
        {
            throw new RecordNotFoundException();
        }
    }
}

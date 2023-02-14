using Models;

namespace DataAccess;

public interface IUserDAO
{
    Task<List<User>> GetAllUsers();
    Task<User> GetUserById(int userID);
    Task<User> GetUserByEmail(string email);
    Task<User> CreateUser(User user);
    Task<bool> UpdateUser(User user);
}

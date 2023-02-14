using Models;
using DataAccess;
using CustomExceptions;

namespace Services;

public class AuthServices 
{
    private readonly IUserDAO _user;

    public AuthServices(IUserDAO userDao)
    {
        _user = userDao;
    }
    
    public async Task<User> LogIn(User loginUser)
    {
        try
        {
            User foundUser = await _user.GetUserByEmail(loginUser.Email);

            if(loginUser.Email == null)
            {
                throw new ResourceNotFoundException();
            }
            if(loginUser.Password == foundUser.Password)
            {
                return foundUser;
            }
            else{
                throw new InvalidCredentialException();
            }
        }
        catch(RecordNotFoundException)
        {
            throw new InvalidCredentialException();
        }
    }

    public async Task<User> Register(User newUser)
    {
        try
        {
            User attempt = await _user.GetUserByEmail(newUser.Email);
            
            if(attempt.Email == newUser.Email)
            {
                throw new DuplicateRecordException("already exists email");
            }
            else    
            {
                newUser.UserId = 0;
                return await _user.CreateUser(newUser);
            }
        }
        catch(DuplicateRecordException)
        {
            throw;
        }
        catch(Exception)
        {
            return await _user.CreateUser(newUser);
        }  
    }
}
using Moq;
using Models;
using CustomExceptions;
using Services;
using Xunit;
using DataAccess;


namespace Tests;

/*
    TESTS REQUIRED
        - GetAllUsers       (✔) = Pass
        - GetUserById       (✔) = Pass
        - GetUserByEmail    (✔) = Pass
        - UpdateUser        (✔) = Pass
        - GetUserById       (✔) = RecordNotFoundException
        - GetUserByEmail    (✔) = 500 Internal Server Error
        - UpdateUser        (✔) = InvalidInputException        
*/

/*
    USERS HAVE (from User Model)
        - UserId
        - Email
        - Password
*/

public class UserTesting
{

    // GetAllUsers = Pass

    [Fact]
    public void GetAllUsers()
    {
        // WHERE does it get the mock information from? How does it get .... "all users"?
        var mockedRepo = new Mock<IUserDAO>();
        mockedRepo.Setup( repo =>  repo.GetAllUsers()).Throws(new ResourceNotFoundException());
        UserServices service = new UserServices(mockedRepo.Object);
        Assert.ThrowsAsync<ResourceNotFoundException>(async () => await service.GetAllUsers());
    }  

    // GetUserById = Pass

    [Fact]
    public async Task GetUserById()
    {
        var UserRepo = new Mock<IUserDAO>();
        User newUser = new User

        {
            UserId = 2,                     // has correct userId
            Email = "autumn@gmail.com",     // email valid
        };

        UserRepo.Setup( repo => repo.CreateUser(newUser)).ReturnsAsync(newUser);
        UserRepo.Setup( repo => repo.GetUserById(2)).ThrowsAsync(new RecordNotFoundException());

        UserServices service = new UserServices(UserRepo.Object);

        await Assert.ThrowsAsync<RecordNotFoundException>(() => service.GetUserById(2));  
    }


    // GetUserById = Fail
    

    [Fact]
    public async Task WrongUserId()
    {
        var UserRepo = new Mock<IUserDAO>();
        User newUser = new User

        {
            UserId = 8,                     // number doesn't exist
            Email = "autumn@gmail.com",     
        };

        UserRepo.Setup( repo =>  repo.CreateUser(newUser)).ReturnsAsync(newUser);
        UserRepo.Setup( repo => repo.GetUserById(2)).ThrowsAsync(new RecordNotFoundException());
        UserServices service = new UserServices(UserRepo.Object);
        await Assert.ThrowsAsync<RecordNotFoundException>(() => service.GetUserById(2));  
    }

    // UpdateUser = Pass
    [Fact]
    public async Task SucceedToUpdateUser()
    {
        // Given
        var UserRepo = new Mock<IUserDAO>();

        User newUser = new User{
            UserId = 1,
            Email = "autumn@gmail.com", 
        };

        User toUpdate = new User{
            UserId = 1,
            Email = "booger@snot.com", 
        };
    
        // If
        UserRepo.Setup( repo =>  repo.CreateUser(newUser)).ReturnsAsync(newUser);
        UserRepo.Setup( repo =>  repo.UpdateUser(toUpdate)).ReturnsAsync(true);
        // Then
        UserServices service = new UserServices(UserRepo.Object);
        var result = await service.UpdateUser(toUpdate);
        Assert.Equal(result, true);  
    }

    // UpdateUser = Fail
    [Fact]
    public async Task FailToUpdateUser()
    {
        // Given
        var UserRepo = new Mock<IUserDAO>();

        User newUser = new User{
            UserId = 1,
            Email = "autumn@gmail.com", 
        };

        User toUpdate = new User{
            UserId = 1,
            Email = "incorrect@wrong.com", 
        };
    
        // If
        UserRepo.Setup( repo =>  repo.CreateUser(newUser)).ReturnsAsync(newUser);
        UserRepo.Setup( repo =>  repo.CreateUser(toUpdate)).ThrowsAsync(new InvalidInputException());
        // Then
        UserServices service = new UserServices(UserRepo.Object);
        await Assert.ThrowsAsync<InvalidInputException>(() => service.CreateUser(toUpdate));  
    }

    // GetUserByEmail = Pass
    [Fact]
    public async Task GetUserByEmail()
    {
        var UserRepo = new Mock<IUserDAO>();
        // I can't tell from Models what should go here

        User newUser = new User {
            UserId = 2,                 // correct userId
            Email = "autumn@gmail.com",   // email valid
        };

        UserRepo.Setup( repo =>  repo.CreateUser(newUser)).ReturnsAsync(newUser);
        UserRepo.Setup( repo => repo.GetUserByEmail("autumn@gmail.com")).ReturnsAsync(newUser);
        
        UserServices service = new UserServices(UserRepo.Object);
        
        var existingUser = await service.GetUserByEmail("autumn@gmail.com");
        
        Assert.Equal(newUser.Email,existingUser.Email); 
    }

    // GetUserById = Fail    
    [Fact]
    public async Task WrongOrNoUserEmail()
    {
        var UserRepo = new Mock<IUserDAO>();

        User newUser = new User {
            UserId = 123,              
            Email = "autumn@gmail.com",  // "wrong" not valid
        };

        UserRepo.Setup( repo =>  repo.CreateUser(newUser)).ReturnsAsync(newUser);
        UserRepo.Setup( repo => repo.GetUserByEmail("autumn@gmail.wrong")).ThrowsAsync(new RecordNotFoundException());
        
        UserServices service = new UserServices(UserRepo.Object);
        
        await Assert.ThrowsAsync<RecordNotFoundException>(() => service.GetUserByEmail("autumn@gmail.wrong"));  
    }    

}
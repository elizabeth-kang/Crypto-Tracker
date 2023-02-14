using Models;
using Services;
using CustomExceptions;

namespace WebAPI.Controllers;

public class UserController
{
    private readonly UserServices _service;

    public UserController(UserServices service)
    {
        _service = service;
    }
    public async Task<IResult> GetAllUsers()
    {
        var AllUsers =  await _service.GetAllUsers();
        return AllUsers.Count > 0 ? Results.Ok(AllUsers) : Results.BadRequest("No users to get!");   
    }
    public async Task<IResult> GetUserById(int userID)
    {
        var User = await _service.GetUserById(userID);
        return User != null ? Results.Ok(User) : Results.BadRequest("No userd by this ID!");
    }
    public async Task<IResult> GetUserByEmail(string useremail)
    {
        var email = await _service.GetUserByEmail(useremail);
        return email != null ? Results.Ok(email) : Results.BadRequest("No user with this email!");
    }
    public async Task<IResult> CreateUser(User user)
    {
        var createdUser = await _service.CreateUser(user);
        return createdUser != null ? Results.Ok(createdUser) : Results.BadRequest("Invalid user input!");
    }
    public async Task<IResult> UpdateUser(User user)
    {
        var updatedUser = await _service.UpdateUser(user);
        return updatedUser ? Results.Ok(updatedUser) : Results.BadRequest("Invalid user update input!");

    }
}
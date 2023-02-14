using Services;
using Models;
using CustomExceptions;

namespace WebAPI.Controllers;
public class AuthController
{
    private readonly AuthServices _service;
    public AuthController(AuthServices service)
    {
        _service = service;
    }

    public async Task<IResult> Register(User userRegister)
    {
        if (userRegister.Email == null)
        {
            return Results.BadRequest("Name cannot be null");
        }
        try
        {
            await _service.Register(userRegister);
            return Results.Created("/register", userRegister);
        }
        catch (DuplicateRecordException)
        {
            return Results.Conflict("User with this name already exists");
        }
    }

        public async Task<IResult> Login(User findUser)
    {
        if (findUser.Email == null)
        {
            return Results.BadRequest("Name cannot be null");
        }
        try
        {
            return Results.Ok(await _service.LogIn(findUser));
        }
        catch (InvalidCredentialException)
        {
            return Results.NoContent();
        }
    }
}
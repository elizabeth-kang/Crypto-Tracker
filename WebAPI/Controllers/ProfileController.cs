using Services;
using CustomExceptions;
using DataAccess;
using Models;

namespace WebAPI.Controllers;
public class ProfileController
{
    private readonly ProfileServices _services;

    public ProfileController(ProfileServices services)
    {
        _services = services;
    }

    public async Task<IResult> GetAllProfiles()
    {
        var profiles =  await _services.GetAllProfiles();
        return profiles.Count > 0 ? Results.Ok(profiles) : Results.BadRequest("No profiles to get!");   
    }

    public async Task<IResult> GetProfileById(int profile_id)
    {
        var profile = await _services.GetProfileById(profile_id);
        return profile != null ? Results.Ok(profile) : Results.BadRequest("No profile with this ID!");
    }

    public async Task<IResult> GetProfileByUserId(int user_id)
    {
        var profiles = await _services.GetProfileByUserId(user_id);
        return profiles != null ? Results.Ok(profiles) : Results.BadRequest("No profile with this user ID!");
    }

    public async Task<IResult> CreateProfile(Profile profile)
    {
        var createdProfile = await _services.CreateProfile(profile);
        return createdProfile ? Results.Ok(profile) : Results.BadRequest("Invalid profile create!");
    }

    public async Task<IResult> UpdateProfile(Profile profile)
    {
        var updatedProfile = await _services.UpdateProfile(profile);
        return updatedProfile ? Results.Ok(profile) : Results.BadRequest("Invalid profile update!");
    }
}
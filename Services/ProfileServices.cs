using Models;
using DataAccess;
using CustomExceptions;

namespace Services;

public class ProfileServices : IProfileDAO
{
    private readonly IProfileDAO _profileRepo;

    public ProfileServices(IProfileDAO repo)
    {
        _profileRepo = repo;
    }

    public async Task<List<Profile>> GetAllProfiles()
    {
         try
        {
            return await _profileRepo.GetAllProfiles();
        }
        catch (ResourceNotFoundException)
        {
            throw new ResourceNotFoundException();
        }
    }

    public async Task<Profile> GetProfileByUserId(int user_id)
    {
         try
        {
            return await _profileRepo.GetProfileByUserId(user_id);
        }
        catch (ResourceNotFoundException)
        {
            throw new ResourceNotFoundException();
        }
    }
    public async Task<Profile> GetProfileById(int profile_id)
    {
         try
        {
            return await _profileRepo.GetProfileById(profile_id);
        }
        catch (ResourceNotFoundException)
        {
            throw new ResourceNotFoundException();
        }
    }
    public async Task<bool> CreateProfile(Profile profile)
    {
         try
        {
             return await _profileRepo.CreateProfile(profile);
        }
        catch (ResourceNotFoundException)
        {
            throw new ResourceNotFoundException();
        }
    }
    public async Task<bool> UpdateProfile(Profile profile)
    {
         try
        {
            return await _profileRepo.UpdateProfile(profile);
        }
        catch (ResourceNotFoundException)
        {
            throw new ResourceNotFoundException();
        }
    }
}

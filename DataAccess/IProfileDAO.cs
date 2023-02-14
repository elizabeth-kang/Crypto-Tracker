using Models;

namespace DataAccess;

public interface IProfileDAO
{
    Task<List<Profile>> GetAllProfiles();
    Task<Profile> GetProfileById(int profile_id);
    Task<Profile> GetProfileByUserId(int user_id);
    Task<bool> CreateProfile(Profile profile);
    Task<bool> UpdateProfile(Profile profile);
}
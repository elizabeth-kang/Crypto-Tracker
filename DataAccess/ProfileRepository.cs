using Microsoft.EntityFrameworkCore;
using Models;
using CustomExceptions;

namespace DataAccess;

public class ProfileRepository : IProfileDAO
{
    private readonly StonksDbContext _context;
    public ProfileRepository(StonksDbContext context)
    {
        _context = context;
    }
    public async Task<List<Profile>> GetAllProfiles()
    {
        return await _context.Profiles.ToListAsync();
    }
    public async Task<Profile> GetProfileById(int profile_id)
    {
        Profile? foundProfile = await _context.Profiles.FirstOrDefaultAsync(profile => profile.ProfileId == profile_id);
        if(foundProfile != null) return foundProfile;
        throw new RecordNotFoundException("Could not find the currency with such profile");
    }
    public async Task<Profile> GetProfileByUserId(int user_id)
    {
        Profile? foundProfile = await _context.Profiles.FirstOrDefaultAsync(profile => profile.UserIdFk == user_id);
        if(foundProfile != null) return foundProfile;
        throw new RecordNotFoundException("Could not find the currency with such user id");
    }
    public async Task<bool> CreateProfile(Profile profile)
    {
       
        _context.Add(profile);
        await _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();
        return true;
    }
    public async Task<bool> UpdateProfile(Profile profile)
    {

        _context.Update(profile);
        await _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();
        return true;
    }
}
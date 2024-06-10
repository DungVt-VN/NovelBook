using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Repository
{
    public class UserProfileRepo : IUserProfileRepo
    {
        private readonly ApplicationDBContext _context;
        public UserProfileRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<UserProfile> CreateAsync(UserProfile userProfile)
        {
            await _context.UserProfiles.AddAsync(userProfile);
            await _context.SaveChangesAsync();
            return userProfile;
        }

        public Task<UserProfile> UpdateAsync(string userId, UserProfile userProfile)
        {
            throw new NotImplementedException();
        }
    }
}

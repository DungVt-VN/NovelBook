using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IUserProfileRepo
    {
        Task<UserProfile> CreateAsync(UserProfile userProfile);
        Task<UserProfile> UpdateAsync(string userId, UserProfile userProfile);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;

namespace api.Interfaces
{
    public interface IUserRepo
    {
        Task<Boolean> GetExistingEmailAsync(string email);
        Task<List<AppUser>> GetAllUsersAndRoleAsync();
        Task<string> DeleteUserAsync(string id);
        Task<string> ConfirmEmailAsync(string email);
        Task<string> UpdateUserAsync(UpdateUserDto updateUserDto);

    }
}
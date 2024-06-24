using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.User;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace api.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserRepo(ApplicationDBContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<string> ConfirmEmailAsync(string email)
        {
            try
            {
                // Tìm người dùng dựa trên email
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    return "User not found";
                }
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (!result.Succeeded)
                {
                    return "Error confirming email";
                }
            }
            catch (Exception ex)
            {
                return $"Error confirming email: {ex.Message}";
            }
            return "Email confirmed successfully";
        }

        public async Task<string> DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return "User not found";
            }

            try
            {
                var result = await _userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    return "Error deleting user";
                }
            }
            catch (Exception ex)
            {
                return $"Error deleting user: {ex.Message}";
            }
            return "User deleted successfully";
        }

        public async Task<List<AppUser>> GetAllUsersAndRoleAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                user.Roles = roles.ToList();
            }
            return users;
        }

        public async Task<bool> GetExistingEmailAsync(string email)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(e => e.NormalizedEmail == email.ToUpper());

            if (user == null)
            {
                return false;
            }
            return true;
        }

        public async Task<string> UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            // Tìm người dùng theo Id
            var user = await _userManager.FindByIdAsync(updateUserDto.Id);
            if (user == null)
            {
                return "User not found";
            }
            // Cập nhật thông tin người dùng
            user.UserName = updateUserDto.UserName;
            user.Email = updateUserDto.Email;
            user.PhoneNumber = updateUserDto.PhoneNumber;

            // Lưu thông tin người dùng đã cập nhật
            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                // Xử lý lỗi nếu cập nhật không thành công
                return "UserName hoac Email dax ton tai!";
            }

            // Cập nhật vai trò của người dùng
            var existingRoles = await _userManager.GetRolesAsync(user);
            var rolesToRemove = existingRoles.Except(updateUserDto.Roles).ToList();
            var rolesToAdd = updateUserDto.Roles.Except(existingRoles).ToList();

            await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
            await _userManager.AddToRolesAsync(user, rolesToAdd);
            if (updateUserDto.EmailConfirmed != 0)
            {
                DateTimeOffset lockoutEndDate = DateTimeOffset.UtcNow.AddDays(updateUserDto.EmailConfirmed);
                await _userManager.SetLockoutEndDateAsync(user, lockoutEndDate);
            }
            return "Update Successfully";
        }

    }
}
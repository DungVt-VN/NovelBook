using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<AppUser> _userManager;
        public UserRepo(ApplicationDBContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<bool> GetExistingEmailAsync(string email)
        {
            var user  = await _userManager.Users.FirstOrDefaultAsync(e => e.NormalizedEmail == email.ToUpper());

            if(user == null) {
                return false;
            }
            return true;
        }
    }
}
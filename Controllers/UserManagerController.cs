using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("admin/users")]
    [ApiController]
    public class UserManagerController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        public UserManagerController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepo.GetAllUsersAndRoleAsync();
            var usersDto = users.Select(u => u.ToViewUsers()).ToList(); ;
            return Ok(usersDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromBody] string id)
        {
            var message = await _userRepo.DeleteUserAsync(id);
            return Ok(message);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("confirm")]
        public async Task<IActionResult> ConfirmedUser([FromBody] ConfirmEmailRequest email)
        {
            var message = await _userRepo.ConfirmEmailAsync(email.Email);
            return Ok(message);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto)
        {
            var message = await _userRepo.UpdateUserAsync(updateUserDto);
            return Ok(message);
        }

    }
}
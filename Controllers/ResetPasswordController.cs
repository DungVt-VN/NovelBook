using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ResetPasswordController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IMemoryCache _cache;

        public ResetPasswordController(
            UserManager<AppUser> userManager,
            ITokenService tokenService,
            IEmailService emailService,
            IMemoryCache cache)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _emailService = emailService;
            _cache = cache;
        }


        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] FogotPWDto fogotPWDto)
        {
            var normalizedEmail = fogotPWDto.email.ToUpper();
            var user = await _userManager.Users.FirstOrDefaultAsync(e => e.NormalizedEmail == normalizedEmail);
            if (user == null) return NotFound("Email không tồn tại");

            var resetCode = new Random().Next(100000, 999999).ToString();
            // Lưu mã đặt lại vào cache với thời gian hết hạn (ví dụ: 15 phút)
            if (user.Email != null)
                _cache.Set(user.Email, resetCode, TimeSpan.FromMinutes(15));

            if (user.Email != null)
            {
                await _emailService.SendPasswordResetEmail(user.Email, resetCode);
            }

            return Ok("Reset code sent to email.");
        }

        [HttpPost("verifyresetcode")]
        public async Task<IActionResult> VerifyResetCode([FromBody] VerifyResetCodeDto verifyResetCodeDto)
        {
            var user = await _userManager.FindByEmailAsync(verifyResetCodeDto.Email);
            if (user == null)
            {
                return NotFound("Email không tồn tại");
            }
            var cachedResetCode = string.Empty;
            if (user.Email != null)
                cachedResetCode = _cache.Get<string>(user.Email);
            if (cachedResetCode == null || cachedResetCode != verifyResetCodeDto.Code)
            {
                return BadRequest("ResetCode không hợp lệ hoặc đã hết hạn.");
            }

            var result = await _userManager.ResetPasswordAsync(user, await _userManager.GeneratePasswordResetTokenAsync(user), verifyResetCodeDto.NewPassword);
            if (!result.Succeeded)
            {
                return BadRequest("Mã đặt lại mật khẩu không hợp lệ hoặc mật khẩu mới không đủ mạnh.");
            }

            // Xóa mã khỏi cache sau khi sử dụng
            if(user.Email != null ){
                _cache.Remove(user.Email);
            }
            

            return Ok("Đặt lại mật khẩu thành công.");
        }
    }
}
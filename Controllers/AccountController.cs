using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Interfaces;
using api.Models;
using MailKit;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Twitter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepo _userRepo;


        public AccountController(
            ITokenService tokenService,
            IUserRepo userRepo
            )
        {
            _tokenService = tokenService;
            _userRepo = userRepo;
        }

        // Login
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _userRepo.LoginAsync(loginDto);
            if (result == null)
            {
                return Unauthorized("Email or Password incorrect!");
            }
            return Ok(result);
        }

        // Register
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (string.IsNullOrEmpty(registerDto.Password))
                return BadRequest("Password is required");
            var result = await _userRepo.RegisterAsync(registerDto);
            if (result == null)
            {
                return BadRequest("Email or Username already exists!");
            }
            return Ok(result);

        }

        // Logout
        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
                await HttpContext.SignOutAsync(IdentityConstants.TwoFactorUserIdScheme);
                return Ok("Logout Success!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred during logout." + ex.Message);
            }
        }



        // --------------------------------------------------------------------------------------------------------------------


        [HttpGet("login/google")]
        public IActionResult LoginWithGoogle()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!result.Succeeded) return BadRequest();

            var token = await _tokenService.GenerateJwtToken(result.Principal);
            return Ok(new { Token = token });
        }

        [HttpGet("login/facebook")]
        public IActionResult LoginWithFacebook()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("FacebookResponse") };
            return Challenge(properties, FacebookDefaults.AuthenticationScheme);
        }

        [HttpGet("facebook-response")]
        public async Task<IActionResult> FacebookResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!result.Succeeded) return BadRequest();

            var token = await _tokenService.GenerateJwtToken(result.Principal);
            return Ok(new { Token = token });
        }

        [HttpGet("login/twitter")]
        public IActionResult LoginWithTwitter()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("TwitterResponse") };
            return Challenge(properties, TwitterDefaults.AuthenticationScheme);
        }

        [HttpGet("twitter-response")]
        public async Task<IActionResult> TwitterResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!result.Succeeded) return BadRequest();

            var token = await _tokenService.GenerateJwtToken(result.Principal);
            return Ok(new { Token = token });
        }


    }

}

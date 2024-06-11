using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Interfaces;
using api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;

namespace api.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<AppUser> _userManager;

        public TokenService(IConfiguration config, UserManager<AppUser> userManager)
        {
            _config = config;
            _userManager = userManager;
            var signingKey = _config["JWT:SigningKey"];
            if (signingKey != null)
            {
                _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            }
            else
            {
                throw new InvalidOperationException("JWT SigningKey is null.");
            }
        }

        public async Task<string> CreateToken(AppUser user)
        {
            var claims = new List<Claim>();

            if (user.Email != null)
            {
                claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            }

            if (user.UserName != null)
            {
                claims.Add(new Claim(JwtRegisteredClaimNames.GivenName, user.UserName));
            }

            // Get user roles and add them to the claims
            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"],
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

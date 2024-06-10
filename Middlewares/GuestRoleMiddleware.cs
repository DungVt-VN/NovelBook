using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

public class GuestRoleMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;
    private readonly ILogger<GuestRoleMiddleware> _logger;

    public GuestRoleMiddleware(RequestDelegate next, IConfiguration configuration, ILogger<GuestRoleMiddleware> logger)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context == null)
        {
            _logger.LogError("HttpContext is null");
            throw new ArgumentNullException(nameof(context));
        }

        if (context.User?.Identity == null)
        {
            _logger.LogInformation("User or User.Identity is null");
            await _next(context);
            return;
        }

        if (!context.User.Identity.IsAuthenticated)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "guest"),
                new Claim(ClaimTypes.Role, "Guest")
            };

            var signingKey = _configuration["JWT:SigningKey"];
            if (string.IsNullOrEmpty(signingKey))
            {
                _logger.LogError("JWT Signing Key is not configured");
                throw new InvalidOperationException("JWT Signing Key is not configured.");
            }

            _logger.LogDebug("Signing Key: {SigningKey}", signingKey);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            _logger.LogDebug("Generated Token: {Token}", tokenString);

            // Use Append or indexer to add/update the header
            context.Response.Headers["Authorization"] = "Bearer " + tokenString;
        }

        await _next(context);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Dtos.User
{
    public class UserDto
    {
        public string Id { get; set; } = string.Empty;
        public string? UserName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; } = false;
        public string? PhoneNumber { get; set; } = string.Empty;
        public DateTimeOffset? LockoutEnd {get; set;}
        public IList<string>? Roles { get; internal set; }
    }
}
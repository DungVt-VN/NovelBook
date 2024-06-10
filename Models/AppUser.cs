using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace api.Models
{
    public class AppUser : IdentityUser
    {
        public string? UserProfileId { get; set; } // Khóa ngoại tham chiếu đến UserProfile
        public UserProfile? UserProfile { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<UserBook> UserBooks { get; set; } = new List<UserBook>();
    }
}

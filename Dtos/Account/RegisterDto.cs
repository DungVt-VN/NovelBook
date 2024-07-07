using System;
using System.ComponentModel.DataAnnotations;
using api.Data.Enums;

namespace api.Dtos.Account
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Username is required")]
        public required string Username { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public required string Email { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        public required string Password { get; set; }
        
        public string? AvatarURL { get; set; }
        
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "DateOfBirth is required")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        
        [Required(ErrorMessage = "Gender is required")]
        public GenderEnum Gender { get; set; } = GenderEnum.None;
        
        public string Address { get; set; } = string.Empty;
    }
}

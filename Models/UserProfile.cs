using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Data.Enums;

namespace api.Models
{
    public class UserProfile
    {
        [Key]
        public string? UserProfileId { get; set; }

        [Url]
        public string? AvatarURL { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "DateOfBirth is required")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Gender is required")]
        public GenderEnum Gender { get; set; } = GenderEnum.None;

        public string? Address { get; set; } = string.Empty;

        [Required]
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; } = string.Empty;

        [Required]
        public AppUser AppUser { get; set; } = new AppUser();
    }
}

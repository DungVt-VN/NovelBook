using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Data.Enums;

namespace api.Models
{
    public class UserProfile
    {
        [Key]
        public string? UserProfileId { get; set; } = Guid.NewGuid().ToString();// UserProfileId là khóa chính

        [Url]
        [MaxLength(500, ErrorMessage = "Avatar URL cannot exceed 500 characters")]
        public string? AvatarURL { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(100, ErrorMessage = "FirstName cannot exceed 100 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "LastName is required")]
        [MaxLength(100, ErrorMessage = "LastName cannot exceed 100 characters")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "DateOfBirth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public GenderEnum Gender { get; set; } = GenderEnum.None;

        [MaxLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        public string? Address { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public AppUser AppUser { get; set; } = new AppUser();
    }
}

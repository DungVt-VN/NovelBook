using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Account
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}

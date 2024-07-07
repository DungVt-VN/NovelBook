using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class UserBook
    {
        [Key]
        public int UserBookId { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }

        [Required]
        public int BookItemId { get; set; }

        [ForeignKey("BookItemId")]
        public BookItem? BookItem { get; set; }

        public bool Liked { get; set; } = false;
        public bool Followed { get; set; } = false;
        public int Rating { get; set; } = 0;
        public int Viewed { get; set; } = 0;
    }
}

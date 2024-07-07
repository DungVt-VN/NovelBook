using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class AnotherName
    {
        [Key]
        public int AnotherNameId { get; set; }

        [MaxLength(1000, ErrorMessage = "Name cannot exceed 1000 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "BookId is required")]
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public BookItem? BookItem { get; set; }

        public static implicit operator string(AnotherName v)
        {
            throw new NotImplementedException();
        }
    }
}

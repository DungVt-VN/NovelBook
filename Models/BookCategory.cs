using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class BookCategory
    {
        [Key]
        public int BookCategoryId { get; set; }

        [Required]
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public BookItem? BookItem { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class BookCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public int BookId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        [ForeignKey("BookId")]
        public BookItemBase? BookItem { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class BookTag
    {
        [Key]
        public int TagId { get; set; }

        [Required]
        public int BookId { get; set; }

        [ForeignKey("TagId")]
        public Tag? Tag { get; set; }

        [ForeignKey("BookId")]
        public BookItem? BookItem { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class AnotherName
    {
        [Key]
        public int AnotherNameId { get; set; }

        public string? Name { get; set; }

        [Required]
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public BookItemBase? BookItemBase { get; set; }
    }
}

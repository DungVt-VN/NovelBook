using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        [Required]
        public string TagName { get; set; } = string.Empty;

        public ICollection<BookTag>? BookTags { get; set; }
    }
}

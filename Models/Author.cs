using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Pseudonym is required")]
        public string Pseudonym { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }
        public string? Biography { get; set; }

        // Navigation property
        public ICollection<BookItemBase> BookItems { get; set; } = new List<BookItemBase>();
    }
}

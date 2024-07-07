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
        [MaxLength(100, ErrorMessage = "Pseudonym cannot exceed 100 characters")]
        public string Pseudonym { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(2000, ErrorMessage = "Biography cannot exceed 2000 characters")]
        public string? Biography { get; set; }

        // Navigation property
        public ICollection<BookItem> BookItems { get; set; } = new List<BookItem>();
    }
}

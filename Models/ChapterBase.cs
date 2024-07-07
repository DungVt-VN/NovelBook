using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class ChapterBase
    {
        [Key]
        public int ChapterId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public int ChapterNumber { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Content { get; set; } = string.Empty;

        [Required]
        public int LanguageId { get; set; }
        public int Price { get; set; } = 0;

        [Required]
        public DateTime PublishedDate { get; set; } = DateTime.Now;

        public int Viewed { get; set; } = 0;

        // foreignkeys BookItem
        [Required]
        public int BookItemId { get; set; }

        [ForeignKey("BookItemId")]
        public BookItem? BookItem { get; set; }


        // Comment
        public ICollection<Comment>? Comments { get; set; } = new List<Comment>();

        // Nguoi tai len/ nguoi dang
        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }

        // So luong giao dich
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}

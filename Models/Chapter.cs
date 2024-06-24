using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Chapter
    {
        [Key]
        public int ChapterId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public int ChapterNumber { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        public DateTime PublishedDate { get; set; } = DateTime.Now;
        public int viewed { get; set; } = 0;

        public List<Images>? ImageItems { get; set; }

        [Required]
        public int MangaId { get; set; }

        [ForeignKey("MangaId")]
        public Manga? Manga { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Images
    {
        [Key]
        public int ImageId { get; set; }

        [Required, Url]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public int NumericalOrder { get; set; } = 0;

        [Required]
        public int ChapterId { get; set; }

        [ForeignKey("ChapterId")]
        public MangaChapter Chapter { get; set; } = new MangaChapter();
    }
}

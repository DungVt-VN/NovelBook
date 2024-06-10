using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        [Required, Url]
        public string Url { get; set; } = string.Empty;

        [Required]
        public int NumericalOrder { get; set; } = 0;

        [Required]
        public int ChapterId { get; set; }

        [ForeignKey("ChapterId")]
        public Chapter? Chapter { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.Data.Enums;

namespace api.Models
{
    public class BookLine
    {
        public int BookLineId { get; set; }
        public int ChapterId { get; set; }
        [ForeignKey("ChapterId")]
        public NovelChapter Chapter { get; set; } = new NovelChapter();
        public StyleParagraph StyleParagraph { get; set; } = StyleParagraph.Line;
        public int LineNumber { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class NovelChapter : ChapterBase
    {
        public float Volume { get; set; } = -1;
        public ICollection<BookLine> LineItems { get; set; } = new List<BookLine>();
    }
}
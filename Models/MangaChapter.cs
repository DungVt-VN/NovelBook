using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class MangaChapter : ChapterBase
    {
        public ICollection<Images> ImageItems { get; set; } = new List<Images>();
        
    }
}
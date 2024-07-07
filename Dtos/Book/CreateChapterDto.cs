using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.Book
{
    public class CreateChapterDto
    {
        public int ChapterId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ChapterNumber { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public int Viewed { get; set; }
        public List<Images> Images { get; set; } = new List<Images>();
        public int BookItemId { get; set; }
    }
}
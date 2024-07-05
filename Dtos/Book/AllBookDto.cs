using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data.Enums;
using api.Models;

namespace api.Dtos.Book
{
    public class AllBookDto
    {
        public int bookId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NameUrl { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty;
        public string CoverImage { get; set; } = string.Empty;
        public Boolean Actived { get; set; } =false;
        public BookStatusEnum Status { get; set; }
        public int CurrentChapter { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Voted { get; set; }
        public int Rating { get; set; }
        public int Liked { get; set; }
        public int Viewed { get; set; }
        public int Followed { get; set; }
        public int Commented { get; set; }
        public ICollection<String>? Categories { get; set; }    
        public ICollection<String>? Tags { get; set; }
        public ICollection<String>? AnotherNames { get; set; }
    }
    
}
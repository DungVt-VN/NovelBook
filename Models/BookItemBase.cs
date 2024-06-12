using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Data.Enums;
using api.Dtos.Book;

namespace api.Models
{
    public class BookItemBase
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public BookStatusEnum Status { get; set; }
        public int CurrentChapter { get; set; }
        
        [Required]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }

        public int Voted { get; set; } = 0;
        public int Rating { get; set; } = 5;
        public int Liked { get; set; } = 0;
        public int Followed { get; set; } = 0;
        public int Viewed { get; set; } = 0;
        public int Commented { get; set; } = 0;
        public int Chapter { get; set; } = 0;

        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
        public ICollection<BookTag> BookTags { get; set; } = new List<BookTag>();
        public ICollection<AnotherName> AnotherNames { get; set; } = new List<AnotherName>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<UserBook> UserBooks { get; set; } = new List<UserBook>();

        internal AllBookDto ToViewAllBook(string pseudonym, int commentCount, Category? categories)
        {
            throw new NotImplementedException();
        }

        internal object ToViewAllBookAddAuthor(Task<string?> task)
        {
            throw new NotImplementedException();
        }
    }
}

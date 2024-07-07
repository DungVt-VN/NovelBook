using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Data.Enums;

namespace api.Models
{
    public class BookItem
    {
        [Key]
        public int BookId { get; set; }

        private string _name;

        [Required]
        public required string Name
        {
            get => _name;
            set
            {
                _name = value ?? throw new ArgumentNullException(nameof(Name));
                NameUrl = _name.ToLower().Replace(" ", "-");
            }
        }
        
        public string NameUrl { get; set; } = string.Empty;
        public Boolean Actived { get; set; } = false;
        public string CoverImage { get; set; } = string.Empty;
        public BookStatusEnum Status { get; set; }
        public int CurrentChapter { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }

        [Required]
        public string OwnerId { get; set; } = string.Empty;

        [ForeignKey("OwnerId")]
        public AppUser? AppUser { get; set; }

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
        public ICollection<ChapterBase> ChapterList { get; set; } = new List<ChapterBase>();


        // Default constructor
        public BookItem()
        {
            _name = string.Empty;
        }

        // Constructor with name parameter
        public BookItem(string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Data.Enums;

namespace api.Models
{
    public class BookItemBase
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
        public string OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public AppUser AppUser { get; set; }

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

        // Constructor mặc định
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public BookItemBase()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
        }

        // Constructor với tham số name
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public BookItemBase(string name)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public int Likes { get; set; } = 0;

        [Required]
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser? User { get; set; }

        [Required]
        public int BookItemId { get; set; }

        [ForeignKey("BookItemId")]
        public BookItemBase? BookItem { get; set; }

        // One-to-many relationship: a comment can have many replies
        public ICollection<Comment> Replies { get; set; } = new List<Comment>();

        // Many-to-one relationship: a comment belongs to a parent comment (if any)
        public int? ParentCommentId { get; set; }

        [ForeignKey("ParentCommentId")]
        public Comment? ParentComment { get; set; }
    }
}

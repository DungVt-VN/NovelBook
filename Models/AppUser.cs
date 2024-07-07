using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class AppUser : IdentityUser
    {
        public string? UserProfileId { get; set; } // Khóa ngoại tham chiếu đến UserProfile
        public UserProfile? UserProfile { get; set; }

        // So luong xu cua nguoi dung
        public int Balance { get; set; } = 0;


        // Collection of Comments made by the user
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        // Collection of books associated with the user
        public ICollection<UserBook> UserBooks { get; set; } = new List<UserBook>();

        // Roles assigned to the user (this might be redundant with IdentityUser roles management)
        public IList<string>? Roles { get; internal set; }

        // Collection of book items created by the user
        public IList<BookItem> BookItems { get; internal set; } = new List<BookItem>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}

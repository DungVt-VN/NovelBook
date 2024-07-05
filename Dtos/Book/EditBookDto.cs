using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data.Enums;

namespace api.Dtos.Book
{
    public class EditBookDto
    {
        public int BookId { get; set; }
        public Boolean Actived { get; set; } = false;
        public string Name { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty;
        public string CoverImage { get; set; } = string.Empty;
        public BookStatusEnum Status { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string[]? AnotherNames { get; set; }
        public string[]? Categories { get; set; }
        public string[]? Tags { get; set; }
    }
}
using System.Collections.Generic;

namespace api.Models
{
    public class Manga : BookItemBase
    {
        // One-to-many relationship with Chapter
        public ICollection<Chapter>? Chapters { get; set; }
    }
}

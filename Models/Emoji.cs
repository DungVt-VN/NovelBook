using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Emoji
    {
        public int EmojiId { get; set; }
        public int EmojiNumber { get; set; }
        public string EmojiUrl { get; set; } = string.Empty;
    }
}
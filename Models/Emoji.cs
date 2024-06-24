using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Emoji
    {
        public int EmojiId { get; set; }
        public int NumberEmoji { get; set; }
        public string Url { get; set; } = string.Empty;
    }
}
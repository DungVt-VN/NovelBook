using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; } = string.Empty;
        public string LanguageCode { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
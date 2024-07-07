using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Transaction
{
    public class TransactionDto
    {
        [Required]
        public string AppUserId { get; set; } = string.Empty;

        [Required]
        [Range(10000, int.MaxValue, ErrorMessage = "Amount must be at least 10,000 VND")]
        public int Amount { get; set; }
    }

}
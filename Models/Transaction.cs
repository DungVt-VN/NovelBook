using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Transaction
    {
        // Mã giao dịch (8 số ngẫu nhiên)
        public string TransactionId { get; set; } = string.Empty;

        // Số tiền đã nạp (VNĐ)
        public int Amount { get; set; }

        // Số xu tương ứng
        public int Coins { get; set; }

        // Ngày thực hiện giao dịch
        public DateTime TransactionDate { get; set; }

        // Mã người dùng
        public string AppUserId { get; set; } = string.Empty;

        // Người dùng (khoá ngoại)
        [ForeignKey("AppUserId")]
        public AppUser? AppUser { get; set; }

        // Hàm tạo mã giao dịch ngẫu nhiên
        public void GenerateTransactionId()
        {
            Random random = new Random();
            const string chars = "0123456789";
            TransactionId = new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

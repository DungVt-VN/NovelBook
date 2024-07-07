using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Purchase
    {
        // Mã giao dịch mua hàng
        public int PurchaseId { get; set; }

        // Ngày mua hàng
        public DateTime PurchaseDate { get; set; }

        // Mã người dùng
        public string AppUserId { get; set; } = string.Empty;

        // Người dùng (khoá ngoại)
        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; } = new AppUser();

        // Mã chương sách đã mua
        public int ChapterId { get; set; }

        // Chương sách (khoá ngoại)
        [ForeignKey("ChapterId")]
        public ChapterBase Chapter { get; set; } = new ChapterBase();
    }
}

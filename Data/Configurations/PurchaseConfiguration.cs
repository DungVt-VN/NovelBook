using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Configurations
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasOne(p => p.AppUser)
                .WithMany(u => u.Purchases)
                .HasForeignKey(p => p.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Chapter)
                .WithMany(c => c.Purchases)
                .HasForeignKey(p => p.ChapterId)
                .OnDelete(DeleteBehavior.Cascade); // Thay đổi thành DeleteBehavior.Restrict nếu cần thiết
        }
    }
}

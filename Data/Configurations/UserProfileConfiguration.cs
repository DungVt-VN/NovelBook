using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;

namespace api.Data.Configurations
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(u => u.UserProfileId); // Đặt UserProfileId là khóa chính
            builder.HasOne(u => u.AppUser)
                .WithOne(u => u.UserProfile)
                .HasForeignKey<UserProfile>(u => u.UserId)
                .IsRequired();
        }
    }
}

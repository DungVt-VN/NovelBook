using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;

namespace api.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasOne(a => a.UserProfile)
                .WithOne(up => up.AppUser)
                .HasForeignKey<AppUser>(up => up.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(u => u.Email).IsUnique();
            builder.HasIndex(u => u.NormalizedUserName).IsUnique();
            builder.HasIndex(u => u.UserName).IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).IsUnique();
        }
    }
}
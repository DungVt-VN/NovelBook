using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Configurations
{
    public class UserBookConfiguration : IEntityTypeConfiguration<UserBook>
    {
        public void Configure(EntityTypeBuilder<UserBook> builder)
        {
            builder.HasIndex(u => new { u.BookItemId, u.UserId }).IsUnique();

            builder.HasOne(ubi => ubi.AppUser)
                .WithMany(u => u.UserBooks)
                .HasForeignKey(ubi => ubi.UserId);

            builder.HasOne(ubi => ubi.BookItem)
                .WithMany(b => b.UserBooks)
                .HasForeignKey(ubi => ubi.BookItemId);
        }
    }
}
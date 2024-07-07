using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;

namespace api.Data.Configurations
{
    public class BookItemConfiguration : IEntityTypeConfiguration<BookItem>
    {
        public void Configure(EntityTypeBuilder<BookItem> builder)
        {
            builder.HasIndex(u => u.Name).IsUnique();
            builder.HasIndex(u => u.NameUrl).IsUnique();

            builder.HasMany(b => b.AnotherNames)
                .WithOne(a => a.BookItem)
                .HasForeignKey(a => a.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Author)
                .WithMany(a => a.BookItems)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.Comments)
                .WithOne(r => r.BookItem)
                .HasForeignKey(r => r.BookItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.AppUser)
                .WithMany(u => u.BookItems)
                .HasForeignKey(ubi => ubi.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
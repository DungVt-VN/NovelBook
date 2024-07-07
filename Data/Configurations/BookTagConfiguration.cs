using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Configurations
{
    public class BookTagConfiguration : IEntityTypeConfiguration<BookTag>
    {
        public void Configure(EntityTypeBuilder<BookTag> builder)
        {
            builder.HasKey(bt => new { bt.BookId, bt.TagId });

            builder.HasOne(bt => bt.BookItem)
                .WithMany(b => b.BookTags)
                .HasForeignKey(bt => bt.BookId);

            builder.HasOne(bt => bt.Tag)
                .WithMany(t => t.BookTags)
                .HasForeignKey(bt => bt.TagId);
        }
    }
}
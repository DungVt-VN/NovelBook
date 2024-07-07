using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;

namespace api.Data.Configurations
{
    public class ChapterBaseConfiguration : IEntityTypeConfiguration<ChapterBase>
    {
        public void Configure(EntityTypeBuilder<ChapterBase> builder)
        {
            builder.HasIndex(u => new { u.ChapterNumber, u.BookItemId }).IsUnique();
            builder.HasOne(b => b.BookItem)
                .WithMany(b => b.ChapterList)
                .HasForeignKey(b => b.BookItemId)
                .OnDelete(DeleteBehavior.Cascade);

            // Table Per Hierarchy
            builder.ToTable("Chapters");
        }
    }
}
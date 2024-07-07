using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;

namespace api.Data.Configurations
{
    public class BookLineConfiguration : IEntityTypeConfiguration<BookLine>
    {
        public void Configure(EntityTypeBuilder<BookLine> builder)
        {
            builder.HasIndex(u => new { u.LineNumber, u.ChapterId }).IsUnique();
            builder.HasOne(p => p.Chapter)
                .WithMany(b => b.LineItems)
                .HasForeignKey(p => p.ChapterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
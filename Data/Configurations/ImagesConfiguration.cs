using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;

namespace api.Data.Configurations
{
    public class ImagesConfiguration : IEntityTypeConfiguration<Images>
    {
        public void Configure(EntityTypeBuilder<Images> builder)
        {
            builder.HasIndex(u => new { u.NumericalOrder, u.ChapterId }).IsUnique();
            builder.HasOne(p => p.Chapter)
                .WithMany(b => b.ImageItems)
                .HasForeignKey(p => p.ChapterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Configurations
{
    public class MangaChapterConfiguration : IEntityTypeConfiguration<MangaChapter>
    {
        public void Configure(EntityTypeBuilder<MangaChapter> builder)
        {
            builder.ToTable("MangaChapters");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;

namespace api.Data.Configurations
{
    public class NovelChapterConfiguration : IEntityTypeConfiguration<NovelChapter>
    {
        public void Configure(EntityTypeBuilder<NovelChapter> builder)
        {
            builder.ToTable("NovelChapters");
        }
    }
}
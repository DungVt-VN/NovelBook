using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data.Configurations;
using api.Data.Seeding;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public virtual DbSet<BookItem> BookItems { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<ChapterBase> Chapters { get; set; }
        public virtual DbSet<NovelChapter> NovelChapters { get; set; }
        public virtual DbSet<MangaChapter> MangaChapters { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }
        public virtual DbSet<BookTag> BookTags { get; set; }
        public virtual DbSet<AnotherName> AnotherNames { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<UserBook> UserBooks { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Emoji> Emojis { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // AppUser and UserProfile
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new UserProfileConfiguration());
            builder.ApplyConfiguration(new BookItemConfiguration());
            builder.ApplyConfiguration(new ChapterBaseConfiguration());
            builder.ApplyConfiguration(new NovelChapterConfiguration());
            builder.ApplyConfiguration(new MangaChapterConfiguration());
            builder.ApplyConfiguration(new BookLineConfiguration());
            builder.ApplyConfiguration(new ImagesConfiguration());
            builder.ApplyConfiguration(new UserBookConfiguration());
            builder.ApplyConfiguration(new BookCategoryConfiguration());
            builder.ApplyConfiguration(new BookTagConfiguration());
            builder.ApplyConfiguration(new TransactionConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new AuthorConfiguration());
            builder.ApplyConfiguration(new PurchaseConfiguration());

            // Seeding data 
            builder.ApplyConfiguration<AppUser>(new RoleAdminSeed());
            builder.ApplyConfiguration<IdentityRole>(new RoleAdminSeed());
            builder.ApplyConfiguration<IdentityUserRole<string>>(new RoleAdminSeed());
        }
    }
}

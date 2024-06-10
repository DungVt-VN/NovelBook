using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookItemBase> BookItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Cấu hình TPT (Table Per Type) cho các thực thể kế thừa
            builder.Entity<BookItemBase>().ToTable("BookItems");
            builder.Entity<Manga>().ToTable("Mangas");

            // Thiết lập quan hệ một-một giữa AppUser và UserProfile
            builder.Entity<AppUser>()
                .HasOne(u => u.UserProfile)
                .WithOne(p => p.AppUser)
                .HasForeignKey<UserProfile>(p => p.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập quan hệ một-nhiều giữa BookItemBase và AnotherName
            builder.Entity<BookItemBase>()
               .HasMany(b => b.AnotherNames)
               .WithOne(a => a.BookItemBase)
               .HasForeignKey(a => a.BookId)
               .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập quan hệ nhiều-nhiều giữa BookItemBase và Category
            builder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });
            builder.Entity<BookCategory>()
               .HasOne(bc => bc.BookItem)
               .WithMany(b => b.BookCategories)
               .HasForeignKey(bc => bc.BookId);
            builder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);

            // Thiết lập quan hệ nhiều-nhiều giữa BookItemBase và Tag
            builder.Entity<BookTag>()
               .HasKey(bt => new { bt.BookId, bt.TagId });
            builder.Entity<BookTag>()
               .HasOne(bt => bt.BookItem)
               .WithMany(b => b.BookTags)
               .HasForeignKey(bt => bt.BookId);
            builder.Entity<BookTag>()
               .HasOne(bt => bt.Tag)
               .WithMany(t => t.BookTags)
               .HasForeignKey(bt => bt.TagId);

            // Thiết lập quan hệ một-nhiều giữa Author và BookItemBase
            builder.Entity<BookItemBase>()
                .HasOne(b => b.Author)
                .WithMany(a => a.BookItems)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập quan hệ một-nhiều giữa AppUser và Comment
            builder.Entity<AppUser>()
                .HasMany(a => a.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập quan hệ một-nhiều giữa BookItemBase và Comments
            builder.Entity<BookItemBase>()
                .HasMany(b => b.Comments)
                .WithOne(r => r.BookItem)
                .HasForeignKey(r => r.BookItemId)
                .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập quan hệ một-nhiều giữa Comment và Comments
            builder.Entity<Comment>()
                .HasOne(c => c.ParentComment)
                .WithMany(c => c.Replies)
                .HasForeignKey(c => c.ParentCommentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Thiết lập quan hệ một-nhiều giữa Manga và Chapter
            builder.Entity<Chapter>()
                .HasOne(b => b.Manga) // Mỗi Chapter chỉ thuộc về một BookItemBase
                .WithMany(b => b.Chapters) // Một BookItemBase có thể có nhiều Chapter
                .HasForeignKey(b => b.MangaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập quan hệ một-nhiều giữa Chapter và Image
            builder.Entity<Image>()
                .HasOne(p => p.Chapter)
                .WithMany(b => b.Images)
                .HasForeignKey(p => p.ChapterId)
                .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập quan hệ nhiều-nhiều giữa AppUser và BookItemBase
            builder.Entity<UserBook>()
                .HasKey(ubi => new { ubi.UserId, ubi.BookItemId });

            builder.Entity<UserBook>()
                .HasOne(ubi => ubi.AppUser)
                .WithMany(u => u.UserBooks)
                .HasForeignKey(ubi => ubi.UserId);

            builder.Entity<UserBook>()
                .HasOne(ubi => ubi.BookItem)
                .WithMany(b => b.UserBooks)
                .HasForeignKey(ubi => ubi.BookItemId);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                    // Truy cập và kiểm soát toàn bộ hệ thống.
                    // Thêm, sửa, xóa người dùng và phân quyền cho họ.
                    // Quản lý nội dung trên toàn hệ thống, bao gồm duyệt, chỉnh sửa, xóa bất kỳ nội dung nào của bất kỳ người dùng nào.
                    // Quản lý cấu hình hệ thống và các thiết lập khác.
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                    // Đăng nhập vào website.
                    // Truy cập và sử dụng các tính năng cơ bản của website.
                    // Tạo và quản lý nội dung cá nhân (nếu có).
                    // Có thể tương tác với nội dung, như bình luận, đánh giá, chia sẻ.
                    // Thường có tài khoản được đăng ký.
                },
                new IdentityRole {
                    Name = "Moderator",
                    NormalizedName = "MODERATOR"
                    // Duyệt, chỉnh sửa hoặc xóa nội dung của người dùng khác để đảm bảo tính phù hợp và chất lượng của nội dung.
                    // Quản lý bình luận và phản hồi từ người dùng.
                    // Có thể cấp quyền cho người dùng khác.
                    // Hỗ trợ người dùng về các vấn đề kỹ thuật hoặc thắc mắc liên quan đến sản phẩm hoặc dịch vụ.
                    // Có thể có quyền truy cập vào hệ thống để giải quyết các vấn đề của người dùng.
                },
                new IdentityRole {
                    Name = "Editor",
                    NormalizedName = "EDITOR"
                    // Tạo, chỉnh sửa và xuất bản nội dung trên website.
                    // Quản lý bài viết, hình ảnh, video, v.v.
                    // Có quyền truy cập vào các tính năng biên tập và xuất bản nội dung.
                    // Có thể làm chủ việc quản lý và chỉnh sửa nội dung cá nhân hoặc nội dung mà họ đã tạo.
                    // Quản lý và tổ chức nội dung trên trang web, bao gồm việc tạo ra các danh mục, thẻ, hoặc phân loại nội dung.
                    // Có thể thực hiện các hoạt động kiểm tra nội dung để đảm bảo tính đúng đắn, tính chất lượng và tuân thủ các quy định.
                },
                new IdentityRole {
                    Name = "Creator",
                    NormalizedName = "CREATOR"
                    // Tạo nội dung mới: Creators chủ yếu tập trung vào việc tạo ra nội dung mới, bao gồm việc viết bài, tạo hình ảnh, video, hoặc các tác phẩm sáng tạo khác.
                    // Quản lý nội dung cá nhân: Họ có thể quản lý và duy trì các tác phẩm hoặc nội dung mà họ đã tạo ra, bao gồm việc chỉnh sửa, cập nhật hoặc xóa.
                    // Chia sẻ và phổ biến nội dung: Creators thường chia sẻ nội dung của mình với cộng đồng hoặc đối tác thông qua các kênh truyền thông xã hội hoặc các nền tảng khác.
                    // Tương tác với người dùng: Họ có thể tương tác với người dùng để nhận phản hồi hoặc phản đối từ đối tác.
                },
                new IdentityRole {
                    Name = "Premium",
                    NormalizedName = "PREMIUM"
                    // Được cấp quyền truy cập vào các tính năng cao cấp.
                },
                new IdentityRole {
                    Name = "Guest",
                    NormalizedName = "GUEST"
                    // Được cấp quyền truy cập vào các tính năng cơ bản.
                    // Không cần đăng nhập.
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}

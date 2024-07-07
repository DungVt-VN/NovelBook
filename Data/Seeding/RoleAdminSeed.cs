using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using api.Models; // Assuming your AppUser class is defined here

namespace api.Data.Seeding
{
    public class RoleAdminSeed : IEntityTypeConfiguration<AppUser>, IEntityTypeConfiguration<IdentityRole>, IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        private List<AppUser> _users = new List<AppUser>();
        private List<IdentityRole> _roles = new List<IdentityRole>();
        private List<IdentityUserRole<string>> _userRoles = new List<IdentityUserRole<string>>();
        private static readonly string AdminUserId = Guid.NewGuid().ToString();
        private static readonly string AdminRoleId = Guid.NewGuid().ToString();

        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            AppUser tempUser = new AppUser();
            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            _users.Add(
                new AppUser
                {
                    Id = AdminUserId,
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@localhost",
                    NormalizedEmail = "ADMIN@LOCALHOST",
                    EmailConfirmed = true,
                    PasswordHash = passwordHasher.HashPassword(tempUser, "Admin123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = false,
                    LockoutEnd = DateTimeOffset.UtcNow.AddDays(-1)
                }
            );

            builder.HasData(_users);
        }
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            _roles.AddRange(new[]
            {
                new IdentityRole
                {
                    Id = AdminRoleId,
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
                new IdentityRole
                {
                    Name = "Moderator",
                    NormalizedName = "MODERATOR"
                    // Duyệt, chỉnh sửa hoặc xóa nội dung của người dùng khác để đảm bảo tính phù hợp và chất lượng của nội dung.
                    // Quản lý bình luận và phản hồi từ người dùng.
                    // Có thể cấp quyền cho người dùng khác.
                    // Hỗ trợ người dùng về các vấn đề kỹ thuật hoặc thắc mắc liên quan đến sản phẩm hoặc dịch vụ.
                    // Có thể có quyền truy cập vào hệ thống để giải quyết các vấn đề của người dùng.
                },
                new IdentityRole
                {
                    Name = "Editor",
                    NormalizedName = "EDITOR"
                    // Tạo, chỉnh sửa và xuất bản nội dung trên website.
                    // Quản lý bài viết, hình ảnh, video, v.v.
                    // Có quyền truy cập vào các tính năng biên tập và xuất bản nội dung.
                    // Có thể làm chủ việc quản lý và chỉnh sửa nội dung cá nhân hoặc nội dung mà họ đã tạo.
                    // Quản lý và tổ chức nội dung trên trang web, bao gồm việc tạo ra các danh mục, thẻ, hoặc phân loại nội dung.
                    // Có thể thực hiện các hoạt động kiểm tra nội dung để đảm bảo tính đúng đắn, tính chất lượng và tuân thủ các quy định.
                },
                new IdentityRole
                {
                    Name = "Creator",
                    NormalizedName = "CREATOR"
                    // Tạo nội dung mới: Creators chủ yếu tập trung vào việc tạo ra nội dung mới, bao gồm việc viết bài, tạo hình ảnh, video, hoặc các tác phẩm sáng tạo khác.
                    // Quản lý nội dung cá nhân: Họ có thể quản lý và duy trì các tác phẩm hoặc nội dung mà họ đã tạo ra, bao gồm việc chỉnh sửa, cập nhật hoặc xóa.
                    // Chia sẻ và phổ biến nội dung: Creators thường chia sẻ nội dung của mình với cộng đồng hoặc đối tác thông qua các kênh truyền thông xã hội hoặc các nền tảng khác.
                    // Tương tác với người dùng: Họ có thể tương tác với người dùng để nhận phản hồi hoặc phản đối từ đối tác.
                },
                new IdentityRole
                {
                    Name = "Premium",
                    NormalizedName = "PREMIUM"
                    // Được cấp quyền truy cập vào các tính năng cao cấp.
                },
                new IdentityRole
                {
                    Name = "Guest",
                    NormalizedName = "GUEST"
                    // Được cấp quyền truy cập vào các tính năng cơ bản.
                    // Không cần đăng nhập.
                }
            });

            builder.HasData(_roles);
        }

        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            _userRoles.Add(
                new IdentityUserRole<string>
                {
                    UserId = AdminUserId,
                    RoleId = AdminRoleId,
                }
            );
            builder.HasData(_userRoles);
        }
    }
}

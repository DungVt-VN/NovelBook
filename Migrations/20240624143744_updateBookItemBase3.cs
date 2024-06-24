using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class updateBookItemBase3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1da866c9-af30-408a-bde3-ceb12713f14f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "251fb57e-8e34-43b2-b597-7c37ed053133");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "270ff5a1-6900-41c5-94fb-26aae68225f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52361b33-a3a4-4690-8123-b4273f75680f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8751f3c4-0e31-407f-b8d3-1b100ac0f3af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "894908cf-98fd-4728-ad48-2a727994f101");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a913a7c-c7da-4714-9fc9-4300b5a63d72");

            migrationBuilder.AddColumn<bool>(
                name: "Actived",
                table: "BookItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b8367d9-df3a-42a8-9d04-62c6fd66ce2b", null, "Guest", "GUEST" },
                    { "2caba31f-9cc4-46d2-a61a-c9e8615b6598", null, "Admin", "ADMIN" },
                    { "728673fa-fbf9-4531-b6ea-f888a07127f6", null, "User", "USER" },
                    { "7dd2e853-4419-40a7-a52a-9f9aa4182f84", null, "Premium", "PREMIUM" },
                    { "aab3fc2f-e619-4850-87b2-d661d911fd52", null, "Moderator", "MODERATOR" },
                    { "d5a978c2-95c8-43c4-bf33-5c001ad74d15", null, "Editor", "EDITOR" },
                    { "ed6dee2e-ee7a-4dd9-ac5e-18af77ec892a", null, "Creator", "CREATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b8367d9-df3a-42a8-9d04-62c6fd66ce2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2caba31f-9cc4-46d2-a61a-c9e8615b6598");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "728673fa-fbf9-4531-b6ea-f888a07127f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dd2e853-4419-40a7-a52a-9f9aa4182f84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aab3fc2f-e619-4850-87b2-d661d911fd52");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5a978c2-95c8-43c4-bf33-5c001ad74d15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed6dee2e-ee7a-4dd9-ac5e-18af77ec892a");

            migrationBuilder.DropColumn(
                name: "Actived",
                table: "BookItems");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1da866c9-af30-408a-bde3-ceb12713f14f", null, "Admin", "ADMIN" },
                    { "251fb57e-8e34-43b2-b597-7c37ed053133", null, "Editor", "EDITOR" },
                    { "270ff5a1-6900-41c5-94fb-26aae68225f3", null, "Moderator", "MODERATOR" },
                    { "52361b33-a3a4-4690-8123-b4273f75680f", null, "Creator", "CREATOR" },
                    { "8751f3c4-0e31-407f-b8d3-1b100ac0f3af", null, "User", "USER" },
                    { "894908cf-98fd-4728-ad48-2a727994f101", null, "Guest", "GUEST" },
                    { "8a913a7c-c7da-4714-9fc9-4300b5a63d72", null, "Premium", "PREMIUM" }
                });
        }
    }
}

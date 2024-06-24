using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class updateEmoji2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bb6346c-76b2-46af-b408-cedd1584692e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e52b135-d7b2-4d8d-83f4-89f7af2719aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5d7eb5e-1dde-44d5-9fdd-81a5ab97f7a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c70a7cd3-ee2e-47f8-9b44-098476c787bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca492d43-4be9-4d9f-a082-2fa06ad89dc5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7efd742-b5dd-4a15-99ce-638609b3d0a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4041162-881a-4300-813c-9b32414b3e0c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "244897a8-9d7c-48ef-8039-d601e268456b", null, "Editor", "EDITOR" },
                    { "61c5b0f1-a2ca-427c-9f4f-29db4ee7822e", null, "Premium", "PREMIUM" },
                    { "a943761e-7e5b-4d41-9842-5ef960ea0131", null, "Moderator", "MODERATOR" },
                    { "af9eb7a9-6057-45f0-9fe4-3e1c85a4363d", null, "Guest", "GUEST" },
                    { "b4bb1439-8fee-4551-954b-973aaf0c41d1", null, "Creator", "CREATOR" },
                    { "de45a0e3-b6c5-4cbb-b725-6171d2dde447", null, "User", "USER" },
                    { "ef282113-2947-495f-8bcb-a7702be3a4a0", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "244897a8-9d7c-48ef-8039-d601e268456b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61c5b0f1-a2ca-427c-9f4f-29db4ee7822e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a943761e-7e5b-4d41-9842-5ef960ea0131");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af9eb7a9-6057-45f0-9fe4-3e1c85a4363d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4bb1439-8fee-4551-954b-973aaf0c41d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de45a0e3-b6c5-4cbb-b725-6171d2dde447");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef282113-2947-495f-8bcb-a7702be3a4a0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5bb6346c-76b2-46af-b408-cedd1584692e", null, "Editor", "EDITOR" },
                    { "5e52b135-d7b2-4d8d-83f4-89f7af2719aa", null, "User", "USER" },
                    { "b5d7eb5e-1dde-44d5-9fdd-81a5ab97f7a0", null, "Admin", "ADMIN" },
                    { "c70a7cd3-ee2e-47f8-9b44-098476c787bf", null, "Moderator", "MODERATOR" },
                    { "ca492d43-4be9-4d9f-a082-2fa06ad89dc5", null, "Guest", "GUEST" },
                    { "e7efd742-b5dd-4a15-99ce-638609b3d0a3", null, "Creator", "CREATOR" },
                    { "f4041162-881a-4300-813c-9b32414b3e0c", null, "Premium", "PREMIUM" }
                });
        }
    }
}

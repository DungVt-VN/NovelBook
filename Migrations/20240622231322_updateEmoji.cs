using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class updateEmoji : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05bac651-06ed-4432-918a-c6944c7118e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "258795c5-1a31-41ba-878a-8969f5708742");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4af9a82f-7aa8-41c5-9b2a-da835a622fe2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58c4d329-b7cd-4fbc-91a2-543c1cf8e4cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b152f5e-be66-4526-8f2f-5338b8b48d58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dd7d45b-9f21-468c-bf9d-9d4c12342eea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9645206e-a927-4ffd-8950-e4bfef27150b");

            migrationBuilder.CreateTable(
                name: "Emojis",
                columns: table => new
                {
                    EmojiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberEmoji = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emojis", x => x.EmojiId);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emojis");

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
                    { "05bac651-06ed-4432-918a-c6944c7118e1", null, "Admin", "ADMIN" },
                    { "258795c5-1a31-41ba-878a-8969f5708742", null, "User", "USER" },
                    { "4af9a82f-7aa8-41c5-9b2a-da835a622fe2", null, "Moderator", "MODERATOR" },
                    { "58c4d329-b7cd-4fbc-91a2-543c1cf8e4cf", null, "Guest", "GUEST" },
                    { "7b152f5e-be66-4526-8f2f-5338b8b48d58", null, "Premium", "PREMIUM" },
                    { "8dd7d45b-9f21-468c-bf9d-9d4c12342eea", null, "Editor", "EDITOR" },
                    { "9645206e-a927-4ffd-8950-e4bfef27150b", null, "Creator", "CREATOR" }
                });
        }
    }
}

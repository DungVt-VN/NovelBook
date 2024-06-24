using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class updateEmoji3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "3769f350-73fd-4420-b25f-0c5856f3bdc6", null, "Guest", "GUEST" },
                    { "976417ac-6aed-496c-bf89-1fc77b4c8a7c", null, "Moderator", "MODERATOR" },
                    { "9dbc380c-fb6f-46c4-8405-87fb207402ae", null, "Creator", "CREATOR" },
                    { "a4b82c69-587e-4a98-b0fb-7192190e304f", null, "Editor", "EDITOR" },
                    { "c9e2b88a-f8d8-4997-bbc4-09b75002dd2d", null, "User", "USER" },
                    { "f497dc61-82cc-4f2b-b06a-c9e797d68f13", null, "Premium", "PREMIUM" },
                    { "fd144a95-f28a-4b6a-a6a0-a8c7c778f9d4", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3769f350-73fd-4420-b25f-0c5856f3bdc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "976417ac-6aed-496c-bf89-1fc77b4c8a7c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9dbc380c-fb6f-46c4-8405-87fb207402ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4b82c69-587e-4a98-b0fb-7192190e304f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9e2b88a-f8d8-4997-bbc4-09b75002dd2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f497dc61-82cc-4f2b-b06a-c9e797d68f13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd144a95-f28a-4b6a-a6a0-a8c7c778f9d4");

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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class updateEmoji5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "1da866c9-af30-408a-bde3-ceb12713f14f", null, "Admin", "ADMIN" },
                    { "251fb57e-8e34-43b2-b597-7c37ed053133", null, "Editor", "EDITOR" },
                    { "270ff5a1-6900-41c5-94fb-26aae68225f3", null, "Moderator", "MODERATOR" },
                    { "52361b33-a3a4-4690-8123-b4273f75680f", null, "Creator", "CREATOR" },
                    { "8751f3c4-0e31-407f-b8d3-1b100ac0f3af", null, "User", "USER" },
                    { "894908cf-98fd-4728-ad48-2a727994f101", null, "Guest", "GUEST" },
                    { "8a913a7c-c7da-4714-9fc9-4300b5a63d72", null, "Premium", "PREMIUM" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}

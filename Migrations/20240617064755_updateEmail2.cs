using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class updateEmail2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29d48bab-89f8-47d1-aa89-f39c3bb4a1bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36c433bd-cf7c-4370-8fc7-3c652f916f9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6307a94a-4047-47a3-b2e4-c1ec78ecff49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7385780a-103f-4027-81af-d84ff135c4e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8138b755-33dc-4692-9b36-a1e7322bd3e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0218a26-8998-447d-acfe-c092765e62e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4963688-88b6-4f04-a451-8b69f097cbcd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5d80a7f5-a515-47f1-a7c5-906b1198efdf", null, "User", "USER" },
                    { "6d998896-fe61-42c0-b4e8-429bc3ee622c", null, "Moderator", "MODERATOR" },
                    { "6ef75a18-a507-4f98-8c75-ee6e355a4f7d", null, "Guest", "GUEST" },
                    { "93bb6a62-1eea-428e-babd-8931c9b4ade7", null, "Premium", "PREMIUM" },
                    { "9feda044-42fb-42b4-ae64-7e9a02dd8227", null, "Admin", "ADMIN" },
                    { "a7390a21-e4d8-46ae-8fcb-6a2064d690e0", null, "Editor", "EDITOR" },
                    { "f392e91d-43a7-49de-a82f-85b0a755fb51", null, "Creator", "CREATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d80a7f5-a515-47f1-a7c5-906b1198efdf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d998896-fe61-42c0-b4e8-429bc3ee622c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ef75a18-a507-4f98-8c75-ee6e355a4f7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93bb6a62-1eea-428e-babd-8931c9b4ade7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9feda044-42fb-42b4-ae64-7e9a02dd8227");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7390a21-e4d8-46ae-8fcb-6a2064d690e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f392e91d-43a7-49de-a82f-85b0a755fb51");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29d48bab-89f8-47d1-aa89-f39c3bb4a1bd", null, "Guest", "GUEST" },
                    { "36c433bd-cf7c-4370-8fc7-3c652f916f9f", null, "Admin", "ADMIN" },
                    { "6307a94a-4047-47a3-b2e4-c1ec78ecff49", null, "Premium", "PREMIUM" },
                    { "7385780a-103f-4027-81af-d84ff135c4e3", null, "Editor", "EDITOR" },
                    { "8138b755-33dc-4692-9b36-a1e7322bd3e2", null, "User", "USER" },
                    { "c0218a26-8998-447d-acfe-c092765e62e0", null, "Creator", "CREATOR" },
                    { "f4963688-88b6-4f04-a451-8b69f097cbcd", null, "Moderator", "MODERATOR" }
                });
        }
    }
}

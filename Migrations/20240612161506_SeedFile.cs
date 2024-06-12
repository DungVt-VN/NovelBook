using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f49993e-3a12-4287-95bd-615e69f2ee05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c57d190-56f0-4907-8fcb-c6acf05feb46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5eee0eb2-4125-4173-a02a-34725a667bdf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "698a3134-754e-4d90-94bc-8fe79d4850ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fadafa2-2561-457f-b4a7-efebaebc81bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70c5a6ee-3fa3-4b23-aab6-69929b2afb9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85f3eead-3b31-4396-bfb5-91585e582e52");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0751d4a2-8f31-415b-9d24-e70498ff4372", null, "User", "USER" },
                    { "11fc28de-f450-454b-a6b0-e1efd4faa106", null, "Editor", "EDITOR" },
                    { "1d6771c2-4ccd-4046-9e4e-25202faae4be", null, "Moderator", "MODERATOR" },
                    { "7d4d1fc4-feee-49c4-af26-15f5755854cc", null, "Guest", "GUEST" },
                    { "c015dafd-6dde-4d42-8636-743d159791ac", null, "Creator", "CREATOR" },
                    { "d5d85724-af1d-4ff6-90f6-7d9127855ef6", null, "Admin", "ADMIN" },
                    { "e18aa243-587f-41b4-b0f4-80400dc128af", null, "Premium", "PREMIUM" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0751d4a2-8f31-415b-9d24-e70498ff4372");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11fc28de-f450-454b-a6b0-e1efd4faa106");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d6771c2-4ccd-4046-9e4e-25202faae4be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d4d1fc4-feee-49c4-af26-15f5755854cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c015dafd-6dde-4d42-8636-743d159791ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5d85724-af1d-4ff6-90f6-7d9127855ef6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e18aa243-587f-41b4-b0f4-80400dc128af");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f49993e-3a12-4287-95bd-615e69f2ee05", null, "Editor", "EDITOR" },
                    { "3c57d190-56f0-4907-8fcb-c6acf05feb46", null, "Admin", "ADMIN" },
                    { "5eee0eb2-4125-4173-a02a-34725a667bdf", null, "User", "USER" },
                    { "698a3134-754e-4d90-94bc-8fe79d4850ea", null, "Guest", "GUEST" },
                    { "6fadafa2-2561-457f-b4a7-efebaebc81bd", null, "Creator", "CREATOR" },
                    { "70c5a6ee-3fa3-4b23-aab6-69929b2afb9e", null, "Premium", "PREMIUM" },
                    { "85f3eead-3b31-4396-bfb5-91585e582e52", null, "Moderator", "MODERATOR" }
                });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class updateEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27314f7c-4d6a-4444-8874-2eb9a905251c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2775c7a8-fff5-47fd-ae94-d55bd3a5d59f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350683ec-4d84-4415-9a8b-22a97e894826");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6489bd71-afff-4dd6-b84c-e5c826f57a0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ea9c35c-aef2-45ae-8aa4-449987afb0d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9424011d-bb0c-46ca-ac72-1cb798acaa25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b587a311-c997-4c16-bec0-717f22859ba6");

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

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail",
                unique: true,
                filter: "[NormalizedEmail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers");

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
                    { "27314f7c-4d6a-4444-8874-2eb9a905251c", null, "Premium", "PREMIUM" },
                    { "2775c7a8-fff5-47fd-ae94-d55bd3a5d59f", null, "Moderator", "MODERATOR" },
                    { "350683ec-4d84-4415-9a8b-22a97e894826", null, "Creator", "CREATOR" },
                    { "6489bd71-afff-4dd6-b84c-e5c826f57a0b", null, "Guest", "GUEST" },
                    { "6ea9c35c-aef2-45ae-8aa4-449987afb0d2", null, "Admin", "ADMIN" },
                    { "9424011d-bb0c-46ca-ac72-1cb798acaa25", null, "Editor", "EDITOR" },
                    { "b587a311-c997-4c16-bec0-717f22859ba6", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");
        }
    }
}

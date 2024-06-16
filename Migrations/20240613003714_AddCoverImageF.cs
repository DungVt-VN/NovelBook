using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddCoverImageF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "CoverImage",
                table: "BookItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "BookItems");

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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class updateOwnerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0066cc7d-e0c8-4f93-9572-d2a621d330ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28dd2aae-2e93-4dbb-9e15-7feb6898aa86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3aec97ff-b6a9-4dd3-b233-b6f306281e06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f02b35c-9dfa-42bf-a36f-9e4ba825ab60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "719bc395-87af-4173-adbe-3a9896c92223");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce2fd535-b75f-4c93-a242-11373a8e1887");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f005f3e4-dd80-405c-97c5-ce8e89b7b30d");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "BookItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "BookItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "149ff61d-993b-4875-a639-39725d8146a3", null, "Editor", "EDITOR" },
                    { "52a55c9f-a20c-44f3-a2f6-ae08dd68a6f6", null, "User", "USER" },
                    { "ac67cbda-aa08-4a82-a53b-e472a75be5d1", null, "Moderator", "MODERATOR" },
                    { "bcb1296d-85d3-4017-a625-3ef9a63b712b", null, "Creator", "CREATOR" },
                    { "e08ecf85-e268-48d4-a3ee-ea98a079ec86", null, "Admin", "ADMIN" },
                    { "e6859859-4139-4067-8ba0-b8bc5e978064", null, "Guest", "GUEST" },
                    { "e8bc47f9-f14c-460a-97d4-b65e8b5095f0", null, "Premium", "PREMIUM" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "149ff61d-993b-4875-a639-39725d8146a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52a55c9f-a20c-44f3-a2f6-ae08dd68a6f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac67cbda-aa08-4a82-a53b-e472a75be5d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bcb1296d-85d3-4017-a625-3ef9a63b712b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e08ecf85-e268-48d4-a3ee-ea98a079ec86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6859859-4139-4067-8ba0-b8bc5e978064");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8bc47f9-f14c-460a-97d4-b65e8b5095f0");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "BookItems");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "BookItems");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0066cc7d-e0c8-4f93-9572-d2a621d330ed", null, "Admin", "ADMIN" },
                    { "28dd2aae-2e93-4dbb-9e15-7feb6898aa86", null, "Guest", "GUEST" },
                    { "3aec97ff-b6a9-4dd3-b233-b6f306281e06", null, "Editor", "EDITOR" },
                    { "6f02b35c-9dfa-42bf-a36f-9e4ba825ab60", null, "Moderator", "MODERATOR" },
                    { "719bc395-87af-4173-adbe-3a9896c92223", null, "Premium", "PREMIUM" },
                    { "ce2fd535-b75f-4c93-a242-11373a8e1887", null, "Creator", "CREATOR" },
                    { "f005f3e4-dd80-405c-97c5-ce8e89b7b30d", null, "User", "USER" }
                });
        }
    }
}

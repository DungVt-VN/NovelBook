using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class updateOwnerId2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "BookItems",
                newName: "AppUser");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "046e5edd-3454-4a91-b5ca-fbb9ecfc51e5", null, "Moderator", "MODERATOR" },
                    { "55532218-0ffb-47d8-a9bc-c7fdab2c3b51", null, "Editor", "EDITOR" },
                    { "7cafdc45-1d3d-43f3-8f24-0c99629085dd", null, "Guest", "GUEST" },
                    { "b3a32d67-ac80-4fe3-a228-c32e758fa2dd", null, "Premium", "PREMIUM" },
                    { "b8562fbc-00d0-4f43-b755-dcbcc83fcfe8", null, "Admin", "ADMIN" },
                    { "c4c10092-7a18-4c85-ac43-c7b2e818eff9", null, "User", "USER" },
                    { "f2ef7867-999f-4967-884c-f8d80e17fdd7", null, "Creator", "CREATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "046e5edd-3454-4a91-b5ca-fbb9ecfc51e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55532218-0ffb-47d8-a9bc-c7fdab2c3b51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cafdc45-1d3d-43f3-8f24-0c99629085dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3a32d67-ac80-4fe3-a228-c32e758fa2dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8562fbc-00d0-4f43-b755-dcbcc83fcfe8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4c10092-7a18-4c85-ac43-c7b2e818eff9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2ef7867-999f-4967-884c-f8d80e17fdd7");

            migrationBuilder.RenameColumn(
                name: "AppUser",
                table: "BookItems",
                newName: "AppUserId");

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
    }
}

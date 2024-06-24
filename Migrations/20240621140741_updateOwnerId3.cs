using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class updateOwnerId3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AppUser",
                table: "BookItems");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "BookItems",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateIndex(
                name: "IX_BookItems_OwnerId",
                table: "BookItems",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookItems_AspNetUsers_OwnerId",
                table: "BookItems",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookItems_AspNetUsers_OwnerId",
                table: "BookItems");

            migrationBuilder.DropIndex(
                name: "IX_BookItems_OwnerId",
                table: "BookItems");

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

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "BookItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "AppUser",
                table: "BookItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}

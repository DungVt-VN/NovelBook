using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddMangaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapter_BookItems_MangaId",
                table: "Chapter");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e74689a-6e9f-4fb5-90ec-4c8967b470f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87c41be2-4076-472d-a602-6e166901d51b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99c3d31b-a97d-4ae5-9dca-694402376c63");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a394afde-9eb1-4c4f-b6b0-ada29a1f33ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c447b22e-7ed3-4922-80cb-b63d30a290d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd62d114-c07f-492b-a384-ce381cfd2d49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef916dbc-be43-4167-9bea-6bf6d5e41ff2");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BookItems");

            migrationBuilder.RenameColumn(
                name: "Liked",
                table: "Comment",
                newName: "Likes");

            migrationBuilder.CreateTable(
                name: "Mangas",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mangas", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Mangas_BookItems_BookId",
                        column: x => x.BookId,
                        principalTable: "BookItems",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "24ea1791-66e0-4665-a363-dc1d35dc0194", null, "Editor", "EDITOR" },
                    { "32d28cb6-fb53-4fb4-a227-149ff0aa5b98", null, "Admin", "ADMIN" },
                    { "6dac4e72-8819-43cd-99f5-3bac945ceb26", null, "Moderator", "MODERATOR" },
                    { "712e3a0d-7b43-4075-b48f-f3bdd0c1cc11", null, "Guest", "GUEST" },
                    { "db51a791-ed6b-4ece-ad1f-751dba6550a9", null, "Premium", "PREMIUM" },
                    { "de180ece-e3ff-4db7-8031-fc9be86fef5d", null, "Creator", "CREATOR" },
                    { "fe46f8da-4685-43c8-897b-97d19987dc0f", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Chapter_Mangas_MangaId",
                table: "Chapter",
                column: "MangaId",
                principalTable: "Mangas",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapter_Mangas_MangaId",
                table: "Chapter");

            migrationBuilder.DropTable(
                name: "Mangas");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24ea1791-66e0-4665-a363-dc1d35dc0194");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32d28cb6-fb53-4fb4-a227-149ff0aa5b98");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6dac4e72-8819-43cd-99f5-3bac945ceb26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "712e3a0d-7b43-4075-b48f-f3bdd0c1cc11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db51a791-ed6b-4ece-ad1f-751dba6550a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de180ece-e3ff-4db7-8031-fc9be86fef5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe46f8da-4685-43c8-897b-97d19987dc0f");

            migrationBuilder.RenameColumn(
                name: "Likes",
                table: "Comment",
                newName: "Liked");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BookItems",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e74689a-6e9f-4fb5-90ec-4c8967b470f5", null, "Guest", "GUEST" },
                    { "87c41be2-4076-472d-a602-6e166901d51b", null, "Editor", "EDITOR" },
                    { "99c3d31b-a97d-4ae5-9dca-694402376c63", null, "Moderator", "MODERATOR" },
                    { "a394afde-9eb1-4c4f-b6b0-ada29a1f33ff", null, "Admin", "ADMIN" },
                    { "c447b22e-7ed3-4922-80cb-b63d30a290d3", null, "User", "USER" },
                    { "cd62d114-c07f-492b-a384-ce381cfd2d49", null, "Premium", "PREMIUM" },
                    { "ef916dbc-be43-4167-9bea-6bf6d5e41ff2", null, "Creator", "CREATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Chapter_BookItems_MangaId",
                table: "Chapter",
                column: "MangaId",
                principalTable: "BookItems",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homework5._29.Data.Migrations
{
    public partial class updatetablenameagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmark_Users_UserId",
                table: "Bookmark");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmark",
                table: "Bookmark");

            migrationBuilder.RenameTable(
                name: "Bookmark",
                newName: "Bookmarks");

            migrationBuilder.RenameIndex(
                name: "IX_Bookmark_UserId",
                table: "Bookmarks",
                newName: "IX_Bookmarks_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Users_UserId",
                table: "Bookmarks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Users_UserId",
                table: "Bookmarks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks");

            migrationBuilder.RenameTable(
                name: "Bookmarks",
                newName: "Bookmark");

            migrationBuilder.RenameIndex(
                name: "IX_Bookmarks_UserId",
                table: "Bookmark",
                newName: "IX_Bookmark_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmark",
                table: "Bookmark",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmark_Users_UserId",
                table: "Bookmark",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

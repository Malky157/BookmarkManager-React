using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homework5._29.Data.Migrations
{
    public partial class updatetablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookmarkedWebsites_Users_UserId",
                table: "BookmarkedWebsites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookmarkedWebsites",
                table: "BookmarkedWebsites");

            migrationBuilder.RenameTable(
                name: "BookmarkedWebsites",
                newName: "Bookmark");

            migrationBuilder.RenameIndex(
                name: "IX_BookmarkedWebsites_UserId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmark_Users_UserId",
                table: "Bookmark");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmark",
                table: "Bookmark");

            migrationBuilder.RenameTable(
                name: "Bookmark",
                newName: "BookmarkedWebsites");

            migrationBuilder.RenameIndex(
                name: "IX_Bookmark_UserId",
                table: "BookmarkedWebsites",
                newName: "IX_BookmarkedWebsites_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookmarkedWebsites",
                table: "BookmarkedWebsites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookmarkedWebsites_Users_UserId",
                table: "BookmarkedWebsites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

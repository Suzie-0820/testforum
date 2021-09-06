using Microsoft.EntityFrameworkCore.Migrations;

namespace testholger.Migrations
{
    public partial class littlechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_AuthorUsersId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "AuthorUsersId",
                table: "Posts",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AuthorUsersId",
                table: "Posts",
                newName: "IX_Posts_UsersId");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Topics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UsersId",
                table: "Posts",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "UsersId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UsersId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Posts",
                newName: "AuthorUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_UsersId",
                table: "Posts",
                newName: "IX_Posts_AuthorUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_AuthorUsersId",
                table: "Posts",
                column: "AuthorUsersId",
                principalTable: "Users",
                principalColumn: "UsersId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

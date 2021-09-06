using Microsoft.EntityFrameworkCore.Migrations;

namespace testholger.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OriginalPost",
                table: "Topics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorUsersId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorUsersId",
                table: "Posts",
                column: "AuthorUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_AuthorUsersId",
                table: "Posts",
                column: "AuthorUsersId",
                principalTable: "Users",
                principalColumn: "UsersId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_AuthorUsersId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AuthorUsersId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "OriginalPost",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "AuthorUsersId",
                table: "Posts");
        }
    }
}

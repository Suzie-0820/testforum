using Microsoft.EntityFrameworkCore.Migrations;

namespace testholger.Migrations
{
    public partial class boo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Topics_PostTopicTopicsId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "PostTopicTopicsId",
                table: "Posts",
                newName: "TopicsId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_PostTopicTopicsId",
                table: "Posts",
                newName: "IX_Posts_TopicsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Topics_TopicsId",
                table: "Posts",
                column: "TopicsId",
                principalTable: "Topics",
                principalColumn: "TopicsId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Topics_TopicsId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "TopicsId",
                table: "Posts",
                newName: "PostTopicTopicsId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_TopicsId",
                table: "Posts",
                newName: "IX_Posts_PostTopicTopicsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Topics_PostTopicTopicsId",
                table: "Posts",
                column: "PostTopicTopicsId",
                principalTable: "Topics",
                principalColumn: "TopicsId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

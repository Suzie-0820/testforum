using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace testholger.Migrations
{
    public partial class ChangesAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Topics",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Topics",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumberComments",
                table: "Topics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Topics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TopicSubject",
                table: "Topics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Topics",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PostLikes",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostTopicTopicsId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topics_UsersId",
                table: "Topics",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostTopicTopicsId",
                table: "Posts",
                column: "PostTopicTopicsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Topics_PostTopicTopicsId",
                table: "Posts",
                column: "PostTopicTopicsId",
                principalTable: "Topics",
                principalColumn: "TopicsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Users_UsersId",
                table: "Topics",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "UsersId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Topics_PostTopicTopicsId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Users_UsersId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_UsersId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PostTopicTopicsId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "NumberComments",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "TopicSubject",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostLikes",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostTopicTopicsId",
                table: "Posts");
        }
    }
}

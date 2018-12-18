using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebshopApp.Data.Migrations
{
    public partial class BlogEntityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Blogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedOn",
                table: "Blogs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_ImageId",
                table: "Blogs",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Images_ImageId",
                table: "Blogs",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Images_ImageId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_ImageId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "PostedOn",
                table: "Blogs");
        }
    }
}

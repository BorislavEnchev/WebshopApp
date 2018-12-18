using Microsoft.EntityFrameworkCore.Migrations;

namespace WebshopApp.Data.Migrations
{
    public partial class BlogImagereform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "PictureUri",
                table: "Blogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUri",
                table: "Blogs");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Blogs",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WebshopApp.Data.Migrations
{
    public partial class QuantityAddedtoProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ShoppingCartItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");
        }
    }
}

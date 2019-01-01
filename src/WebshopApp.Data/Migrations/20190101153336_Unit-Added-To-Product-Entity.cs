using Microsoft.EntityFrameworkCore.Migrations;

namespace WebshopApp.Data.Migrations
{
    public partial class UnitAddedToProductEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Products",
                newName: "Unit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "Products",
                newName: "Quantity");
        }
    }
}

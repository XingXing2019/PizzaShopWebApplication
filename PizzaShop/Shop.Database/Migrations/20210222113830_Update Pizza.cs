using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Database.Migrations
{
    public partial class UpdatePizza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToppingLargeImagePath",
                table: "Toppings");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Pizzas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Pizzas");

            migrationBuilder.AddColumn<string>(
                name: "ToppingLargeImagePath",
                table: "Toppings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaX.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStockProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockStatus",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockStatus",
                table: "Fries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockStatus",
                table: "Drinks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockStatus",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "StockStatus",
                table: "Fries");

            migrationBuilder.DropColumn(
                name: "StockStatus",
                table: "Drinks");
        }
    }
}

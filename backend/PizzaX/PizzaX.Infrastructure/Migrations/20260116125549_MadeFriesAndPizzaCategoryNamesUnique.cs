using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaX.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MadeFriesAndPizzaCategoryNamesUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PizzaVarieties",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Fries",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaVarieties_Name",
                table: "PizzaVarieties",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fries_Category",
                table: "Fries",
                column: "Category",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PizzaVarieties_Name",
                table: "PizzaVarieties");

            migrationBuilder.DropIndex(
                name: "IX_Fries_Category",
                table: "Fries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PizzaVarieties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Fries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}

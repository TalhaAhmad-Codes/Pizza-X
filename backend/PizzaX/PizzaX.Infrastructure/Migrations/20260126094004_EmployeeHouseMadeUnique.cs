using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaX.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeHouseMadeUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employees_AddressHouse",
                table: "Employees",
                column: "AddressHouse",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_AddressHouse",
                table: "Employees");
        }
    }
}

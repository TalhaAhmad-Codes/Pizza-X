using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaX.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    FatherName = table.Column<string>(type: "text", nullable: false),
                    CNIC = table.Column<string>(type: "text", nullable: false),
                    AddressHouse = table.Column<string>(type: "text", nullable: false),
                    AddressArea = table.Column<string>(type: "text", nullable: false),
                    AddressStreet = table.Column<string>(type: "text", nullable: true),
                    AddressCity = table.Column<string>(type: "text", nullable: false),
                    AddressProvince = table.Column<string>(type: "text", nullable: true),
                    AddressCountry = table.Column<string>(type: "text", nullable: true),
                    Contact = table.Column<string>(type: "text", nullable: false),
                    JobRole = table.Column<int>(type: "integer", nullable: false),
                    Salary = table.Column<decimal>(type: "numeric", nullable: false),
                    Shift = table.Column<int>(type: "integer", nullable: false),
                    JoiningDate = table.Column<DateOnly>(type: "date", nullable: false),
                    LeftDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CNIC",
                table: "Employees",
                column: "CNIC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Contact",
                table: "Employees",
                column: "Contact",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaX.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Deal_DealItems_Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Name",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "BaseProduct");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "BaseProduct",
                newName: "IX_BaseProduct_CategoryId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "BaseProduct",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BaseProduct",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "BaseProduct",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "DealId",
                table: "BaseProduct",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "BaseProduct",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "BaseProduct",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VarietyId",
                table: "BaseProduct",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseProduct",
                table: "BaseProduct",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DealName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DealItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DealItems_BaseProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "BaseProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DealItems_Deals_DealId",
                        column: x => x.DealId,
                        principalTable: "Deals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseProduct_DealId",
                table: "BaseProduct",
                column: "DealId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseProduct_Name",
                table: "BaseProduct",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BaseProduct_VarietyId",
                table: "BaseProduct",
                column: "VarietyId");

            migrationBuilder.CreateIndex(
                name: "IX_DealItems_DealId",
                table: "DealItems",
                column: "DealId");

            migrationBuilder.CreateIndex(
                name: "IX_DealItems_ProductId",
                table: "DealItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_DealName",
                table: "Deals",
                column: "DealName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProduct_Deals_DealId",
                table: "BaseProduct",
                column: "DealId",
                principalTable: "Deals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProduct_PizzaVarieties_VarietyId",
                table: "BaseProduct",
                column: "VarietyId",
                principalTable: "PizzaVarieties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProduct_ProductCategories_CategoryId",
                table: "BaseProduct",
                column: "CategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseProduct_Deals_DealId",
                table: "BaseProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseProduct_PizzaVarieties_VarietyId",
                table: "BaseProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseProduct_ProductCategories_CategoryId",
                table: "BaseProduct");

            migrationBuilder.DropTable(
                name: "DealItems");

            migrationBuilder.DropTable(
                name: "Deals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseProduct",
                table: "BaseProduct");

            migrationBuilder.DropIndex(
                name: "IX_BaseProduct_DealId",
                table: "BaseProduct");

            migrationBuilder.DropIndex(
                name: "IX_BaseProduct_Name",
                table: "BaseProduct");

            migrationBuilder.DropIndex(
                name: "IX_BaseProduct_VarietyId",
                table: "BaseProduct");

            migrationBuilder.DropColumn(
                name: "DealId",
                table: "BaseProduct");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "BaseProduct");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "BaseProduct");

            migrationBuilder.DropColumn(
                name: "VarietyId",
                table: "BaseProduct");

            migrationBuilder.RenameTable(
                name: "BaseProduct",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_BaseProduct_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VarietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: false),
                    StockStatus = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizzas_PizzaVarieties_VarietyId",
                        column: x => x.VarietyId,
                        principalTable: "PizzaVarieties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_VarietyId",
                table: "Pizzas",
                column: "VarietyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

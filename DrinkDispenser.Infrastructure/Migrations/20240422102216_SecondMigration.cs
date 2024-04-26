using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDispenser.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "VendingMachines",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CountDrinks",
                table: "VendingMachines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Drinks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "Coins",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "VendingMachines");

            migrationBuilder.DropColumn(
                name: "CountDrinks",
                table: "VendingMachines");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "Coins");
        }
    }
}

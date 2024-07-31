using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDispenser.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVendingMachineEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvailableDrinks",
                table: "VendingMachines",
                newName: "CountOfAvailableDrinks");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "VendingMachines",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "VendingMachines");

            migrationBuilder.RenameColumn(
                name: "CountOfAvailableDrinks",
                table: "VendingMachines",
                newName: "AvailableDrinks");
        }
    }
}

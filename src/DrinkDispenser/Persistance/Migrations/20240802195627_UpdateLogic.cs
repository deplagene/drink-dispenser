using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDispenser.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coins_VendingMachines_VendingMachineId",
                table: "Coins");

            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_VendingMachines_VendingMachineId",
                table: "Drinks");

            migrationBuilder.AddForeignKey(
                name: "FK_Coins_VendingMachines_VendingMachineId",
                table: "Coins",
                column: "VendingMachineId",
                principalTable: "VendingMachines",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_VendingMachines_VendingMachineId",
                table: "Drinks",
                column: "VendingMachineId",
                principalTable: "VendingMachines",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coins_VendingMachines_VendingMachineId",
                table: "Coins");

            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_VendingMachines_VendingMachineId",
                table: "Drinks");

            migrationBuilder.AddForeignKey(
                name: "FK_Coins_VendingMachines_VendingMachineId",
                table: "Coins",
                column: "VendingMachineId",
                principalTable: "VendingMachines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_VendingMachines_VendingMachineId",
                table: "Drinks",
                column: "VendingMachineId",
                principalTable: "VendingMachines",
                principalColumn: "Id");
        }
    }
}

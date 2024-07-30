using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDispenser.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class NullableVendingMachine : Migration
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

            migrationBuilder.AlterColumn<Guid>(
                name: "VendingMachineId",
                table: "Drinks",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "VendingMachineId",
                table: "Coins",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coins_VendingMachines_VendingMachineId",
                table: "Coins");

            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_VendingMachines_VendingMachineId",
                table: "Drinks");

            migrationBuilder.AlterColumn<Guid>(
                name: "VendingMachineId",
                table: "Drinks",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "VendingMachineId",
                table: "Coins",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Coins_VendingMachines_VendingMachineId",
                table: "Coins",
                column: "VendingMachineId",
                principalTable: "VendingMachines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_VendingMachines_VendingMachineId",
                table: "Drinks",
                column: "VendingMachineId",
                principalTable: "VendingMachines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

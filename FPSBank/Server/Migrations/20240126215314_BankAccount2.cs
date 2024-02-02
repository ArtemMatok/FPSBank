using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPSBank.Server.Migrations
{
    /// <inheritdoc />
    public partial class BankAccount2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_CreditCard_CreditCardCreaditCardId",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_DollarCard_DollarCardId",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_MainCard_MainCardId",
                table: "BankAccounts");

            migrationBuilder.AlterColumn<int>(
                name: "MainCardId",
                table: "BankAccounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DollarCardId",
                table: "BankAccounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreditCardCreaditCardId",
                table: "BankAccounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_CreditCard_CreditCardCreaditCardId",
                table: "BankAccounts",
                column: "CreditCardCreaditCardId",
                principalTable: "CreditCard",
                principalColumn: "CreaditCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_DollarCard_DollarCardId",
                table: "BankAccounts",
                column: "DollarCardId",
                principalTable: "DollarCard",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_MainCard_MainCardId",
                table: "BankAccounts",
                column: "MainCardId",
                principalTable: "MainCard",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_CreditCard_CreditCardCreaditCardId",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_DollarCard_DollarCardId",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_MainCard_MainCardId",
                table: "BankAccounts");

            migrationBuilder.AlterColumn<int>(
                name: "MainCardId",
                table: "BankAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DollarCardId",
                table: "BankAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreditCardCreaditCardId",
                table: "BankAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_CreditCard_CreditCardCreaditCardId",
                table: "BankAccounts",
                column: "CreditCardCreaditCardId",
                principalTable: "CreditCard",
                principalColumn: "CreaditCardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_DollarCard_DollarCardId",
                table: "BankAccounts",
                column: "DollarCardId",
                principalTable: "DollarCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_MainCard_MainCardId",
                table: "BankAccounts",
                column: "MainCardId",
                principalTable: "MainCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPSBank.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddNewCards2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_CreditCard_CreditCardId",
                table: "BankAccounts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CreditCard",
                newName: "CreaditCardId");

            migrationBuilder.RenameColumn(
                name: "CreditCardId",
                table: "BankAccounts",
                newName: "CreditCardCreaditCardId");

            migrationBuilder.RenameIndex(
                name: "IX_BankAccounts_CreditCardId",
                table: "BankAccounts",
                newName: "IX_BankAccounts_CreditCardCreaditCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_CreditCard_CreditCardCreaditCardId",
                table: "BankAccounts",
                column: "CreditCardCreaditCardId",
                principalTable: "CreditCard",
                principalColumn: "CreaditCardId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_CreditCard_CreditCardCreaditCardId",
                table: "BankAccounts");

            migrationBuilder.RenameColumn(
                name: "CreaditCardId",
                table: "CreditCard",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CreditCardCreaditCardId",
                table: "BankAccounts",
                newName: "CreditCardId");

            migrationBuilder.RenameIndex(
                name: "IX_BankAccounts_CreditCardCreaditCardId",
                table: "BankAccounts",
                newName: "IX_BankAccounts_CreditCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_CreditCard_CreditCardId",
                table: "BankAccounts",
                column: "CreditCardId",
                principalTable: "CreditCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

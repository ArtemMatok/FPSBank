using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPSBank.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountOperation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankAccountId",
                table: "BankAccounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_BankAccountId",
                table: "BankAccounts",
                column: "BankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_BankAccounts_BankAccountId",
                table: "BankAccounts",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_BankAccounts_BankAccountId",
                table: "BankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_BankAccountId",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "BankAccountId",
                table: "BankAccounts");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPSBank.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBankAccount4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankAccountId1",
                table: "AccountOperation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountOperation_BankAccountId1",
                table: "AccountOperation",
                column: "BankAccountId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOperation_BankAccounts_BankAccountId1",
                table: "AccountOperation",
                column: "BankAccountId1",
                principalTable: "BankAccounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOperation_BankAccounts_BankAccountId1",
                table: "AccountOperation");

            migrationBuilder.DropIndex(
                name: "IX_AccountOperation_BankAccountId1",
                table: "AccountOperation");

            migrationBuilder.DropColumn(
                name: "BankAccountId1",
                table: "AccountOperation");
        }
    }
}

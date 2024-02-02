using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPSBank.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddNewCards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditCardId",
                table: "BankAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DollarCardId",
                table: "BankAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CreditCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberCard = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DollarCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberCard = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DollarCard", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_CreditCardId",
                table: "BankAccounts",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_DollarCardId",
                table: "BankAccounts",
                column: "DollarCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_CreditCard_CreditCardId",
                table: "BankAccounts",
                column: "CreditCardId",
                principalTable: "CreditCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_DollarCard_DollarCardId",
                table: "BankAccounts",
                column: "DollarCardId",
                principalTable: "DollarCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_CreditCard_CreditCardId",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_DollarCard_DollarCardId",
                table: "BankAccounts");

            migrationBuilder.DropTable(
                name: "CreditCard");

            migrationBuilder.DropTable(
                name: "DollarCard");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_CreditCardId",
                table: "BankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_DollarCardId",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "CreditCardId",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "DollarCardId",
                table: "BankAccounts");
        }
    }
}

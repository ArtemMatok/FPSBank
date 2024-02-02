using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPSBank.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAccountOperation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "AccountOperation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOperation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusOperation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankAccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountOperation_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountOperation_BankAccountId",
                table: "AccountOperation",
                column: "BankAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountOperation");

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
    }
}

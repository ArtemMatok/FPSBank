using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPSBank.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOperationAndTransfer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "TransferMoney",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AccountOperation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "TransferMoney");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AccountOperation");
        }
    }
}

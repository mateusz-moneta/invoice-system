using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class InvoiceUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Buyer_Id",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Issuer_Id",
                table: "Invoices");

            migrationBuilder.AddColumn<string>(
                name: "BuyerVATCode",
                table: "Invoices",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IssuerVATCode",
                table: "Invoices",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerVATCode",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "IssuerVATCode",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "Buyer_Id",
                table: "Invoices",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Issuer_Id",
                table: "Invoices",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}

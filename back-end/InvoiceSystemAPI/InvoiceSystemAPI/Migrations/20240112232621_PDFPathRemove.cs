using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class PDFPathRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PdfPath",
                table: "Invoices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PdfPath",
                table: "Invoices",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}

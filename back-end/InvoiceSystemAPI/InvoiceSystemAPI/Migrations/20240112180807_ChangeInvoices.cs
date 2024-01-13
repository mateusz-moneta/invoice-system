using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InvoiceSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInvoices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Invoice_Id = table.Column<string>(type: "text", nullable: false),
                    Invoice_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Transaction_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Payment_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false),
                    Issuer_Id = table.Column<int>(type: "integer", nullable: false),
                    Issuer_Name = table.Column<string>(type: "text", nullable: false),
                    Issuer_Address = table.Column<string>(type: "text", nullable: false),
                    Issuer_City = table.Column<string>(type: "text", nullable: false),
                    Issuer_Zip = table.Column<string>(type: "text", nullable: false),
                    Buyer_Id = table.Column<int>(type: "integer", nullable: false),
                    Buyer_Name = table.Column<string>(type: "text", nullable: false),
                    Buyer_Address = table.Column<string>(type: "text", nullable: false),
                    Buyer_City = table.Column<string>(type: "text", nullable: false),
                    Buyer_Zip = table.Column<string>(type: "text", nullable: false),
                    Is_Paid = table.Column<bool>(type: "boolean", nullable: false),
                    Status_Id = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

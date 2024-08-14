using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallEcommerceProject.Migrations
{
    /// <inheritdoc />
    public partial class Cart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Cart_Id",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.CheckConstraint("CK_TotalPrice_NoNegative", "[TotalPrice]>=0");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Cart_Id",
                table: "Products",
                column: "Cart_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Cart_Cart_Id",
                table: "Products",
                column: "Cart_Id",
                principalTable: "Cart",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Cart_Cart_Id",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Products_Cart_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Cart_Id",
                table: "Products");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace _3_Data.Migrations
{
    /// <inheritdoc />
    public partial class SaleConcepts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Beer",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Concept",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdBeer = table.Column<int>(type: "int", nullable: false),
                    IdSale = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concept", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Concept_Beer_IdBeer",
                        column: x => x.IdBeer,
                        principalTable: "Beer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Concept_Sale_IdSale",
                        column: x => x.IdSale,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Concept_IdBeer",
                table: "Concept",
                column: "IdBeer");

            migrationBuilder.CreateIndex(
                name: "IX_Concept_IdSale",
                table: "Concept",
                column: "IdSale");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Concept");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Beer");
        }
    }
}

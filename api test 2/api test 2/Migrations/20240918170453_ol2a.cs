using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_test_2.Migrations
{
    /// <inheritdoc />
    public partial class ol2a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bands_Styles_StyleID",
                table: "Bands");

            migrationBuilder.AlterColumn<int>(
                name: "StyleID",
                table: "Bands",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bands_Styles_StyleID",
                table: "Bands",
                column: "StyleID",
                principalTable: "Styles",
                principalColumn: "StyleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bands_Styles_StyleID",
                table: "Bands");

            migrationBuilder.AlterColumn<int>(
                name: "StyleID",
                table: "Bands",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Bands_Styles_StyleID",
                table: "Bands",
                column: "StyleID",
                principalTable: "Styles",
                principalColumn: "StyleId");
        }
    }
}

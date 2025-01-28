using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cf.Dotnet.EntityFramework.Parte5.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: -1688817565);

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: -883087604);

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: -616574076);

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: -164019224);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: -2123293431);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1231359541);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1312471759);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: -1762581106);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: -1678726481);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: -1461459372);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: -887410311);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: -353702825);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 226757684);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 272561428);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 685301010);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1345291401);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1629067545);

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: -2099722467);

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: -1803193904);

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: -196266089);

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 685362692);

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 827837288);

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 1541779665);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: -1844279215);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: -437882865);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: -64352089);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 314028962);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 486680686);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1417718545);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2098273525);

            migrationBuilder.InsertData(
                table: "CatalogItems",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 62202779, "indigo", 0.7406917764239440m },
                    { 170307152, "Team-oriented", 0.4110946162612770m },
                    { 403144518, "navigate", 0.7480105917249670m },
                    { 777235512, "neural", 0.4348467837971520m },
                    { 1035187876, "Rand", 0.3187806442828970m },
                    { 1527132064, "interface", 0.03759202886896360m },
                    { 1627690230, "Principal", 0.9403404901620640m },
                    { 1854948403, "Analyst", 0.6552809700941160m },
                    { 1999405661, "COM", 0.1301395832384160m },
                    { 2121178650, "Bedfordshire", 0.08117704624213320m }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 269531841, "Handmade Granite Chair" },
                    { 1250048129, "circuit" },
                    { 1400559217, "Manager" },
                    { 1440246757, "Awesome" },
                    { 1548625142, "pink" },
                    { 1600760419, "withdrawal" },
                    { 1777755962, "copying" },
                    { 1784559130, "recontextualize" },
                    { 1989899502, "purple" },
                    { 2113317830, "GB" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CatalogItemId", "CustomerId", "Quantity" },
                values: new object[,]
                {
                    { 106842929, 170307152, 1400559217, 481663073 },
                    { 118231333, 170307152, 1989899502, -1703387782 },
                    { 455695385, 403144518, 1600760419, -934525895 },
                    { 503200746, 777235512, 1989899502, 909388729 },
                    { 539681038, 1999405661, 1400559217, 658515941 },
                    { 977156273, 1627690230, 1777755962, 57636514 },
                    { 1110588061, 403144518, 1400559217, 1692508996 },
                    { 1661277252, 1999405661, 1777755962, 52140459 },
                    { 1689251316, 2121178650, 1250048129, 2129188673 },
                    { 1980459864, 1999405661, 1400559217, 1741749428 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 62202779);

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 1035187876);

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 1527132064);

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 1854948403);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 269531841);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1440246757);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1548625142);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1784559130);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2113317830);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 106842929);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 118231333);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 455695385);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 503200746);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 539681038);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 977156273);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1110588061);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1661277252);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1689251316);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1980459864);

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 170307152);

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 403144518);

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 777235512);

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 1627690230);

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 1999405661);

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 2121178650);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1250048129);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1400559217);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1600760419);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1777755962);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1989899502);

            migrationBuilder.InsertData(
                table: "CatalogItems",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { -2099722467, "compress", 0.7559692915880470m },
                    { -1803193904, "Turkey", 0.6874146819010130m },
                    { -1688817565, "collaboration", 0.9978162533548330m },
                    { -883087604, "bricks-and-clicks", 0.4703248002597940m },
                    { -616574076, "bus", 0.008210504012866270m },
                    { -196266089, "distributed", 0.4246440187374280m },
                    { -164019224, "Villages", 0.4934813939685640m },
                    { 685362692, "Frozen", 0.2460276737248510m },
                    { 827837288, "yellow", 0.1991782144448260m },
                    { 1541779665, "vortals", 0.4178059139385060m }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { -2123293431, "cyan" },
                    { -1844279215, "Handcrafted Cotton Pizza" },
                    { -437882865, "Planner" },
                    { -64352089, "Beauty" },
                    { 314028962, "quantifying" },
                    { 486680686, "Home" },
                    { 1231359541, "extranet" },
                    { 1312471759, "cross-platform" },
                    { 1417718545, "empower" },
                    { 2098273525, "mobile" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CatalogItemId", "CustomerId", "Quantity" },
                values: new object[,]
                {
                    { -1762581106, -2099722467, -64352089, -1923650843 },
                    { -1678726481, -196266089, -437882865, -1791864025 },
                    { -1461459372, -196266089, 2098273525, -1986658322 },
                    { -887410311, 685362692, 486680686, 1487383197 },
                    { -353702825, -1803193904, -1844279215, 449927245 },
                    { 226757684, -1803193904, -1844279215, 378779742 },
                    { 272561428, 827837288, 1417718545, -559304829 },
                    { 685301010, -196266089, -437882865, 1784103946 },
                    { 1345291401, 1541779665, -64352089, -1284876059 },
                    { 1629067545, -196266089, 314028962, -1690769054 }
                });
        }
    }
}

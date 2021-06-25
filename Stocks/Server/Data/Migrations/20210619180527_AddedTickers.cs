using Microsoft.EntityFrameworkCore.Migrations;

namespace Stocks.Server.Data.Migrations
{
    public partial class AddedTickers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TickersDetails",
                columns: table => new
                {
                    IdTickersDetails = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    listdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bloomberg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lei = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sic = table.Column<int>(type: "int", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    industry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    marketcap = table.Column<long>(type: "bigint", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ceo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    exchange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    exchangeSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hq_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hq_state = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hq_country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TickersDetails", x => x.IdTickersDetails);
                });

            migrationBuilder.CreateTable(
                name: "TickersUsers",
                columns: table => new
                {
                    IdTickersDetails = table.Column<int>(type: "int", nullable: false),
                    IdApplicationUser = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TickersUsers", x => new { x.IdTickersDetails, x.IdApplicationUser });
                    table.ForeignKey(
                        name: "FK_TickersUsers_AspNetUsers_IdApplicationUser",
                        column: x => x.IdApplicationUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TickersUsers_TickersDetails_IdTickersDetails",
                        column: x => x.IdTickersDetails,
                        principalTable: "TickersDetails",
                        principalColumn: "IdTickersDetails",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TickersUsers_IdApplicationUser",
                table: "TickersUsers",
                column: "IdApplicationUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TickersUsers");

            migrationBuilder.DropTable(
                name: "TickersDetails");
        }
    }
}

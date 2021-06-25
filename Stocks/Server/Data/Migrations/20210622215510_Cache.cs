using Microsoft.EntityFrameworkCore.Migrations;

namespace Stocks.Server.Data.Migrations
{
    public partial class Cache : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TickerOHLC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TickerName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    V = table.Column<double>(type: "float", nullable: false),
                    Vw = table.Column<double>(type: "float", nullable: false),
                    O = table.Column<double>(type: "float", nullable: false),
                    C = table.Column<double>(type: "float", nullable: false),
                    H = table.Column<double>(type: "float", nullable: false),
                    L = table.Column<double>(type: "float", nullable: false),
                    T = table.Column<double>(type: "float", nullable: false),
                    N = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TickerOHLC", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TickerOHLC_TickerName",
                table: "TickerOHLC",
                column: "TickerName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TickerOHLC");
        }
    }
}

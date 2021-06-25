using Microsoft.EntityFrameworkCore.Migrations;

namespace Stocks.Server.Data.Migrations
{
    public partial class Cache2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TickerOHLC_T",
                table: "TickerOHLC",
                column: "T");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TickerOHLC_T",
                table: "TickerOHLC");
        }
    }
}

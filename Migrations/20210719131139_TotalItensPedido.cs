using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteLance.Migrations
{
    public partial class TotalItensPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalItensPedido",
                table: "Pedidos",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalItensPedido",
                table: "Pedidos");
        }
    }
}

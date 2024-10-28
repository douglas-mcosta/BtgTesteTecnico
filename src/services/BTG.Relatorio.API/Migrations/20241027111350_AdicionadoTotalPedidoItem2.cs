using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTG.Relatorio.API.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoTotalPedidoItem2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "PedidoItens",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "PedidoItens");
        }
    }
}

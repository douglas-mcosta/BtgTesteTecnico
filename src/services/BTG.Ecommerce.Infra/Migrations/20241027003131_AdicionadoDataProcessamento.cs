using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTG.Clientes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoDataProcessamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Pedidos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataProcessamento",
                table: "Pedidos",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "DataProcessamento",
                table: "Pedidos");
        }
    }
}

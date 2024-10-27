using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTG.Relatorio.API.Migrations
{
    /// <inheritdoc />
    public partial class correcaoCampos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CodigoCliente",
                table: "Pedidos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoCliente",
                table: "Pedidos");
        }
    }
}

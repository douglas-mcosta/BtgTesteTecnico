using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTG.Clientes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class DataCadastroAtualizacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Clientes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Clientes");
        }
    }
}

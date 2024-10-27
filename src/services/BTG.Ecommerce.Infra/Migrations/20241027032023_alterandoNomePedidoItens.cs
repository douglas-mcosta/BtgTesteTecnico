using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTG.Clientes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class alterandoNomePedidoItens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItems_Pedidos_PedidoId",
                table: "PedidoItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItems_Produtos_ProdutoId",
                table: "PedidoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoItems",
                table: "PedidoItems");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Pedidos");

            migrationBuilder.RenameTable(
                name: "PedidoItems",
                newName: "PedidoItens");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoItems_ProdutoId",
                table: "PedidoItens",
                newName: "IX_PedidoItens_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoItems_PedidoId",
                table: "PedidoItens",
                newName: "IX_PedidoItens_PedidoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoItens",
                table: "PedidoItens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItens_Pedidos_PedidoId",
                table: "PedidoItens",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItens_Produtos_ProdutoId",
                table: "PedidoItens",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItens_Pedidos_PedidoId",
                table: "PedidoItens");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItens_Produtos_ProdutoId",
                table: "PedidoItens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoItens",
                table: "PedidoItens");

            migrationBuilder.RenameTable(
                name: "PedidoItens",
                newName: "PedidoItems");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoItens_ProdutoId",
                table: "PedidoItems",
                newName: "IX_PedidoItems_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoItens_PedidoId",
                table: "PedidoItems",
                newName: "IX_PedidoItems_PedidoId");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Pedidos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Pedidos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Pedidos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Pedidos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Pedidos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Pedidos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Pedidos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoItems",
                table: "PedidoItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItems_Pedidos_PedidoId",
                table: "PedidoItems",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItems_Produtos_ProdutoId",
                table: "PedidoItems",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");
        }
    }
}

using BTG.Ecommerce.Domain.Models;
using System;

namespace BTG.Ecommerce.Application.ViewModel
{
    public class PedidoItemViewModel
    {
        public Guid ProdutoId { get; set; }
        public Guid PedidoId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Imagem { get; set; }
        public int Quantidade { get; set; }

        public static PedidoItem ParaPedidoItem(PedidoItemViewModel pedidoItemDto)
        {
            var pedidoItem = new PedidoItem(
                pedidoItemDto.PedidoId,
                pedidoItemDto.ProdutoId,
                pedidoItemDto.Nome,
                pedidoItemDto.Quantidade,
                pedidoItemDto.Valor,
                pedidoItemDto.Imagem);

            return pedidoItem;
        }
    }
}
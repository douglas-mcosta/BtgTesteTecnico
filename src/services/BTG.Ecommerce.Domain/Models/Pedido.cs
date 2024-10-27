using BTG.Core.DomainObjects;
using BTG.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTG.Ecommerce.Domain.Models
{
    public class Pedido : Entity
    {
        public Pedido()
        {
            PedidoItems = new List<PedidoItem>();
        }
        public Pedido(Guid clienteId) : this()
        {
            ClienteId = clienteId;
            PedidoStatus = PedidoStatus.Aberto;
        }

        public int Codigo { get; private set; }
        public Guid ClienteId { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }
        public DateTime? DataProcessamento { get; private set; }
        public PedidoStatus PedidoStatus { get; private set; }
        public Cliente Cliente { get; private set; }
        public List<PedidoItem> PedidoItems { get; private set; }

        public bool PedidoEstaAberto() => PedidoStatus.Equals(PedidoStatus.Aberto);
        public void CancelarPedidoFaltaEstoque() => PedidoStatus = PedidoStatus.CanceladoFaltaEstoque;
        public void ProcessarPagamento() => PedidoStatus = PedidoStatus.Processado;

        public void ProcessarPedido()
        {
            DataProcessamento = DateTime.Now;
        }

        public void CalcularValorPedido()
        {
            ValorTotal = PedidoItems.Sum(p => p.CalcularValor());
        }

        public void AddItemPedido(PedidoItem novoItem)
        {
            if (PedidoItems is null) PedidoItems = new List<PedidoItem>();

            if (ExisteItem(novoItem))
            {
                var item = ObterItem(novoItem);
                item.SomarQuantidade(novoItem.Quantidade);
                item.CalcularValor();
                CalcularValorPedido();
                return;
            }

            PedidoItems.Add(novoItem);
            CalcularValorPedido();
        }

        public void RemoverItemPedido(PedidoItem item)
        {
            if (ExisteItem(item))
            {
                PedidoItems.Remove(item);
                CalcularValorPedido();
                return;
            }
        }

        public bool ExisteItem(PedidoItem item)
        {
            return PedidoItems.Any(x => x.ProdutoId == item.ProdutoId);
        }

        public PedidoItem ObterItem(PedidoItem item)
        {
            return PedidoItems.FirstOrDefault(x => x.ProdutoId == item.ProdutoId);
        }
    }
}
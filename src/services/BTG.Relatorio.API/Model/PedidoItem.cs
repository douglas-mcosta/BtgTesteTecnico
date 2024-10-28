using BTG.Core.DomainObjects;
using System.Text.Json.Serialization;

namespace BTG.Relatorio.API.Model
{
    public class PedidoItem : Entity
    {
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal Total { get => CalcularValor(); set { } }
        public Guid PedidoId { get; set; }
        [JsonIgnore]
        public Pedido Pedido { get; set; }
        private decimal CalcularValor() => Quantidade * Preco;
    }
}

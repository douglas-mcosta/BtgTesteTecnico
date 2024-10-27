namespace BTG.Relatorio.API.Model
{
    public class RelatorioPedidoProcessado
    {
        public Guid CodigoCliente { get; set; }
        public string NomeCliente { get; set; }
        public int QtdPedidos { get; set; }
        public decimal ValorTotal { get; set; }
        public List<Pedido> Pedidos { get; set; }
    }
}

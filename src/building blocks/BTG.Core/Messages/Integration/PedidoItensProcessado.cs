namespace BTG.Core.Messages.Integration
{
    public class PedidoItensProcessado
    {
        public Guid Id{ get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }
}
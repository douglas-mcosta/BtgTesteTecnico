using BTG.Ecommerce.Domain.Models;

namespace BTG.Ecommerce.Application.ViewModel
{
    public class PedidoViewModel
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public int Codigo { get; set; }
        public int Status { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }
        public List<PedidoItemViewModel> PedidoItems { get; set; }

        public EnderecoViewModel Endereco { get; set; }
       
    }
}
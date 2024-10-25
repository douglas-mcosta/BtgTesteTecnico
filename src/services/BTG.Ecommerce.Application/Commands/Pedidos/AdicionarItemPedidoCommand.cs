using BTG.Core.Messages;
using FluentValidation;

namespace BTG.Ecommerce.Application.Commands.Pedidos
{
    public class AdicionarItemPedidoCommand : Command
    {
        public AdicionarItemPedidoCommand(Guid produtoId, Guid clienteId)
        {
            ProdutoId = produtoId;
            ClienteId = clienteId;
        }

        public Guid ProdutoId { get; set; }
        public Guid ClienteId { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarItemPedidoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AdicionarItemPedidoCommandValidation : AbstractValidator<AdicionarItemPedidoCommand>
    {

        public AdicionarItemPedidoCommandValidation()
        {
            RuleFor(x => x.ProdutoId).NotEmpty().WithMessage("Produto invalido");
            RuleFor(x => x.ProdutoId).NotNull().WithMessage("Produto invalido");

            RuleFor(x => x.ClienteId).NotEmpty().WithMessage("Cliente invalido");
            RuleFor(x => x.ClienteId).NotNull().WithMessage("Cliente invalido");
        }

    }
}

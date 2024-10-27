using BTG.Core.Messages;
using FluentValidation;

namespace BTG.Ecommerce.Application.Commands.Pedidos
{
    public class ProcessarPedidoCommand : Command
    {
        public ProcessarPedidoCommand(Guid pedidoId, Guid clienteId)
        {
            PedidoId = pedidoId;
            ClienteId = clienteId;
        }

        public Guid ClienteId { get; set; }
        public Guid PedidoId { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new ProcessarPedidoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class ProcessarPedidoCommandValidation : AbstractValidator<ProcessarPedidoCommand>
    {

        public ProcessarPedidoCommandValidation()
        {
            RuleFor(x => x.PedidoId).NotEmpty().WithMessage("Pedido invalido");
            RuleFor(x => x.PedidoId).NotNull().WithMessage("Pedido invalido");

            RuleFor(x => x.ClienteId).NotEmpty().WithMessage("Item invalido");
            RuleFor(x => x.ClienteId).NotNull().WithMessage("Item invalido");
        }

    }
}

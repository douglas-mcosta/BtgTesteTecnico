using BTG.Core.Messages;
using FluentValidation;

namespace BTG.Ecommerce.Application.Commands.Pedidos
{
    public class RemoverItemPedidoCommand : Command
    {
        public RemoverItemPedidoCommand(Guid itemId, Guid clienteId)
        {
            AggregateId = itemId;
            ClienteId = clienteId;
            ItemId = itemId;
        }

        public Guid ClienteId { get; set; }
        public Guid ItemId { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new RemoverItemPedidoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RemoverItemPedidoCommandValidation : AbstractValidator<RemoverItemPedidoCommand>
    {

        public RemoverItemPedidoCommandValidation()
        {
            RuleFor(x => x.ClienteId).NotEmpty().WithMessage("Cliente invalido");
            RuleFor(x => x.ClienteId).NotNull().WithMessage("Cliente invalido");

            RuleFor(x => x.ItemId).NotEmpty().WithMessage("Item invalido");
            RuleFor(x => x.ItemId).NotNull().WithMessage("Item invalido");
        }

    }
}

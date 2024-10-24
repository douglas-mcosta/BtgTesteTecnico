using BTG.Core.Messages;
using FluentValidation;

namespace BTG.Clientes.Application.Commands
{
    public class RegistrarClienteCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public RegistrarClienteCommand(Guid id, string nome, string email, string cpf)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }


        public override bool EhValido()
        {
            ValidationResult = new RegistrarClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
    public class RegistrarClienteCommandValidation : AbstractValidator<RegistrarClienteCommand>
    {
        public RegistrarClienteCommandValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do Cliente inválido.");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do cliente não foi informado");

            RuleFor(c => c.Cpf)
                .Must(TerCpfValido)
                .WithMessage("CPF inválido.");

            RuleFor(c => c.Email)
                .Must(TerEmailValido)
                .WithMessage("E-mail inválido.");
        }

        private static bool TerCpfValido(string cpf)
        {
            return Core.DomainObjects.Cpf.Validar(cpf);
        }
        private static bool TerEmailValido(string email)
        {
            return Core.DomainObjects.Email.Validar(email);
        }
    }
}


using BTG.Core.Messages;
using BTG.Ecommerce.Application.Events.Clientes;
using BTG.Ecommerce.Domain.Interfaces;
using BTG.Ecommerce.Domain.Models;
using FluentValidation.Results;
using MediatR;

namespace BTG.Ecommerce.Application.Commands.Clientes
{
    public class ClienteCommandHandler : CommandHandler,
        IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var cliente = new Cliente(message.Id, message.Nome, message.Email, message.Cpf);
            var clienteExistente = await _clienteRepository.ObterPorCpfAsync(cliente.Cpf.Numero);
            if (clienteExistente != null)
            {
                AdicionarErro("Já existe um cliente com esse CPF cadastrado.");
                return ValidationResult;
            }

            _clienteRepository.Adicionar(cliente);
            cliente.AdicionarEvento(new ClienteRegistradoEvent(message.Id, message.Nome, message.Email, message.Cpf));

            return await SaveChanges(_clienteRepository.UnitOfWork);
        }
    }
}

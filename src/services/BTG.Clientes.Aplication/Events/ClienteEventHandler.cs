﻿using MediatR;

namespace BTG.Clientes.Application.Events
{
    public class ClienteEventHandler : INotificationHandler<ClienteRegistradoEvent>
    {
        public Task Handle(ClienteRegistradoEvent notification, CancellationToken cancellationToken)
        {
            //Enviar evento de confirmação
            return Task.CompletedTask;
        }
    }
}

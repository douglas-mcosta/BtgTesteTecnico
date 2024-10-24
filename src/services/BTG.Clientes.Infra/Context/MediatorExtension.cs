using BTG.Core.Mediator;
using Microsoft.EntityFrameworkCore;
using BTG.Core.DomainObjects;

namespace BTG.Clientes.Infra.Context
{
    public static class MediatorExtension
    {
        public static async Task PublicarEventos<T>(this IMediatorHandler mediator, T context) where T : DbContext
        {
            var domainEntities = context.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notificacoes != null && x.Entity.Notificacoes.Any());

            var domainEvents = domainEntities.
                SelectMany(x => x.Entity.Notificacoes)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.LimparEventos());

            var task = domainEvents
                .Select(async (domainEvents) => {
                    await mediator.PublishEvent(domainEvents);
                });

            await Task.WhenAll(task);
        }
    }
}

using BTG.Core.DomainObjects;
using System;

namespace BTG.Core.DomainObjects.Data
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }
    }
}

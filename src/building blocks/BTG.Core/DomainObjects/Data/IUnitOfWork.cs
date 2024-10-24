
namespace BTG.Core.DomainObjects.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}

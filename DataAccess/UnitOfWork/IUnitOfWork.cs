using DataAccess.Repositories;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDriverRepository Driver {  get; }
    }
}

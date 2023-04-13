using Entities;

namespace Repositories
{
    public interface IDriverRepository:IRepository<Drivers>
    {
        bool delDriver(int id, bool active);
    }
}

using Entities;

namespace DataAccess.Repositories
{
    public interface IDriverRepository:IRepository<Driver>
    {
        void Update(Driver driver);
    }
}

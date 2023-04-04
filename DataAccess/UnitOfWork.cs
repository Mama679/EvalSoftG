using Repositories;
using UnitOWork;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(string connectionString)
        {
            Driver = new DriverRepository(connectionString);
        }
        public IDriverRepository Driver { get; private set; }
    }
}

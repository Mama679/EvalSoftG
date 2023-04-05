using Repositories;
using UnitOWork;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(string connectionString)
        {
            Driver = new DriverRepository(connectionString);
            Vehicle = new VehicleRepository(connectionString);
        }
        public IDriverRepository Driver { get; private set; }
        public IVehicleRepository Vehicle { get; private set; }
    }
}

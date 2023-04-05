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
            Route = new RouteRepository(connectionString);
            Shedule = new SheduleRepository(connectionString);
            User = new UserRepository(connectionString);
        }
        public IDriverRepository Driver { get; private set; }
        public IVehicleRepository Vehicle { get; private set; }
        public IRouteRepository Route { get; private set; }
        public ISheduleRepository Shedule { get; private set; }
        public IUserRepository User { get; private set; }
    }
}

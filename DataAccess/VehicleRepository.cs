using Entities;
using Repositories;

namespace DataAccess
{
    public class VehicleRepository : Repository<Vehicles>, IVehicleRepository
    {
        public VehicleRepository(string connectionStrig) : base(connectionStrig)
        {
        }
    }
}

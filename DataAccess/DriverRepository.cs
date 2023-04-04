using Entities;
using Repositories;

namespace DataAccess
{
    public class DriverRepository : Repository<Drivers>, IDriverRepository
    {
        public DriverRepository(string connectionStrig) : base(connectionStrig)
        {
        }
    }
}

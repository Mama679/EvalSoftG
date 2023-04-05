using Entities;
using Repositories;

namespace DataAccess
{
    public class RouteRepository : Repository<Routes>, IRouteRepository
    {
        public RouteRepository(string connectionStrig) : base(connectionStrig)
        {
        }
    }
}

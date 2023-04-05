using Entities;

namespace Repositories
{
    public interface IRouteRepository:IRepository<Routes>
    {
        int AddRoute(string description, int driverId, int vehicleId, bool active);
        bool UpdateRoute(string description, int driverId, int vehicleId, bool active,int id);
        List<Routes> GetAllRoutes();
        Routes GetRouteById(int id); 

    }
}

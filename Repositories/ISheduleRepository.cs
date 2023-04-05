using Entities;

namespace Repositories
{
    public interface ISheduleRepository:IRepository<Schedules>
    {
        int AddSchedules(int weeknum, DateTime from, DateTime To, bool Active, int routeId);
        bool UpdateShedules(int weeknum, DateTime from, DateTime To, bool Active, int routeId, int id);
        List<Schedules> GetAllShedules();
        Schedules GetSheduleById(int id);
    }
    
}

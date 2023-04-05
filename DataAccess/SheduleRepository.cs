using Entities;
using Repositories;

namespace DataAccess
{
    public class SheduleRepository : Repository<Schedules>, ISheduleRepository
    {
        public SheduleRepository(string connectionStrig) : base(connectionStrig)
        {
        }
    }
}

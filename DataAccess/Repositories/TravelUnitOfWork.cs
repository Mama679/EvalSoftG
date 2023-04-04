using DataAccess.DbContext;
using DataAccess.UnitOfWork;

namespace DataAccess.Repositories
{
    public class TravelUnitOfWork : IUnitOfWork
    {
        private readonly TravelContext _context;
        public TravelUnitOfWork(TravelContext context)
        {
            _context = context;
            Driver = new DriverRepository(_context);
        }

        public IDriverRepository Driver { get; private set; }
    }
}

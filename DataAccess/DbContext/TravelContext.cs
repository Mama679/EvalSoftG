using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbContext
{
    public class TravelContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public TravelContext(DbContextOptions<TravelContext> options) : base(options)
        {

        }

        public DbSet<Driver> Drivers { get; set; }
    }
}
